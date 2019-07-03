using System.Collections.Generic;
using System.ServiceModel;
using Common;

namespace StoreRestService
{
    public class StoreRestServiceProxy : ClientBase<IStoreRestService>, IStoreRestService
    {
        public void StartService()
        {
            Channel.StartService();
        }

        public void CloseService()
        {
            Channel.CloseService();
        }

        public void OnOrdersShipment(List<ReplenishmentRequestData> shippedReplenishmentOrderIds)
        {
            Channel.OnOrdersShipment(shippedReplenishmentOrderIds);
        }

        public void RegisterOrdersListByClientId(string clientId, BasicOrderData basicOrderData)
        {
            Channel.RegisterOrdersListByClientId(clientId, basicOrderData);
        }

        public void RegisterOrdersListByClientEmail(string clientEmail, BasicOrderData basicOrderData)
        {
            Channel.RegisterOrdersListByClientEmail(clientEmail, basicOrderData);
        }

        public void AddNewClient(string name, string address, string email)
        {
            Channel.AddNewClient(name, address, email);
        }

        public void RemoveClient(string clientId)
        {
            Channel.RemoveClient(clientId);
        }

        public List<List<ReplenishmentRequest>> LoadPendentListOfReplenishmentRequests()
        {
            return Channel.LoadPendentListOfReplenishmentRequests();
        }

        public void ReceiveReplenishmentRequestDelivery(string deliveryIndex)
        {
            Channel.ReceiveReplenishmentRequestDelivery(deliveryIndex);
        }

        public BooksAndAvailability GetBooksListAndAvailability()
        {
            return Channel.GetBooksListAndAvailability();
        }

        public List<Client> GetClients()
        {
            return Channel.GetClients();
        }

        public List<OrderToDisplay> GetOrders(string userEmail)
        {
            return Channel.GetOrders(userEmail);
        }
    }
}
