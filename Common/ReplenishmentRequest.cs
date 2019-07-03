using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    [DataContract(Name = "replenishmentRequest", Namespace = "")]
    public class ReplenishmentRequest
    {
        public static int CurrId = 1;

        [DataMember(Name = "Id", Order = 1)]
        public int Id;

        [DataMember(Name = "Book", Order = 2)]
        public Book Book;

        [DataMember(Name = "Quantity", Order = 3)]
        public int Quantity;


        public ReplenishmentRequest() {}

        public ReplenishmentRequest(Book book, int quantity)
        {
            this.Id = CurrId;
            CurrId++;
            this.Book = book;
            this.Quantity = quantity;
        }

        public ReplenishmentRequest(int id, Book book, int quantity)
        {
            this.Id = id;
            this.Book = book;
            this.Quantity = quantity;
        }
    }

    [Serializable]
    [DataContract(Name = "replenishmentRequest", Namespace = "")]
    public class ReplenishmentRequestData
    {
        [DataMember(Name = "Id", Order = 1)]
        public int Id;

        [DataMember(Name = "Book", Order = 2)]
        public BookData Book;

        [DataMember(Name = "Quantity", Order = 3)]
        public int Quantity;
    }
}
