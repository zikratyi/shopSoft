using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopSoft
{
    [Serializable]
    class Request
    {
        private int _idRequest;
        public ClientPersonal Client { set; get; }
        public Manager Manager { set; get; }
        public string Item { set; get; }
        public double Price { set; get; }
        public int Discount { set; get; }
        public int Amount { set; get; }
        public double Total { set; get; }

        public int IDRequest
        {
            set
            {
                if (MainWindow.DB.Requests.Count() != 0)
                {
                    _idRequest = MainWindow.DB.Requests.Last<Request>().IDRequest + 1;
                }
                else
                {
                    _idRequest = 1;
                }
            }
            get
            {
                return _idRequest;
            }

        }
        public Request (ClientPersonal client, Manager manager, string item, double price, int discount, int amount, double total)
        {
            this.IDRequest = IDRequest;
            Client = client;
            Manager = manager;
            Item = item;
            Price = price;
            Discount = discount;
            Amount = amount;
            Total = total; 
        }
        public Request()
        {
            this.IDRequest = IDRequest;
        }
    }
}
