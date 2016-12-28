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
        public double Discount { set; get; }
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

        public ListSoftware(string nameItem, double regularPrice, double  discount = 1.0, string action = "No action", double actionPrice = 0)
        {
            this.IDItem = IDItem;
            NameItem = nameItem;
            RegularPrice = regularPrice;
            Discount = discount;
            Action = action;
            ActionPrice = actionPrice;
        }

        public ListSoftware(int idItem, string nameItem)
        {
            IDItem = idItem;
            NameItem = nameItem;

        }

        public override string ToString()
        {
            return NameItem;
        }
    }
}
