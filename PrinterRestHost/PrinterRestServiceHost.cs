using System;
using System.ServiceModel.Web;

class PrinterRestServiceHost
{
    static void Main()
    {
        WebServiceHost host = new WebServiceHost(typeof(PrinterRestService.PrinterRestService));
        host.Open();
        Console.WriteLine("Printer Rest service running");
        Console.WriteLine("Press ENTER to stop the service");
        Console.ReadLine();
        host.Close();
    }
}