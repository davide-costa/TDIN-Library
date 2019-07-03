using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    [DataContract(Name = "book", Namespace = "")]
    public class Book
    {
        [DataMember(Name = "CurrId", Order = 4)]
        public static int CurrId = 1;

        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; set; }

        [DataMember(Name = "Title", Order = 2)]
        public string Title;

        [DataMember(Name = "Price", Order = 3)]
        public double Price;


        public Book() { }

        public Book(string title, double price)
        {
            this.Id = CurrId;
            CurrId++;
            this.Title = title;
            this.Price = price;
        }

        public Book(int id, string title, double price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }
    }

    [DataContract]
    public class BookData
    {
        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; set; }

        [DataMember(Name = "Title", Order = 2)]
        public string Title { get; set; }

        [DataMember(Name = "Price", Order = 3)]
        public double Price { get; set; }
    }
}
