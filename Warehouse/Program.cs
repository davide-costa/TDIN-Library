using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using StoreRestService;
using Message = System.Messaging.Message;

namespace Warehouse
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WarehouseGUI gui = new WarehouseGUI();
            RemotingConfiguration.Configure("Warehouse.exe.config", false);
            StoreRestServiceProxy serviceProxy = new StoreRestServiceProxy();
            Warehouse warehouse = new Warehouse(serviceProxy, gui);
            gui.SetWarehouse(warehouse);
            Application.Run(gui);
        }
    }
}
