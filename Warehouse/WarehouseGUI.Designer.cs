namespace Warehouse
{
    partial class WarehouseGUI
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
            this.SelectReplenishmentRequestButton = new System.Windows.Forms.Button();
            this.labelReplenishmentRequests = new System.Windows.Forms.Label();
            this.ReemoveReplenishmentRequest = new System.Windows.Forms.Button();
            this.labelSelectedReplenishmentRequests = new System.Windows.Forms.Label();
            this.buttonShipSeelectedRequests = new System.Windows.Forms.Button();
            this.selectedReplenishmentRequestsList = new System.Windows.Forms.ListView();
            this.columnHeaderIdSRR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBookTitleSRR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQuantitySRR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.replenishmentRequestsList = new System.Windows.Forms.ListView();
            this.columnHeaderIdRR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBookTitleRR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQuantityRR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 50;
            // 
            // SelectReplenishmentRequestButton
            // 
            this.SelectReplenishmentRequestButton.Location = new System.Drawing.Point(61, 519);
            this.SelectReplenishmentRequestButton.Name = "SelectReplenishmentRequestButton";
            this.SelectReplenishmentRequestButton.Size = new System.Drawing.Size(178, 35);
            this.SelectReplenishmentRequestButton.TabIndex = 1;
            this.SelectReplenishmentRequestButton.Text = "Select Replenishment Request";
            this.SelectReplenishmentRequestButton.UseVisualStyleBackColor = true;
            this.SelectReplenishmentRequestButton.Click += new System.EventHandler(this.SelectReplenishmentRequest);
            // 
            // labelReplenishmentRequests
            // 
            this.labelReplenishmentRequests.AutoSize = true;
            this.labelReplenishmentRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReplenishmentRequests.Location = new System.Drawing.Point(110, 23);
            this.labelReplenishmentRequests.Name = "labelReplenishmentRequests";
            this.labelReplenishmentRequests.Size = new System.Drawing.Size(252, 25);
            this.labelReplenishmentRequests.TabIndex = 3;
            this.labelReplenishmentRequests.Text = "Replenishment Requests";
            // 
            // ReemoveReplenishmentRequest
            // 
            this.ReemoveReplenishmentRequest.Location = new System.Drawing.Point(544, 517);
            this.ReemoveReplenishmentRequest.Name = "ReemoveReplenishmentRequest";
            this.ReemoveReplenishmentRequest.Size = new System.Drawing.Size(193, 35);
            this.ReemoveReplenishmentRequest.TabIndex = 4;
            this.ReemoveReplenishmentRequest.Text = "Remove Replenishment Request";
            this.ReemoveReplenishmentRequest.UseVisualStyleBackColor = true;
            this.ReemoveReplenishmentRequest.Click += new System.EventHandler(this.RemoveReplenishmentRequest);
            // 
            // labelSelectedReplenishmentRequests
            // 
            this.labelSelectedReplenishmentRequests.AutoSize = true;
            this.labelSelectedReplenishmentRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedReplenishmentRequests.Location = new System.Drawing.Point(549, 23);
            this.labelSelectedReplenishmentRequests.Name = "labelSelectedReplenishmentRequests";
            this.labelSelectedReplenishmentRequests.Size = new System.Drawing.Size(342, 25);
            this.labelSelectedReplenishmentRequests.TabIndex = 5;
            this.labelSelectedReplenishmentRequests.Text = "Selected Replenishment Requests";
            // 
            // buttonShipSeelectedRequests
            // 
            this.buttonShipSeelectedRequests.Location = new System.Drawing.Point(677, 579);
            this.buttonShipSeelectedRequests.Name = "buttonShipSeelectedRequests";
            this.buttonShipSeelectedRequests.Size = new System.Drawing.Size(144, 35);
            this.buttonShipSeelectedRequests.TabIndex = 10;
            this.buttonShipSeelectedRequests.Text = "Ship Selected Requests";
            this.buttonShipSeelectedRequests.UseVisualStyleBackColor = true;
            this.buttonShipSeelectedRequests.Click += new System.EventHandler(this.ShipSelectedRequests);
            // 
            // selectedReplenishmentRequestsList
            // 
            this.selectedReplenishmentRequestsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIdSRR,
            this.columnHeaderBookTitleSRR,
            this.columnHeaderQuantitySRR});
            this.selectedReplenishmentRequestsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedReplenishmentRequestsList.FullRowSelect = true;
            this.selectedReplenishmentRequestsList.Location = new System.Drawing.Point(534, 68);
            this.selectedReplenishmentRequestsList.MultiSelect = false;
            this.selectedReplenishmentRequestsList.Name = "selectedReplenishmentRequestsList";
            this.selectedReplenishmentRequestsList.Size = new System.Drawing.Size(375, 443);
            this.selectedReplenishmentRequestsList.TabIndex = 20;
            this.selectedReplenishmentRequestsList.UseCompatibleStateImageBehavior = false;
            this.selectedReplenishmentRequestsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderIdSRR
            // 
            this.columnHeaderIdSRR.Text = "Id";
            this.columnHeaderIdSRR.Width = 43;
            // 
            // columnHeaderBookTitleSRR
            // 
            this.columnHeaderBookTitleSRR.Text = "Book Title";
            this.columnHeaderBookTitleSRR.Width = 247;
            // 
            // columnHeaderQuantitySRR
            // 
            this.columnHeaderQuantitySRR.Text = "Quantity";
            this.columnHeaderQuantitySRR.Width = 80;
            // 
            // replenishmentRequestsList
            // 
            this.replenishmentRequestsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIdRR,
            this.columnHeaderBookTitleRR,
            this.columnHeaderQuantityRR});
            this.replenishmentRequestsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replenishmentRequestsList.FullRowSelect = true;
            this.replenishmentRequestsList.Location = new System.Drawing.Point(49, 68);
            this.replenishmentRequestsList.MultiSelect = false;
            this.replenishmentRequestsList.Name = "replenishmentRequestsList";
            this.replenishmentRequestsList.Size = new System.Drawing.Size(375, 445);
            this.replenishmentRequestsList.TabIndex = 21;
            this.replenishmentRequestsList.UseCompatibleStateImageBehavior = false;
            this.replenishmentRequestsList.View = System.Windows.Forms.View.Details;
            this.replenishmentRequestsList.DoubleClick += new System.EventHandler(this.SelectReplenishmentRequest);
            // 
            // columnHeaderIdRR
            // 
            this.columnHeaderIdRR.Text = "Id";
            this.columnHeaderIdRR.Width = 43;
            // 
            // columnHeaderBookTitleRR
            // 
            this.columnHeaderBookTitleRR.Text = "Book Title";
            this.columnHeaderBookTitleRR.Width = 245;
            // 
            // columnHeaderQuantityRR
            // 
            this.columnHeaderQuantityRR.Text = "Quantity";
            this.columnHeaderQuantityRR.Width = 82;
            // 
            // WarehouseGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 656);
            this.Controls.Add(this.replenishmentRequestsList);
            this.Controls.Add(this.selectedReplenishmentRequestsList);
            this.Controls.Add(this.buttonShipSeelectedRequests);
            this.Controls.Add(this.labelSelectedReplenishmentRequests);
            this.Controls.Add(this.ReemoveReplenishmentRequest);
            this.Controls.Add(this.labelReplenishmentRequests);
            this.Controls.Add(this.SelectReplenishmentRequestButton);
            this.Name = "WarehouseGUI";
            this.Text = "ListProducts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.Button SelectReplenishmentRequestButton;
        private System.Windows.Forms.Label labelReplenishmentRequests;
        private System.Windows.Forms.Button ReemoveReplenishmentRequest;
        private System.Windows.Forms.Label labelSelectedReplenishmentRequests;
        private System.Windows.Forms.Button buttonShipSeelectedRequests;
        private System.Windows.Forms.ListView selectedReplenishmentRequestsList;
        private System.Windows.Forms.ColumnHeader columnHeaderIdSRR;
        private System.Windows.Forms.ColumnHeader columnHeaderBookTitleSRR;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantitySRR;
        private System.Windows.Forms.ListView replenishmentRequestsList;
        private System.Windows.Forms.ColumnHeader columnHeaderIdRR;
        private System.Windows.Forms.ColumnHeader columnHeaderBookTitleRR;
        private System.Windows.Forms.ColumnHeader columnHeaderQuantityRR;
    }
}