namespace Store
{
    partial class StoreGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectBookButton = new System.Windows.Forms.Button();
            this.labelBooksList = new System.Windows.Forms.Label();
            this.removeProductFromOrderButton = new System.Windows.Forms.Button();
            this.labelSelectedBooks = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.buttonSubmitOrder = new System.Windows.Forms.Button();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.labelClientsList = new System.Windows.Forms.Label();
            this.clientsListView = new System.Windows.Forms.ListView();
            this.columnHeaderClientIdCL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNameCL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAddressCL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmailCL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelClient = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.buttonSelectClient = new System.Windows.Forms.Button();
            this.buttonAddNewClient = new System.Windows.Forms.Button();
            this.selectedBooksListView = new System.Windows.Forms.ListView();
            this.columnHeaderIdSB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBookTitleSB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPriceSB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQuantitySB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.booksListView = new System.Windows.Forms.ListView();
            this.columnHeaderIdBL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBookTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPriceBL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAvailabilityBL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxClientSelectedId = new System.Windows.Forms.TextBox();
            this.buttonDeleteClient = new System.Windows.Forms.Button();
            this.buttonReceiveBookShipment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 50;
            // 
            // selectBookButton
            // 
            this.selectBookButton.Location = new System.Drawing.Point(241, 711);
            this.selectBookButton.Name = "selectBookButton";
            this.selectBookButton.Size = new System.Drawing.Size(120, 35);
            this.selectBookButton.TabIndex = 1;
            this.selectBookButton.Text = "Select Book";
            this.selectBookButton.UseVisualStyleBackColor = true;
            this.selectBookButton.Click += new System.EventHandler(this.SelectBook);
            // 
            // labelBooksList
            // 
            this.labelBooksList.AutoSize = true;
            this.labelBooksList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBooksList.Location = new System.Drawing.Point(136, 23);
            this.labelBooksList.Name = "labelBooksList";
            this.labelBooksList.Size = new System.Drawing.Size(217, 25);
            this.labelBooksList.TabIndex = 3;
            this.labelBooksList.Text = "BooksToQuantity List";
            // 
            // removeProductFromOrderButton
            // 
            this.removeProductFromOrderButton.Location = new System.Drawing.Point(466, 519);
            this.removeProductFromOrderButton.Name = "removeProductFromOrderButton";
            this.removeProductFromOrderButton.Size = new System.Drawing.Size(95, 35);
            this.removeProductFromOrderButton.TabIndex = 4;
            this.removeProductFromOrderButton.Text = "Remove";
            this.removeProductFromOrderButton.UseVisualStyleBackColor = true;
            this.removeProductFromOrderButton.Click += new System.EventHandler(this.DeselectBook);
            // 
            // labelSelectedBooks
            // 
            this.labelSelectedBooks.AutoSize = true;
            this.labelSelectedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedBooks.Location = new System.Drawing.Point(555, 23);
            this.labelSelectedBooks.Name = "labelSelectedBooks";
            this.labelSelectedBooks.Size = new System.Drawing.Size(267, 25);
            this.labelSelectedBooks.TabIndex = 5;
            this.labelSelectedBooks.Text = "Selected BooksToQuantity";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(186, 640);
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantity.TabIndex = 6;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantity.Location = new System.Drawing.Point(77, 640);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(68, 20);
            this.labelQuantity.TabIndex = 7;
            this.labelQuantity.Text = "Quantity";
            // 
            // buttonSubmitOrder
            // 
            this.buttonSubmitOrder.Location = new System.Drawing.Point(608, 711);
            this.buttonSubmitOrder.Name = "buttonSubmitOrder";
            this.buttonSubmitOrder.Size = new System.Drawing.Size(95, 35);
            this.buttonSubmitOrder.TabIndex = 10;
            this.buttonSubmitOrder.Text = "Submit Order";
            this.buttonSubmitOrder.UseVisualStyleBackColor = true;
            this.buttonSubmitOrder.Click += new System.EventHandler(this.SubmitOrder);
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(513, 611);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(83, 20);
            this.labelTotalPrice.TabIndex = 12;
            this.labelTotalPrice.Text = "Total Price";
            // 
            // labelClientsList
            // 
            this.labelClientsList.AutoSize = true;
            this.labelClientsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientsList.Location = new System.Drawing.Point(1016, 23);
            this.labelClientsList.Name = "labelClientsList";
            this.labelClientsList.Size = new System.Drawing.Size(118, 25);
            this.labelClientsList.TabIndex = 13;
            this.labelClientsList.Text = "Clients List";
            // 
            // clientsListView
            // 
            this.clientsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderClientIdCL,
            this.columnHeaderNameCL,
            this.columnHeaderAddressCL,
            this.columnHeaderEmailCL});
            this.clientsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientsListView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.clientsListView.FullRowSelect = true;
            this.clientsListView.LabelWrap = false;
            this.clientsListView.Location = new System.Drawing.Point(878, 68);
            this.clientsListView.MultiSelect = false;
            this.clientsListView.Name = "clientsListView";
            this.clientsListView.Size = new System.Drawing.Size(375, 535);
            this.clientsListView.TabIndex = 14;
            this.clientsListView.UseCompatibleStateImageBehavior = false;
            this.clientsListView.View = System.Windows.Forms.View.Details;
            this.clientsListView.DoubleClick += new System.EventHandler(this.SelectClient);
            // 
            // columnHeaderClientIdCL
            // 
            this.columnHeaderClientIdCL.Text = "Id";
            this.columnHeaderClientIdCL.Width = 32;
            // 
            // columnHeaderNameCL
            // 
            this.columnHeaderNameCL.Text = "Name";
            this.columnHeaderNameCL.Width = 146;
            // 
            // columnHeaderAddressCL
            // 
            this.columnHeaderAddressCL.Text = "Address";
            this.columnHeaderAddressCL.Width = 74;
            // 
            // columnHeaderEmailCL
            // 
            this.columnHeaderEmailCL.Text = "Email";
            this.columnHeaderEmailCL.Width = 119;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClient.Location = new System.Drawing.Point(513, 654);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(49, 20);
            this.labelClient.TabIndex = 16;
            this.labelClient.Text = "Client";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(622, 611);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalPrice.TabIndex = 17;
            // 
            // buttonSelectClient
            // 
            this.buttonSelectClient.Location = new System.Drawing.Point(895, 609);
            this.buttonSelectClient.Name = "buttonSelectClient";
            this.buttonSelectClient.Size = new System.Drawing.Size(95, 35);
            this.buttonSelectClient.TabIndex = 18;
            this.buttonSelectClient.Text = "Select Client";
            this.buttonSelectClient.UseVisualStyleBackColor = true;
            this.buttonSelectClient.Click += new System.EventHandler(this.SelectClient);
            // 
            // buttonAddNewClient
            // 
            this.buttonAddNewClient.Location = new System.Drawing.Point(1027, 711);
            this.buttonAddNewClient.Name = "buttonAddNewClient";
            this.buttonAddNewClient.Size = new System.Drawing.Size(107, 35);
            this.buttonAddNewClient.TabIndex = 19;
            this.buttonAddNewClient.Text = "Add New Client";
            this.buttonAddNewClient.UseVisualStyleBackColor = true;
            this.buttonAddNewClient.Click += new System.EventHandler(this.AddNewClient);
            // 
            // selectedBooksListView
            // 
            this.selectedBooksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIdSB,
            this.columnHeaderBookTitleSB,
            this.columnHeaderPriceSB,
            this.columnHeaderQuantitySB});
            this.selectedBooksListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedBooksListView.FullRowSelect = true;
            this.selectedBooksListView.Location = new System.Drawing.Point(466, 70);
            this.selectedBooksListView.MultiSelect = false;
            this.selectedBooksListView.Name = "selectedBooksListView";
            this.selectedBooksListView.Size = new System.Drawing.Size(375, 443);
            this.selectedBooksListView.TabIndex = 20;
            this.selectedBooksListView.UseCompatibleStateImageBehavior = false;
            this.selectedBooksListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderIdSB
            // 
            this.columnHeaderIdSB.Text = "Id";
            this.columnHeaderIdSB.Width = 43;
            // 
            // columnHeaderBookTitleSB
            // 
            this.columnHeaderBookTitleSB.Text = "Book Title";
            this.columnHeaderBookTitleSB.Width = 205;
            // 
            // columnHeaderPriceSB
            // 
            this.columnHeaderPriceSB.Text = "Price";
            this.columnHeaderPriceSB.Width = 55;
            // 
            // columnHeaderQuantitySB
            // 
            this.columnHeaderQuantitySB.Text = "Quantity";
            this.columnHeaderQuantitySB.Width = 68;
            // 
            // booksListView
            // 
            this.booksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIdBL,
            this.columnHeaderBookTitle,
            this.columnHeaderPriceBL,
            this.columnHeaderAvailabilityBL});
            this.booksListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booksListView.FullRowSelect = true;
            this.booksListView.Location = new System.Drawing.Point(27, 68);
            this.booksListView.MultiSelect = false;
            this.booksListView.Name = "booksListView";
            this.booksListView.Size = new System.Drawing.Size(375, 535);
            this.booksListView.TabIndex = 21;
            this.booksListView.UseCompatibleStateImageBehavior = false;
            this.booksListView.View = System.Windows.Forms.View.Details;
            this.booksListView.DoubleClick += new System.EventHandler(this.SelectBook);
            // 
            // columnHeaderIdBL
            // 
            this.columnHeaderIdBL.Text = "Id";
            this.columnHeaderIdBL.Width = 43;
            // 
            // columnHeaderBookTitle
            // 
            this.columnHeaderBookTitle.Text = "Book Title";
            this.columnHeaderBookTitle.Width = 205;
            // 
            // columnHeaderPriceBL
            // 
            this.columnHeaderPriceBL.Text = "Price";
            this.columnHeaderPriceBL.Width = 55;
            // 
            // columnHeaderAvailabilityBL
            // 
            this.columnHeaderAvailabilityBL.Text = "Availability";
            this.columnHeaderAvailabilityBL.Width = 68;
            // 
            // textBoxClientSelectedId
            // 
            this.textBoxClientSelectedId.Location = new System.Drawing.Point(622, 653);
            this.textBoxClientSelectedId.Name = "textBoxClientSelectedId";
            this.textBoxClientSelectedId.Size = new System.Drawing.Size(100, 20);
            this.textBoxClientSelectedId.TabIndex = 22;
            // 
            // buttonDeleteClient
            // 
            this.buttonDeleteClient.Location = new System.Drawing.Point(1137, 611);
            this.buttonDeleteClient.Name = "buttonDeleteClient";
            this.buttonDeleteClient.Size = new System.Drawing.Size(95, 35);
            this.buttonDeleteClient.TabIndex = 23;
            this.buttonDeleteClient.Text = "Delete Client";
            this.buttonDeleteClient.UseVisualStyleBackColor = true;
            this.buttonDeleteClient.Click += new System.EventHandler(this.DeleteClient);
            // 
            // buttonReceiveBookShipment
            // 
            this.buttonReceiveBookShipment.Location = new System.Drawing.Point(45, 711);
            this.buttonReceiveBookShipment.Name = "buttonReceiveBookShipment";
            this.buttonReceiveBookShipment.Size = new System.Drawing.Size(140, 35);
            this.buttonReceiveBookShipment.TabIndex = 24;
            this.buttonReceiveBookShipment.Text = "Receive Book Shipment";
            this.buttonReceiveBookShipment.UseVisualStyleBackColor = true;
            this.buttonReceiveBookShipment.Click += new System.EventHandler(this.ReceiveBookShipment);
            // 
            // StoreGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 804);
            this.Controls.Add(this.buttonReceiveBookShipment);
            this.Controls.Add(this.buttonDeleteClient);
            this.Controls.Add(this.textBoxClientSelectedId);
            this.Controls.Add(this.booksListView);
            this.Controls.Add(this.selectedBooksListView);
            this.Controls.Add(this.buttonAddNewClient);
            this.Controls.Add(this.buttonSelectClient);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.clientsListView);
            this.Controls.Add(this.labelClientsList);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.buttonSubmitOrder);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.labelSelectedBooks);
            this.Controls.Add(this.removeProductFromOrderButton);
            this.Controls.Add(this.labelBooksList);
            this.Controls.Add(this.selectBookButton);
            this.Name = "StoreGUI";
            this.Text = "ListProducts";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.Button selectBookButton;
        private System.Windows.Forms.Label labelBooksList;
        private System.Windows.Forms.Button removeProductFromOrderButton;
        private System.Windows.Forms.Label labelSelectedBooks;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Button buttonSubmitOrder;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label labelClientsList;
        private System.Windows.Forms.ListView clientsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderNameCL;
        private System.Windows.Forms.ColumnHeader columnHeaderAddressCL;
        private System.Windows.Forms.ColumnHeader columnHeaderEmailCL;
        private System.Windows.Forms.ColumnHeader columnHeaderClientIdCL;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Button buttonSelectClient;
        private System.Windows.Forms.Button buttonAddNewClient;
        private System.Windows.Forms.ListView selectedBooksListView;
        private System.Windows.Forms.ColumnHeader columnHeaderIdSB;
        private System.Windows.Forms.ColumnHeader columnHeaderBookTitleSB;
        private System.Windows.Forms.ColumnHeader columnHeaderPriceSB;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantitySB;
        private System.Windows.Forms.ListView booksListView;
        private System.Windows.Forms.ColumnHeader columnHeaderIdBL;
        private System.Windows.Forms.ColumnHeader columnHeaderBookTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderPriceBL;
        private System.Windows.Forms.ColumnHeader columnHeaderAvailabilityBL;
        private System.Windows.Forms.TextBox textBoxClientSelectedId;
        private System.Windows.Forms.Button buttonDeleteClient;
        private System.Windows.Forms.Button buttonReceiveBookShipment;
    }
}