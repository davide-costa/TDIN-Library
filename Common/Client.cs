using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Client
    {
        public static int CurrId = 1;
        public int Id { get; }
        public string Name;
        public string Address;
        public string Email;
        public string Password;


        public Client(string name, string email, string address)
        {
            this.Id = CurrId;
            CurrId++;
            this.Name = name;
            this.Email = email;
            this.Address = address;
        }

    }
}
