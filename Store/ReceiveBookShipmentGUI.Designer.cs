namespace Store
{
    partial class ReceiveBookShipmentGUI
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
            this.labelShipmentsList = new System.Windows.Forms.Label();
            this.shipmentsListView = new System.Windows.Forms.ListView();
            this.columnHeaderBooksIds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTotalNumberBooks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shipmentDetailsView = new System.Windows.Forms.ListView();
            this.columnHeaderBookId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBookTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBookQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelShipmentDetails = new System.Windows.Forms.Label();
            this.buttonMarkShipmentAsReceived = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelShipmentsList
            // 
            this.labelShipmentsList.AutoSize = true;
            this.labelShipmentsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShipmentsList.Location = new System.Drawing.Point(137, 25);
            this.labelShipmentsList.Name = "labelShipmentsList";
            this.labelShipmentsList.Size = new System.Drawing.Size(153, 25);
            this.labelShipmentsList.TabIndex = 29;
            this.labelShipmentsList.Text = "Shipments List";
            // 
            // shipmentsListView
            // 
            this.shipmentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderBooksIds,
            this.columnHeaderTotalNumberBooks});
            this.shipmentsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shipmentsListView.FullRowSelect = true;
            this.shipmentsListView.Location = new System.Drawing.Point(12, 70);
            this.shipmentsListView.MultiSelect = false;
            this.shipmentsListView.Name = "shipmentsListView";
            this.shipmentsListView.Size = new System.Drawing.Size(375, 419);
            this.shipmentsListView.TabIndex = 30;
            this.shipmentsListView.UseCompatibleStateImageBehavior = false;
            this.shipmentsListView.View = System.Windows.Forms.View.Details;
            this.shipmentsListView.Click += new System.EventHandler(this.ShowSelectedShipmentDetails);
            // 
            // columnHeaderBooksIds
            // 
            this.columnHeaderBooksIds.Text = "Books Ids";
            this.columnHeaderBooksIds.Width = 245;
            // 
            // columnHeaderTotalNumberBooks
            // 
            this.columnHeaderTotalNumberBooks.Text = "Total Number Books";
            this.columnHeaderTotalNumberBooks.Width = 125;
            // 
            // shipmentDetailsView
            // 
            this.shipmentDetailsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderBookId,
            this.columnHeaderBookTitle,
            this.columnHeaderBookQuantity});
            this.shipmentDetailsView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shipmentDetailsView.FullRowSelect = true;
            this.shipmentDetailsView.Location = new System.Drawing.Point(453, 70);
            this.shipmentDetailsView.MultiSelect = false;
            this.shipmentDetailsView.Name = "shipmentDetailsView";
            this.shipmentDetailsView.Size = new System.Drawing.Size(375, 419);
            this.shipmentDetailsView.TabIndex = 31;
            this.shipmentDetailsView.UseCompatibleStateImageBehavior = false;
            this.shipmentDetailsView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderBookId
            // 
            this.columnHeaderBookId.Text = "Id";
            this.columnHeaderBookId.Width = 43;
            // 
            // columnHeaderBookTitle
            // 
            this.columnHeaderBookTitle.Text = "Book Title";
            this.columnHeaderBookTitle.Width = 259;
            // 
            // columnHeaderBookQuantity
            // 
            this.columnHeaderBookQuantity.Text = "Quantity";
            this.columnHeaderBookQuantity.Width = 68;
            // 
            // labelShipmentDetails
            // 
            this.labelShipmentDetails.AutoSize = true;
            this.labelShipmentDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShipmentDetails.Location = new System.Drawing.Point(574, 25);
            this.labelShipmentDetails.Name = "labelShipmentDetails";
            this.labelShipmentDetails.Size = new System.Drawing.Size(174, 25);
            this.labelShipmentDetails.TabIndex = 32;
            this.labelShipmentDetails.Text = "Shipment Details";
            // 
            // buttonMarkShipmentAsReceived
            // 
            this.buttonMarkShipmentAsReceived.Location = new System.Drawing.Point(80, 504);
            this.buttonMarkShipmentAsReceived.Name = "buttonMarkShipmentAsReceived";
            this.buttonMarkShipmentAsReceived.Size = new System.Drawing.Size(226, 28);
            this.buttonMarkShipmentAsReceived.TabIndex = 33;
            this.buttonMarkShipmentAsReceived.Text = "Mark Shipment As Received";
            this.buttonMarkShipmentAsReceived.UseVisualStyleBackColor = true;
            this.buttonMarkShipmentAsReceived.Click += new System.EventHandler(this.MarkShipmentAsReceived);
            // 
            // ReceiveBookShipmentGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 564);
            this.Controls.Add(this.buttonMarkShipmentAsReceived);
            this.Controls.Add(this.labelShipmentDetails);
            this.Controls.Add(this.shipmentDetailsView);
            this.Controls.Add(this.shipmentsListView);
            this.Controls.Add(this.labelShipmentsList);
            this.Name = "ReceiveBookShipmentGUI";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelShipmentsList;
        private System.Windows.Forms.ListView shipmentsListView;
        private System.Windows.Forms.ColumnHeader columnHeaderBooksIds;
        private System.Windows.Forms.ColumnHeader columnHeaderTotalNumberBooks;
        private System.Windows.Forms.ListView shipmentDetailsView;
        private System.Windows.Forms.ColumnHeader columnHeaderBookId;
        private System.Windows.Forms.ColumnHeader columnHeaderBookTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderBookQuantity;
        private System.Windows.Forms.Label labelShipmentDetails;
        private System.Windows.Forms.Button buttonMarkShipmentAsReceived;
    }
}

