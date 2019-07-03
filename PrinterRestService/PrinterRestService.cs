using System;
using System.ServiceModel;

namespace PrinterRestService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PrinterRestService : IPrinterRestService
    {
        public void PrintReceipt(string receiptText)
        {
            Console.WriteLine(receiptText + "\n\n\n");
        }
    }
}