using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopSoft
{
    [Serializable]
    class ClientPersonal : Person
    {
        private int _id;
        public Address AddressClient { set; get; }
        public int ID
        {
            set
            {
                _id = (int)MainWindow.DB.Clients.LongCount() + 1;
            }
            get
            {
                return _id;
            }

        }

        public ClientPersonal( Address AddressClient, string lastName, string firstName, string phone, string email) : 
            base(lastName, firstName, phone, email)
        {
            this.ID = ID;
            this.AddressClient = AddressClient;
        }
        public override string ToString()
        {
            return String.Format(lastName + " " + firstName);
        }
    }
}
