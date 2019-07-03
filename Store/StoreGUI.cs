using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using StoreRestService;

namespace Store
{
    public partial class StoreGUI : Form
    {
        private StoreRestServiceProxy _store;
        delegate ListViewItem ListViewAddItemDelegate(ListViewItem lvItem);


        public StoreGUI(StoreRestServiceProxy store)
        {
            this._store = store;
            InitializeComponent();
            this.FormClosing += OnFormClosing;
            this.Text = "Store";

            LoadStoreBooks();
            LoadStoreClients();
        }

        private void LoadStoreClients()
        {
            List<Client> storeClients = _store.GetClients();
            foreach (Client client in storeClients)
                AddNewClientUpdateUI(client);
        }

        private void LoadStoreBooks()
        {
            BooksAndAvailability booksToAvailability = _store.GetBooksListAndAvailability();
            List<BookData> books = booksToAvailability.books;
            List<int> availabilities = booksToAvailability.availabilities;
            for (int i = 0; i < books.Count; i++)
            {
                BookData bookData = books[i];
                int availability = availabilities[i];
                string[] newRow = {bookData.Id.ToString(), bookData.Title, bookData.Price.ToString(), availability.ToString()};
                booksListView.Items.Add(new ListViewItem(newRow));
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            _store.CloseService();
            Console.WriteLine("store information saved");
        }

        private void SelectBook(object sender, EventArgs e)
        {
            if (booksListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = booksListView.SelectedItems[0];
            int selectedQuantity = Convert.ToInt32(numericUpDownQuantity.Text);
            string[] row = { selectedItem.SubItems[0].Text, selectedItem.SubItems[1].Text,
                selectedItem.SubItems[2].Text, selectedQuantity.ToString()};
            selectedBooksListView.Items.Add(new ListViewItem(row));

            //decrement bookId availability
            int newAvailability = Convert.ToInt32(selectedItem.SubItems[3].Text) - selectedQuantity;
            selectedItem.SubItems[3].Text = newAvailability.ToString();

            UpdateTotalPrice();
            ClearQuantity();
        }

        private void UpdateTotalPrice()
        {
            double totalPrice = 0.0;
            ListView.ListViewItemCollection listViewItems = selectedBooksListView.Items;
            foreach (ListViewItem listViewItem in listViewItems)
                totalPrice += double.Parse(listViewItem.SubItems[2].Text);

            textBoxTotalPrice.Text = totalPrice.ToString();
        }

        private void ClearQuantity()
        {
            numericUpDownQuantity.Value = 1;
        }

        private void DeselectBook(object sender, EventArgs e)
        {
            if (selectedBooksListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = selectedBooksListView.SelectedItems[0];
            int selectedBookId = Convert.ToInt32(selectedItem.SubItems[0].Text);
            int selectedBookQuantity = Convert.ToInt32(selectedItem.SubItems[3].Text);
            ListViewItem foundItem = SearchBookIdOnBooksList(selectedBookId);

            //increment bookId availability
            int newAvailability = Convert.ToInt32(foundItem.SubItems[3].Text) + selectedBookQuantity;
            foundItem.SubItems[3].Text = newAvailability.ToString();

            selectedItem.Remove();

            UpdateTotalPrice();
        }

        private ListViewItem SearchBookIdOnBooksList(int selectedBookId)
        {
            foreach (ListViewItem viewItem in booksListView.Items)
            {
                int selectedViewItemId = Convert.ToInt32(viewItem.SubItems[0].Text);
                if (selectedViewItemId == selectedBookId)
                    return viewItem;
            }

            return null;
        }


        private void CreateOrIncrementEntryInDictionary(Dictionary<int, int> dictionary, int bookId, int value)
        {
            if (dictionary.ContainsKey(bookId))
                dictionary[bookId] += value;
            else
                dictionary[bookId] = value;
        }

        private void SubmitOrder(object sender, EventArgs e)
        {
            if(selectedBooksListView.Items.Count == 0 || textBoxClientSelectedId.Text.Length == 0)
                return;

            Dictionary<int, int> bookIdToQuantity = new Dictionary<int, int>();
            foreach (ListViewItem listViewItem in selectedBooksListView.Items)
            {
                int bookId = Convert.ToInt32(listViewItem.SubItems[0].Text);
                int quantity = Convert.ToInt32(listViewItem.SubItems[3].Text);
                CreateOrIncrementEntryInDictionary(bookIdToQuantity,bookId, quantity);    
            }

            int clientId = Convert.ToInt32(textBoxClientSelectedId.Text);

            try
            {
                BasicOrderData basicOrderData = new BasicOrderData();
                basicOrderData.BooksIds = new List<int>(bookIdToQuantity.Keys);
                basicOrderData.BooksQuantity = new List<int>(bookIdToQuantity.Values);
                _store.RegisterOrdersListByClientId(clientId.ToString(), basicOrderData);
            }
            catch
            {
                MessageBox.Show("Internal error has occurred", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            //clear resources used on new order creation
            selectedBooksListView.Items.Clear();
            textBoxTotalPrice.Text = "";
            textBoxClientSelectedId.Text = "";
        }

        public void HandleNewClientAddedEvent(object sender, Client client)
        {
            //save new client data on server 
            try
            {
                _store.AddNewClient(client.Name, client.Address, client.Email);
            }
            catch
            {
                MessageBox.Show("Error adding client. Please Try again", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            //update UI
            AddNewClientUpdateUIAsync(client);
        }

        private void AddNewClientUpdateUIAsync(Client client)
        {
            string[] row = {client.Id.ToString(), client.Name, client.Address, client.Email};
            ListViewAddItemDelegate listViewAddItemDelegate = clientsListView.Items.Add;
            ListViewItem newClientViewItem = new ListViewItem(row);
            BeginInvoke(listViewAddItemDelegate, newClientViewItem);
        }

        private void AddNewClientUpdateUI(Client client)
        {
            string[] row = { client.Id.ToString(), client.Name, client.Address, client.Email };
            ListViewItem newClientViewItem = new ListViewItem(row);
            clientsListView.Items.Add(newClientViewItem);
        }

        private void SelectClient(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedClient = clientsListView.SelectedItems[0];
            textBoxClientSelectedId.Text = selectedClient.SubItems[0].Text;
        }

        private void AddNewClient(object sender, EventArgs e)
        {
            AddNewClient.AddNewClientGUI addNewClientGui = new AddNewClient.AddNewClientGUI();
            addNewClientGui.NewClientAddedEvent += HandleNewClientAddedEvent;
            addNewClientGui.Show();
        }

        private void DeleteClient(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0)
                return;

            ListViewItem selectedClient = clientsListView.SelectedItems[0];
            int clientToRemoveId = Convert.ToInt32(selectedClient.SubItems[0].Text);

            _store.RemoveClient(clientToRemoveId.ToString());
            selectedClient.Remove();
        }

        private void ReceiveBookShipment(object sender, EventArgs e)
        {
            ReceiveBookShipmentGUI receiveBookShipmentGui = new ReceiveBookShipmentGUI(_store);
            receiveBookShipmentGui.BookShipmentReceived += HandleBookShipmentReceived;
            receiveBookShipmentGui.Show();
        }

        private void HandleBookShipmentReceived(object sender, int e)
        {
            booksListView.Items.Clear();
            LoadStoreBooks();
        }
    }
}
