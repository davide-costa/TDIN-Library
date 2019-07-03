using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;
using System.Windows.Forms;
using Common;
using StoreRestService;
using Store;

class Program
{
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        StoreRestServiceProxy serviceProxy = new StoreRestServiceProxy();
        try
        {
            serviceProxy.StartService();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Error starting service");
            Console.ReadLine();
            return;
        }
        StoreGUI storeGui = new StoreGUI(serviceProxy);
        Application.Run(storeGui);
    }
}
