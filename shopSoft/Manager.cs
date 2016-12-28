using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopSoft
{
    [Serializable]
    class Manager : Person, ICreatableRequest
    {
        private int _id;
        public string login { set; get; }
        public string password { set; private get; }
        public Address AddressManager { set; get; }

        public int ID
        {
            set
            {
                _id = (int)MainWindow.DB.Managers.LongCount() + 1;
            }
            get
            {
                return _id;
            }

        }
        public Manager(string lastName, string firstName, string login, string password, string phone, string email, Address AddressManager) :
            base(lastName, firstName, phone, email)
        {
            this.ID = ID;
            this.login = login;
            this.password = password;
            this.AddressManager = AddressManager;
        }

        public override string ToString()
        {
            return String.Format(this.lastName + " " + this.firstName);
        }
        public string GetManagerName()
        {
            return String.Format(this.lastName + " " + this.firstName);
        }
        public void CreateRequest()
        {

            WindowRequest Order = new WindowRequest();
            //Request order = new Request();
            //order.Manager = manager;
            Order.comboBoxClient.ItemsSource = MainWindow.DB.Clients;
            Order.comboBoxClient.SelectedIndex = 0;
            Order.labelManager.Content = this;
            Order.comboBoxItem.ItemsSource = MainWindow.DB.Softwares;
            Order.comboBoxItem.SelectedIndex = 0;
            Order.Show();
        }
    }
}
