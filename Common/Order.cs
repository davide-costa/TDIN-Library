using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    [DataContract(Name = "order", Namespace = "")]
    public class Order
    {
        public static int CurrId = 1;
        public static string WaitingExpedition = "waiting expedition";

        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; }

        [DataMember(Name = "State", Order = 2)]
        public string State; //states: “waiting expedition”, “dispatched at … (date)” and “dispatch will occur at … (date)”


        public Order(string state)
        {
            this.Id = CurrId;
            CurrId++;
            this.State = state;
        }

        public Order()
        {
            this.Id = CurrId;
            CurrId++;
        }

        public static string DispatchedAtDate()
        {
            return "dispatched at " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        public static string DispatchWillOccurAtDate(String date)
        {
            return "dispatch will occur at " + date;
        }

        public static string DispatchWillOccurInTwoDays()
        {
            return "dispatch will occur at " + DateTime.Now.AddDays(2).ToString("dd-MM-yyyy");
        }
    }

    [DataContract]
    public class OrderData
    {
        [DataMember(Name = "Id", Order = 1)]
        public int Id { get; }

        [DataMember(Name = "State", Order = 2)]
        public string State; //states: “waiting expedition”, “dispatched at … (date)” and “dispatch will occur at … (date)”
    }
}
