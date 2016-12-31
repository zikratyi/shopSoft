using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopSoft
{
    [Serializable]
    class Address
    {
        public string city { set; get; }
        public string street { set; get; }
        public string building { set; get; }
        public string apart { set; get; }
        public Address(string city, string street, string bulding, string apart)
        {
            this.city = city;
            this.street = street;
            this.building = bulding;
            this.apart = apart;
        }
        public Address()
        {

        }
    }
}
