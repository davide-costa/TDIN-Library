using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;
using StoreRestService;

namespace Store
{
    public partial class ReceiveBookShipmentGUI : Form
    {
        public StoreRestServiceProxy Store { get; }
        public event EventHandler<int> BookShipmentReceived;
        public List<Dictionary<Book, int>> bookToQuantityList;

        public ReceiveBookShipmentGUI(StoreRestServiceProxy store)
        {
            InitializeComponent();
            this.Text = "Receive Book Shipment";
            this.Store = store;

            SetListOfBookShipmentsThatAlreadyWereShipped();
        }

        private void SetListOfBookShipmentsThatAlreadyWereShipped()
        {
            List<List<ReplenishmentRequest>> replenishmentRequestsShipments = Store.LoadPendentListOfReplenishmentRequests();
            bookToQuantityList = GetBookToQuantityForEachReplenishmentRequestList(replenishmentRequestsShipments);

            foreach (Dictionary<Book, int> bookToQuantityDictionary in bookToQuantityList)
            {
                string booksIds = "";
                int totalNumberOfBooks = 0;
                foreach (KeyValuePair<Book, int> bookToQuantityKeyValuePair in bookToQuantityDictionary)
                {
                    booksIds += bookToQuantityKeyValuePair.Key.Id + ", ";
                    totalNumberOfBooks += bookToQuantityKeyValuePair.Value;
                }

                shipmentsListView.Items.Add(new ListViewItem(new string[2] { booksIds, totalNumberOfBooks.ToString() }));
            }
        }

        private List<Dictionary<Book, int>> GetBookToQuantityForEachReplenishmentRequestList(
            List<List<ReplenishmentRequest>> replenishmentRequestsShipments)
        {
            List<Dictionary<Book, int>> bookToQuantity = new List<Dictionary<Book, int>>();
            foreach (List<ReplenishmentRequest> replenishmentRequestsShipment in replenishmentRequestsShipments)
            {
                Dictionary<Book, int> bookToQuantityDictionary = new Dictionary<Book, int>();
                foreach (ReplenishmentRequest replenishmentRequest in replenishmentRequestsShipment)
                {
                    Book book = replenishmentRequest.Book;
                    int quantity = replenishmentRequest.Quantity;

                    if (bookToQuantityDictionary.Any(kvp => kvp.Key == book))
                        bookToQuantityDictionary[book] += quantity;
                    else
                        bookToQuantityDictionary[book] = quantity;
                }

                bookToQuantity.Add(bookToQuantityDictionary);
            }

            return bookToQuantity;
        }

        private void MarkShipmentAsReceived(object sender, EventArgs e)
        {
            if (shipmentsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = shipmentsListView.SelectedItems[0];
            int shipmentIndex = shipmentsListView.Items.IndexOf(selectedItem);
            try
            {
                Store.ReceiveReplenishmentRequestDelivery(shipmentIndex.ToString());
            }
            catch
            {
                MessageBox.Show("Error receiving replenishment request", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //clear shipment from list
            selectedItem.Remove();
            shipmentDetailsView.Items.Clear();

            //update Store UI with new quantities
            if (BookShipmentReceived != null)
                BookShipmentReceived(this, 0);
        }


        private void ShowSelectedShipmentDetails(object sender, EventArgs e)
        {
            //clear old shipment details
            shipmentDetailsView.Items.Clear();


            //insert new shipment details
            ListViewItem selectedItem = shipmentsListView.SelectedItems[0];
            int shipmentIndex = shipmentsListView.Items.IndexOf(selectedItem);

            Dictionary<Book, int> selectShipmentBooksAndQuantities = bookToQuantityList[shipmentIndex];
            foreach (KeyValuePair<Book, int> bookToQuantity in selectShipmentBooksAndQuantities)
            {
                Book book = bookToQuantity.Key;
                int quantity = bookToQuantity.Value;

                shipmentDetailsView.Items.Add(new ListViewItem(new string[3] { book.Id.ToString(), book.Title, quantity.ToString() }));
            }
        }
    }
}
