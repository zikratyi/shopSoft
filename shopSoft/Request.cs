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
        public double Discount { set; get; }
        public double Total { set; get; }

        public int IDRequest
        {
            set
            {
                _idRequest = (int)MainWindow.DB.Requests.LongCount() + 1;
            }
            get
            {
                return _idRequest;
            }

        }
        public Request (ClientPersonal client, Manager manager, string item, double price, double discount, double total)
        {
            this.IDRequest = IDRequest;
            Client = client;
            Manager = manager;
            Item = item;
            Price = price;
            Discount = discount;
            Total = total; 
        }
        public Request()
        {
            this.IDRequest = IDRequest;
        }
    }
}
