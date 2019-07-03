using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

namespace PrinterRestService
{
    [ServiceContract]
    public interface IPrinterRestService
    {
        [WebInvoke(Method = "POST", UriTemplate = "/printReceipt")]
        [Description("Prints the received text, representing a receipt")]
        [OperationContract]
        void PrintReceipt(string receiptText);
    }

}