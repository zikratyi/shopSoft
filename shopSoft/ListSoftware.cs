using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopSoft
{
    [Serializable]
    class ListSoftware
    {
        private int _idItem;
        public string NameItem { set; get; }
        public double RegularPrice { set; get; }
        private int _discount;
        private double _price;
        public string Action { set; get; }
        public double ActionPrice { set; get; }
        public int IDItem
        {
            set
            {
                _idItem = (int)MainWindow.DB.Softwares.LongCount() + 1;
            }
            get
            {
                return _idItem;
            }

        }
        public int Discount
        {
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _discount = value;
                }
                else _discount = 0;
            }
            get
            {
                return _discount;
            }
        }
        public double Price
        {
            set
            {
                _price = RegularPrice * (1 - (double)Discount / 100.0 );
            }
            get
            {
                return _price;
            }
        }
        public ListSoftware(string nameItem, double regularPrice, int  discount = 0, string action = "No action", double actionPrice = 0)
        {
            this.IDItem = IDItem;
            NameItem = nameItem;
            RegularPrice = regularPrice;
            Discount = discount;
            this.Price = Price;
            Action = action;
            ActionPrice = actionPrice;
        }

        //public ListSoftware(int idItem, string nameItem, int discount = 0)
        //{
        //    this.IDItem = idItem;
        //    NameItem = nameItem;
        //    Discount = discount;
        //    this.Price = Price;
        //}

        public override string ToString()
        {
            return NameItem;
        }
    }
}
