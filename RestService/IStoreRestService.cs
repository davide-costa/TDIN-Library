using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using System.ServiceModel.Configuration;
using Common;

namespace StoreRestService
{
    [ServiceContract]
    public interface IStoreRestService
    {
        [WebInvoke(Method = "POST", UriTemplate = "/startService")]
        [Description("Starts the service")]
        [OperationContract]
        void StartService();

        [WebInvoke(Method = "POST", UriTemplate = "/closeService")]
        [Description("Closes the service")]
        [OperationContract]
        void CloseService();

        [WebInvoke(Method = "POST", UriTemplate = "/onOrdersShipment", RequestFormat = WebMessageFormat.Json)]
        [Description("Changes internal state according to replenishment requests on traffic")]
        [OperationContract]
        void OnOrdersShipment(List<ReplenishmentRequestData> shippedReplenishmentOrderIds);

        [WebInvoke(Method = "POST", UriTemplate = "/registerOrdersListByClientId/{clientId}", RequestFormat = WebMessageFormat.Json)]
        [Description("Registers an order from a client in the system, based on client id")]
        [OperationContract]
        void RegisterOrdersListByClientId(string clientId, BasicOrderData basicOrderData);

        [WebInvoke(Method = "POST", UriTemplate = "/registerOrdersListByClientEmail/{clientEmail}", RequestFormat = WebMessageFormat.Json)]
        [Description("Registers an order from a client in the system, based on client email")]
        [OperationContract]
        void RegisterOrdersListByClientEmail(string clientEmail, BasicOrderData basicOrderData);

        [WebInvoke(Method = "POST", UriTemplate = "/client", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [Description("Registers a client in the system")]
        [OperationContract]
        void AddNewClient(string name, string address, string email);

        [WebInvoke(Method = "DELETE", UriTemplate = "/client/{clientId}")]
        [Description("Deletes a client from the system")]
        [OperationContract]
        void RemoveClient(string clientId);

        [WebGet(UriTemplate = "/shippedBookShipments", ResponseFormat = WebMessageFormat.Json)]
        [Description("Get information about books already shipped")]
        [OperationContract]
        List<List<ReplenishmentRequest>> LoadPendentListOfReplenishmentRequests();

        [WebInvoke(Method = "POST", UriTemplate = "/replenishmentRequest/{deliveryIndex}/receive")]
        [Description("Informs server of a received replenishment request on the Store")]
        [OperationContract]
        void ReceiveReplenishmentRequestDelivery(string deliveryIndex);

        [WebGet(UriTemplate = "/books", ResponseFormat = WebMessageFormat.Json)]
        [Description("Get books list and availability")]
        [OperationContract]
        BooksAndAvailability GetBooksListAndAvailability();

        [WebGet(UriTemplate = "/clients", ResponseFormat = WebMessageFormat.Json)]
        [Description("Get clients list")]
        [OperationContract]
        List<Client> GetClients();

        [WebInvoke(UriTemplate = "/orders/{userEmail}", ResponseFormat = WebMessageFormat.Json)]
        [Description("Get orders list")]
        [OperationContract]
        List<OrderToDisplay> GetOrders(string userEmail);
    }

    [DataContract]
    public class BooksAndAvailability
    {
        [DataMember]
        public List<BookData> books { get; set; }
        [DataMember]
        public List<int> availabilities { get; set; }
    }

    [DataContract]
    public class OrderToDisplay
    {
        [DataMember]
        public List<BookData> books { get; set; }
        [DataMember]
        public List<int> quantity { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public double totalPrice { get; set; }
    }
}