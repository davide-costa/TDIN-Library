using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRestService
{
    [Serializable]
    class StoreRestServiceData
    {
        public List<ComplexOrder> _pendentOrders = new List<ComplexOrder>();
        public List<List<ReplenishmentRequest>> _pendentListOfReplenishmentRequestsOrderedByShipmentOrder = new List<List<ReplenishmentRequest>>();
        public List<KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>>> _pendentOrdersThatWereSolvedToBooksRemainingStockIncrement =
            new List<KeyValuePair<List<ComplexOrder>, Dictionary<Book, int>>>();

        public List<ComplexOrder> _ordersSolved = new List<ComplexOrder>();
        public List<Client> _clients = new List<Client>();
        public Dictionary<int, Client> _clientsMap = new Dictionary<int, Client>();
        public Dictionary<int, Book> _booksCollectionMap = new Dictionary<int, Book>();
        public Dictionary<int, int> _booksAvailability = new Dictionary<int, int>();

        public int _clientCurrId;
        public int _bookCurrId;
        public int _replenishmentRequestCurrId;
        public int _orderCurrId;
    }
}
