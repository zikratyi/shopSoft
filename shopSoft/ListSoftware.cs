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
        public int _discount;
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
        public ListSoftware(string nameItem, double regularPrice, int  discount = 0, string action = "No action", double actionPrice = 0)
        {
            this.IDItem = IDItem;
            NameItem = nameItem;
            RegularPrice = regularPrice;
            Discount = discount;
            Action = action;
            ActionPrice = actionPrice;
        }

        public ListSoftware(int idItem, string nameItem, int discount = 0)
        {
            IDItem = idItem;
            NameItem = nameItem;
            Discount = discount;

        }

        public override string ToString()
        {
            return NameItem;
        }
    }
}
