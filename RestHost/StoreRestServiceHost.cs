using System;
using System.ServiceModel.Web;

class StoreRestServiceHost
{
    static void Main()
    {
        WebServiceHost host = new WebServiceHost(typeof(StoreRestService.StoreRestService));
        host.Open();
        Console.WriteLine("Store Rest service running");
        Console.WriteLine("Press ENTER to stop the service");
        Console.ReadLine();
        host.Close();
    }
}