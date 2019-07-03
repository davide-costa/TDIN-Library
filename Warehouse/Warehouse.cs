using System.Collections.Generic;
using System.Messaging;
using Common;
using StoreRestService;

namespace Warehouse
{
    public class Warehouse
    {
        private static string informationFileName = "WareHouseDataFile";

        private StoreRestServiceProxy _storeService;
        private List<ReplenishmentRequest> _shippedReplenishmentRequests = new List<ReplenishmentRequest>();
        private static List<ReplenishmentRequest> _replenishmentRequests = new List<ReplenishmentRequest>();
        private static WarehouseGUI _gui;

        const string description = "This is a queue for sending Replenishment Requests between Store and Warehouse.";
        const string path = @".\Private$\ReplenishmentRequestsQueue";


        public Warehouse(StoreRestServiceProxy storeService, WarehouseGUI gui)
        {
            _storeService = storeService;
            _gui = gui;

            loadSystemInformationFromFile();

            StoreWarehouseMessenger storeWarehouseMessenger = new StoreWarehouseMessenger(path, description);
            storeWarehouseMessenger.StartReceiving(OnNewReplenishmentRequest);
        }

        public void loadSystemInformationFromFile()
        {
            WarehouseData restServiceData = (WarehouseData)Utils.LoadObjectToFileAsBinary(informationFileName);
            if(restServiceData == null)
                return;

            _shippedReplenishmentRequests = restServiceData._shippedReplenishmentRequests;
            _replenishmentRequests = restServiceData._replenishmentRequests;
            foreach (ReplenishmentRequest replenishmentRequest in _replenishmentRequests)
                _gui.OnNewReplenishmentRequest(replenishmentRequest);
        }

        public void saveSystemInformationFromFile()
        {
            WarehouseData restServiceData = new WarehouseData();
            restServiceData._shippedReplenishmentRequests = _shippedReplenishmentRequests;
            restServiceData._replenishmentRequests = _replenishmentRequests;
            
            Utils.SaveObjectToFileAsBinary(restServiceData, informationFileName);
        }

        public void OnOrdersShipment(List<int> shippedReplenishmentRequestIds)
        {
            List<ReplenishmentRequestData> shippedReplenishmentRequest = new List<ReplenishmentRequestData>();
            foreach (int orderShippedId in shippedReplenishmentRequestIds)
            {
                ReplenishmentRequest replenishmentRequest =
                    _replenishmentRequests.Find(r => r.Id == orderShippedId);
                _shippedReplenishmentRequests.Add(replenishmentRequest);
                _replenishmentRequests.Remove(replenishmentRequest);


                ReplenishmentRequestData replenishmentRequestData = new ReplenishmentRequestData();
                replenishmentRequestData.Id = replenishmentRequest.Id;
                BookData bookData = new BookData();
                bookData.Id = replenishmentRequest.Book.Id;
                bookData.Price = replenishmentRequest.Book.Price;
                bookData.Title = replenishmentRequest.Book.Title;
                replenishmentRequestData.Book = bookData;
                replenishmentRequestData.Quantity = replenishmentRequest.Quantity;
                shippedReplenishmentRequest.Add(replenishmentRequestData);
            }

            _storeService.OnOrdersShipment(shippedReplenishmentRequest);
        }


        private static void OnNewReplenishmentRequest(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue messageQueue = (MessageQueue)sender;
            Message msg = messageQueue.EndReceive(e.AsyncResult);
            if (msg == null)
                return;

            if (msg.Body != null)
            {
                ReplenishmentRequest replenishmentRequest = (ReplenishmentRequest)msg.Body;
                _replenishmentRequests.Add(replenishmentRequest);
                _gui.OnNewReplenishmentRequestAsync(replenishmentRequest);
            }

            messageQueue.BeginReceive();
        }
    }
}
