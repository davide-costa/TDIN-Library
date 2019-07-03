using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using Common;
using PrinterRestService;

namespace StoreRestService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class StoreRestService : IStoreRestService
    {
        private static string informationFileName = "restServiceDataFile";
        private static int replenishmentDefaultValue = 10;

        private List<ComplexOrder> _pendentOrders = new List<ComplexOrder>();
        private List<List<ReplenishmentRequest>> _pendentListOfReplenishmentRequestsOrderedByShipmentOrder = new List<List<ReplenishmentRequest>>();
        private List<KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>>> _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement =
            new List<KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>>>();
        private List<ComplexOrder> _ordersSolved = new List<ComplexOrder>();

        private List<Client> _clients = new List<Client>();
        private Dictionary<int, Client> _clientsMap = new Dictionary<int, Client>();
        public Dictionary<int, Book> _booksCollectionMap = new Dictionary<int, Book>();
        public Dictionary<int, int> _booksAvailability = new Dictionary<int, int>();

        const string description = "This is a queue for sending Replenishment Requests between Store and Warehouse.";
        const string path = @".\Private$\ReplenishmentRequestsQueue";
        private StoreWarehouseMessenger storeWarehouseMessenger;
        private PrinterRestServiceProxy printerRestServiceProxy;



        public void StartService()
        {
           loadSystemInformationFromFile();
           storeWarehouseMessenger = new StoreWarehouseMessenger(path, description);
           printerRestServiceProxy = new PrinterRestServiceProxy();
        }

       public void CloseService()
       {
           saveSystemInformationFromFile();
       }

       public void loadSystemInformationFromFile()
       {
           StoreRestServiceData restServiceData = (StoreRestServiceData)Utils.LoadObjectToFileAsBinary(informationFileName);
           if (restServiceData == null)
               return;

           _pendentOrders = restServiceData._pendentOrders;
           _pendentListOfReplenishmentRequestsOrderedByShipmentOrder = restServiceData._pendentListOfReplenishmentRequestsOrderedByShipmentOrder;
           _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement = restServiceData._pendentOrdersThatWereSolvedToBooksRemainingStockIncrement;
           _ordersSolved = restServiceData._ordersSolved;
           _clients = restServiceData._clients;
           _clientsMap = restServiceData._clientsMap;
           _booksCollectionMap = restServiceData._booksCollectionMap;
           _booksAvailability = restServiceData._booksAvailability;
           Book.CurrId = restServiceData._bookCurrId;
           Client.CurrId = restServiceData._clientCurrId;
           ReplenishmentRequest.CurrId = restServiceData._replenishmentRequestCurrId;
           Order.CurrId = restServiceData._orderCurrId;
       }

       public void saveSystemInformationFromFile()
       {
           StoreRestServiceData restServiceData = new StoreRestServiceData();
           restServiceData._pendentOrders = _pendentOrders;
           restServiceData._pendentListOfReplenishmentRequestsOrderedByShipmentOrder = _pendentListOfReplenishmentRequestsOrderedByShipmentOrder;
           restServiceData._pendentOrdersThatWereSolvedToBooksRemainingStockIncrement = _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement;
           restServiceData._ordersSolved = _ordersSolved;
           restServiceData._clients = _clients;
           restServiceData._clientsMap = _clientsMap;
           restServiceData._booksCollectionMap = _booksCollectionMap;
           restServiceData._booksAvailability = _booksAvailability;
           restServiceData._bookCurrId = Book.CurrId;
           restServiceData._clientCurrId = Client.CurrId;
           restServiceData._replenishmentRequestCurrId = ReplenishmentRequest.CurrId;
           restServiceData._orderCurrId = Order.CurrId;

            Utils.SaveObjectToFileAsBinary(restServiceData, informationFileName);
       }

       public void ReceiveReplenishmentRequestDelivery(string deliveryIndex)
       {
           bool isNumeric = int.TryParse(deliveryIndex, out int deliveryIndexNumber);
           if (!isNumeric)
               return;

           int pendentOrdersListIndex = deliveryIndexNumber;
           List<ComplexOrder> pendentOrdersThatWereSolved = _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement[pendentOrdersListIndex].Key;
            foreach (ComplexOrder orderSolved in pendentOrdersThatWereSolved)
           {
               _ordersSolved.Add(orderSolved);
               orderSolved.State = Order.DispatchedAtDate();
                string pendentOrderReport = orderSolved.State;
                pendentOrderReport += "\n\n";
                pendentOrderReport = GenerateTableForOrderReport(orderSolved, pendentOrderReport);
                string clientEmail = orderSolved.Client.Email;
                string clientName = orderSolved.Client.Name;
                EmailSender.SendEmail(pendentOrderReport, "Pending Order is Solved", clientEmail, clientName);
            }

           Dictionary<Book, int> booksToRemainingStockIncrement = _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement[pendentOrdersListIndex].Value;
           foreach (KeyValuePair<Book, int> bookToRemainingStockIncrement in booksToRemainingStockIncrement)
           {
               Book book = bookToRemainingStockIncrement.Key;
               int remainingStockIncrement = bookToRemainingStockIncrement.Value;

               _booksAvailability[book.Id] += remainingStockIncrement;
           }

           _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement.RemoveAt(pendentOrdersListIndex);
           _pendentListOfReplenishmentRequestsOrderedByShipmentOrder.RemoveAt(pendentOrdersListIndex);
       }

       public BooksAndAvailability GetBooksListAndAvailability()
       {
           Console.WriteLine("GetBooksListAndAvailability");
           Dictionary<Book, int> bookToAvailability = new Dictionary<Book, int>();
           foreach (KeyValuePair<int, Book> bookIdToBookObject in _booksCollectionMap)
           {
               Book book = bookIdToBookObject.Value;
               int availability = _booksAvailability[bookIdToBookObject.Key];

               bookToAvailability[book] = availability;
           }

           BooksAndAvailability booksAndAvailability = new BooksAndAvailability();
           booksAndAvailability.books = new List<BookData>();
           List<Book> books = new List<Book>(bookToAvailability.Keys);
           foreach(Book book in books)
           {
               BookData bookData = new BookData();
               bookData.Id = book.Id;
               bookData.Price = book.Price;
               bookData.Title = book.Title;

               booksAndAvailability.books.Add(bookData);
           }
           booksAndAvailability.availabilities = new List<int>(bookToAvailability.Values);
           return booksAndAvailability;
       }

       public List<Client> GetClients()
       {
           return _clients;
       }

       private KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>> GetPendentOrdersSolvedWithStockIncrementForThisBook(Dictionary<Book, int> booksToIncrementStock)
       {
           List<ComplexOrder> pendentOrdersThatWereSolved = new List<ComplexOrder>();
           foreach (ComplexOrder complexOrder in _pendentOrders)
           {
               int pendentBooksThatAreFilled = 0;
               foreach (KeyValuePair<Book, int> bookToQuantity in complexOrder.BooksToQuantity)
               {
                   if (booksToIncrementStock.Any(kvp => kvp.Key.Id == bookToQuantity.Key.Id))
                   {
                       Book book = booksToIncrementStock.Keys.First(b => b.Id == bookToQuantity.Key.Id);
                       if (bookToQuantity.Value <= booksToIncrementStock[book])
                       {
                           booksToIncrementStock[book] -= bookToQuantity.Value;
                           complexOrder.BooksToSatisfied[bookToQuantity.Key] = true;
                       }

                       if (complexOrder.BooksToSatisfied[bookToQuantity.Key])
                           pendentBooksThatAreFilled++;
                   }
               }

               if (pendentBooksThatAreFilled == complexOrder.BooksToQuantity.Count)
                   pendentOrdersThatWereSolved.Add(complexOrder);
           }

           return new KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>>(pendentOrdersThatWereSolved, booksToIncrementStock);
       }

       public void AddNewClient(string name, string address, string email)
       {
           Client newClient = new Client(name, email, address);
           _clients.Add(newClient);
           _clientsMap.Add(newClient.Id, newClient);
       }

       public void RemoveClient(string clientId)
       {
           bool isNumeric = int.TryParse(clientId, out int clientIdNumber);
           if(!isNumeric)
               return;

           Client client = _clientsMap[clientIdNumber];
           if (client != null)
           {
               _clients.Remove(client);
               _clientsMap.Remove(clientIdNumber);
           }
       }

       private void CreateOrIncrementEntryInDictionary(Dictionary<Book, int> dictionary, Book book, int value)
       {
           if (dictionary.ContainsKey(book))
               dictionary[book] += value;
           else
               dictionary[book] = value;
       }

       public void RegisterOrdersListByClientEmail(string clientEmail, BasicOrderData basicOrderData)
       {
            Client client = _clients.Find(c => c.Email == clientEmail);
            if (client == default(Client))
                throw new KeyNotFoundException();

            RegisterOrdersListByClientId(client.Id.ToString(), basicOrderData);
       }
       
       public void RegisterOrdersListByClientId(string clientId, BasicOrderData basicOrderData)
       {
           Console.WriteLine("Store RegisterOrdersListByClientId");
           int clientIdNumber = Convert.ToInt32(clientId);
           Dictionary<Book, int> orderAvailableBooks = new Dictionary<Book, int>();
           Dictionary<Book, int> orderPendentBooks = new Dictionary<Book, int>();

           for(int i = 0; i < basicOrderData.BooksIds.Count; i++)
           {
               int bookId = basicOrderData.BooksIds[i];
               int wantedQuantity = basicOrderData.BooksQuantity[i];

               int availableQuantity = _booksAvailability[bookId];
               if (availableQuantity >= wantedQuantity)
               {
                   CreateOrIncrementEntryInDictionary(orderAvailableBooks, _booksCollectionMap[bookId], wantedQuantity);
                   if(availableQuantity == wantedQuantity)
                       GenerateStockFault(_booksCollectionMap[bookId], replenishmentDefaultValue);

                }
               else
               {
                   int satisfiedQuantity = availableQuantity;
                   if (availableQuantity > 0)
                       CreateOrIncrementEntryInDictionary(orderAvailableBooks, _booksCollectionMap[bookId], satisfiedQuantity);
                   CreateOrIncrementEntryInDictionary(orderPendentBooks, _booksCollectionMap[bookId], wantedQuantity - satisfiedQuantity);
               }

               //removes all quantity wanted from availability to leave counters with current availability value
               //a negative value indicates the quantity of that book that is already being waited for other people
               _booksAvailability[bookId] -= wantedQuantity;
           }

           string orderString = "";
           if (orderAvailableBooks.Count != 0)
           {
               ComplexOrder solvedOrder = new ComplexOrder(orderAvailableBooks,
                   _clientsMap[clientIdNumber], Order.DispatchedAtDate(), true);
               _ordersSolved.Add(solvedOrder);

               orderString += GenerateInvoiceString(solvedOrder);

                string solvedOrderReport = solvedOrder.State;
                solvedOrderReport += "\n\n";
                solvedOrderReport = GenerateTableForOrderReport(solvedOrder, solvedOrderReport);
                string clientEmail = solvedOrder.Client.Email;
                string clientName = solvedOrder.Client.Name;
                EmailSender.SendEmail(solvedOrderReport, "New Order", clientEmail, clientName);
            }

           if (orderPendentBooks.Count != 0)
           {
               ComplexOrder pendentOrder = new ComplexOrder(orderPendentBooks,
                   _clientsMap[clientIdNumber], Order.WaitingExpedition, false);
               _pendentOrders.Add(pendentOrder);

               orderString += GeneratePendentOrderReport(pendentOrder);

                foreach (KeyValuePair<Book, int> bookToQuantity in pendentOrder.BooksToQuantity)
                   GenerateStockFault(bookToQuantity.Key, bookToQuantity.Value + replenishmentDefaultValue);

                string pendentOrderReport = pendentOrder.State;
                pendentOrderReport += "\n\n";
                pendentOrderReport = GenerateTableForOrderReport(pendentOrder, pendentOrderReport);
                string clientEmail = pendentOrder.Client.Email;
                string clientName = pendentOrder.Client.Name;
                EmailSender.SendEmail(pendentOrderReport, "Pending Order", clientEmail, clientName);
            }


           printerRestServiceProxy.PrintReceipt(orderString);
       }

       private void GenerateStockFault(Book book, int quantity)
       {
           ReplenishmentRequest replenishmentRequest = new ReplenishmentRequest(book, quantity);
           storeWarehouseMessenger.SendMessage(replenishmentRequest);
       }

       private string GenerateOrderReport(ComplexOrder complexOrder, string orderType)
       {
           string formattedTime = DateTime.Now.ToString(" dd-MM-yyyy hh:mm:ss");
           string orderReport = "\n\n\n" + (orderType + " generated at " + formattedTime + "\n\n").PadLeft(15);

           Client client = complexOrder.Client;
           orderReport += ("Client " + client.Name + "\n\n").PadLeft(25);
           orderReport = GenerateTableForOrderReport(complexOrder, orderReport);

           return orderReport;
       }

       private static string GenerateTableForOrderReport(ComplexOrder complexOrder, string orderReport)
       {
           orderReport += "Book Title".PadRight(20) + "Unit Price".PadRight(15) +
                          "Quantity".PadRight(15) + "Price".PadRight(15) + "\n\n";

           double totalValue = 0.0;
           foreach (KeyValuePair<Book, int> booksToQuantity in complexOrder.BooksToQuantity)
           {
               string bookTitle = booksToQuantity.Key.Title;
               double unitaryPrice = booksToQuantity.Key.Price;
               int quantity = booksToQuantity.Value;
               double price = unitaryPrice * quantity;
               totalValue += price;

               orderReport += bookTitle.PadRight(20) + unitaryPrice.ToString().PadRight(15) +
                              quantity.ToString().PadRight(15) + price.ToString().PadRight(15) + "\n\n";
           }

           orderReport += "\n" + "Total Value".PadRight(20 + 15 + 15) + totalValue;
           return orderReport;
       }

       private string GeneratePendentOrderReport(ComplexOrder pendentOrder)
        {
            return GenerateOrderReport(pendentOrder, "Pendent order report");
        }

       public string GenerateInvoiceString(ComplexOrder solvedOrder)
       {
           return GenerateOrderReport(solvedOrder, "Invoice");
       }

       public void OnOrdersShipment(List<ReplenishmentRequestData> shippedReplenishmentOrders)
       {
           //add to pendent orders to be used as reference on ship arrive on store
           List<ReplenishmentRequest> replenishmentRequests = new List<ReplenishmentRequest>();
           foreach (ReplenishmentRequestData replenishmentRequestData in shippedReplenishmentOrders)
           {
               BookData bookData = replenishmentRequestData.Book;
               Book book = new Book(bookData.Id, bookData.Title, bookData.Price);

               ReplenishmentRequest replenishmentRequest = new ReplenishmentRequest(replenishmentRequestData.Id, book, replenishmentRequestData.Quantity);
               replenishmentRequests.Add(replenishmentRequest);
           }
           _pendentListOfReplenishmentRequestsOrderedByShipmentOrder.Add(replenishmentRequests);

           Dictionary<Book, int> booksToStockIncrement = GetBooksToStockIncrementFromReplenishmentRequests(replenishmentRequests);
           KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>> pendentOrdersSolvedAndRemainingStockIncrementValue =
                   GetPendentOrdersSolvedWithStockIncrementForThisBook(booksToStockIncrement);

           List<ComplexOrder> pendentOrdersSolved = pendentOrdersSolvedAndRemainingStockIncrementValue.Key;
            string pendentOdersReport = "";
            foreach (ComplexOrder pendentOrderSolved in pendentOrdersSolved)
           {
               pendentOrderSolved.State = Order.DispatchWillOccurInTwoDays();

                string pendentOrderReport = pendentOrderSolved.State;
                pendentOrderReport += "\n\n";
                pendentOrderReport = GenerateTableForOrderReport(pendentOrderSolved, pendentOrderReport);
                string clientEmail = pendentOrderSolved.Client.Email;
                string clientName = pendentOrderSolved.Client.Name;
                EmailSender.SendEmail(pendentOrderReport, "Pending Order", clientEmail, clientName);
            }

            _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement.Add(pendentOrdersSolvedAndRemainingStockIncrementValue);
           _pendentOrders.RemoveAll(p => pendentOrdersSolved.Contains(p));
       }

       private Dictionary<Book, int> GetBooksToStockIncrementFromReplenishmentRequests(List<ReplenishmentRequest> shippedReplenishmentOrders)
       {
           Dictionary<Book, int> booksToStockIncrement = new Dictionary<Book, int>();
           foreach (ReplenishmentRequest replenishmentRequest in shippedReplenishmentOrders)
           {
               Book book = replenishmentRequest.Book;
               if (booksToStockIncrement.Any(kvp => kvp.Key == book))
                   booksToStockIncrement[book] += replenishmentRequest.Quantity;
               else
                   booksToStockIncrement[book] = replenishmentRequest.Quantity;
           }

           return booksToStockIncrement;
       }

       public List<List<ReplenishmentRequest>> LoadPendentListOfReplenishmentRequests()
       {
            return _pendentListOfReplenishmentRequestsOrderedByShipmentOrder;
       }

        public List<OrderToDisplay> GetOrders(string userEmail)
        {
            List<OrderToDisplay> orders = new List<OrderToDisplay>();
            foreach (ComplexOrder order in _pendentOrders)
            {
                addOrderToListIfCorrespondsToUserEmail(userEmail, order, orders);
            }
            foreach (ComplexOrder order in _ordersSolved)
            {
                addOrderToListIfCorrespondsToUserEmail(userEmail, order, orders);
            }
            foreach (KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>> pair in _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement)
            {
                List<ComplexOrder> currOrders = pair.Key;
                foreach (ComplexOrder order in currOrders)
                {
                    addOrderToListIfCorrespondsToUserEmail(userEmail, order, orders);
                }
            }
            
            return orders;
        }

        private static void addOrderToListIfCorrespondsToUserEmail(string userEmail, ComplexOrder order, List<OrderToDisplay> orders)
        {
            if (order.Client.Email == userEmail)
            {
                OrderToDisplay orderToDisplay = new OrderToDisplay();
                List<Book> books = order.BooksToQuantity.Keys.ToList();
                List<int> quantities = order.BooksToQuantity.Values.ToList();
                List<BookData> booksData = new List<BookData>();
                double totalPrice = 0.0;
                for (int i = 0; i < books.Count; i++)
                {
                    Book book = books[i];
                    int quantity = quantities[i];
                    BookData bookData = new BookData();
                    bookData.Id = book.Id;
                    bookData.Title = book.Title;
                    bookData.Price = book.Price;
                    booksData.Add(bookData);
                    totalPrice += book.Price * quantity;
                }
                orderToDisplay.books = booksData;
                orderToDisplay.quantity = quantities;
                orderToDisplay.state = order.State;
                orderToDisplay.totalPrice = totalPrice;

                orders.Add(orderToDisplay);
            }
        }
    }
}