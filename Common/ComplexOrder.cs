using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class ComplexOrder : Order
    {
        public Dictionary<Book, int> BooksToQuantity = new Dictionary<Book, int>();
        public Dictionary<Book, bool> BooksToSatisfied = new Dictionary<Book, bool>();
        public Client Client;
      
        public ComplexOrder(Dictionary<Book, int> booksToQuantity, Client client, string state, bool satisfied) : base(state)
        {
            this.BooksToQuantity = booksToQuantity;
            foreach (Book book in booksToQuantity.Keys)
                BooksToSatisfied.Add(book, satisfied);
            this.Client = client;
        }

        public ComplexOrder(Dictionary<Book, int> booksToQuantity, Dictionary<Book, bool> booksToSatisfied, 
            Client client, string state) : base(state)
        {
            this.BooksToQuantity = booksToQuantity;
            this.BooksToSatisfied = booksToSatisfied;
            this.Client = client;
        }

    }
}
