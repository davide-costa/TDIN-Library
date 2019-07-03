using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace AddNewClient
{
    public partial class AddNewClientGUI : Form
    {
        public event EventHandler<Client> NewClientAddedEvent; 

        public AddNewClientGUI()
        {
            InitializeComponent();
            this.Text = "Add New Client";
        }

        private void AddNewClient(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;
            if (name.Length == 0 || email.Length == 0 || address.Length == 0)
            {
                MessageBox.Show("Name, Email and Address must be filled", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
              
            Client client = new Client(name, email, address);
            if (NewClientAddedEvent != null)
                NewClientAddedEvent(this, client);

            this.Close();
        }
    }
}
