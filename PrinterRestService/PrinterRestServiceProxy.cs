using System;
using System.ServiceModel;

namespace PrinterRestService
{
    public class PrinterRestServiceProxy : ClientBase<IPrinterRestService>, IPrinterRestService
    {
        public void PrintReceipt(string receiptText)
        {
            Channel.PrintReceipt(receiptText);
        }
    }
}
