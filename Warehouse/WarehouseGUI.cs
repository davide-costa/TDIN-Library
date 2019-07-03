using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;

namespace Warehouse
{
    public partial class WarehouseGUI : Form
    {
        private Warehouse _warehouse;
        delegate ListViewItem ListViewAddItemDelegate(ListViewItem lvItem);

        public WarehouseGUI()
        {
            InitializeComponent();
            this.FormClosing += OnFormClosing;
            this.Text = "Warehouse";
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            _warehouse.saveSystemInformationFromFile();
            Console.WriteLine("warehouse information saved");
        }

        public void SetWarehouse(Warehouse warehouse)
        {
            this._warehouse = warehouse;
        }

        private void SelectReplenishmentRequest(object sender, EventArgs e)
        {
            if (replenishmentRequestsList.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = replenishmentRequestsList.SelectedItems[0];
            selectedReplenishmentRequestsList.Items.Add((ListViewItem) selectedItem.Clone());
            selectedItem.Remove();
        }

        private void RemoveReplenishmentRequest(object sender, EventArgs e)
        {
            if (selectedReplenishmentRequestsList.SelectedItems.Count == 0)
                return;

            ListViewItem selectedItem = selectedReplenishmentRequestsList.SelectedItems[0];
            replenishmentRequestsList.Items.Add((ListViewItem)selectedItem.Clone());
            selectedItem.Remove();
        }

        private void ShipSelectedRequests(object sender, EventArgs e)
        {
            List<int> ordersShipped = new List<int>();
            foreach (ListViewItem selectedReplenishmentRequest in selectedReplenishmentRequestsList.Items)
                ordersShipped.Add(Convert.ToInt32(selectedReplenishmentRequest.SubItems[0].Text));

            _warehouse.OnOrdersShipment(ordersShipped);

            selectedReplenishmentRequestsList.Items.Clear();
        }

        public void OnNewReplenishmentRequestAsync(ReplenishmentRequest replenishmentRequest)
        {
            string[] row = { replenishmentRequest.Id.ToString(), replenishmentRequest.Book.Title, replenishmentRequest.Quantity.ToString() };

            ListViewAddItemDelegate listViewAddItemDelegate = replenishmentRequestsList.Items.Add;
            ListViewItem newReplenishmentRequest = new ListViewItem(row);
            BeginInvoke(listViewAddItemDelegate, newReplenishmentRequest);
        }

        public void OnNewReplenishmentRequest(ReplenishmentRequest replenishmentRequest)
        {
            string[] row = { replenishmentRequest.Id.ToString(), replenishmentRequest.Book.Title, replenishmentRequest.Quantity.ToString() };
            ListViewItem newReplenishmentRequest = new ListViewItem(row);
            replenishmentRequestsList.Items.Add(newReplenishmentRequest);
        }
    }
}
