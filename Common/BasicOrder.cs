using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    [DataContract(Name = "basicOrder", Namespace = "")]
    public class BasicOrder : Order
    {
        [DataMember(Name = "BooksIdsToQuantity", Order = 1)]
        public Dictionary<int, int> BooksIdsToQuantity;

        [DataMember(Name = "ClientId", Order = 2)]
        public int ClientId;


        public BasicOrder(Dictionary<int, int> booksIdsToQuantity, int clientId, string state) : base(state)
        {
            this.BooksIdsToQuantity = booksIdsToQuantity;
            this.ClientId = clientId;
        }

        public BasicOrder(Dictionary<int, int> booksIdsToQuantity, int clientId) : base()
        {
            this.BooksIdsToQuantity = booksIdsToQuantity;
            this.ClientId = clientId;
        }

    }

    [DataContract]
    public class BasicOrderData
    {
        [DataMember(Name = "BooksIds", Order = 1)]
        public List<int> BooksIds;

        [DataMember(Name = "BooksQuantity", Order = 2)]
        public List<int> BooksQuantity;
    }
}
