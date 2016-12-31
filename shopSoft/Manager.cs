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
                if (MainWindow.DB.Managers.Count() != 0)
                {
                    _id = MainWindow.DB.Managers.Last<Manager>().ID + 1;
                }
                else
                {
                    _id = 1;
                }
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
        
        public void CreateRequest()
        {

            WindowRequest windowOrder = new WindowRequest();
            windowOrder.comboBoxClient.ItemsSource = MainWindow.DB.Clients;
            windowOrder.comboBoxClient.SelectedIndex = 0;
            windowOrder.labelManager.Content = this;
            windowOrder.comboBoxItem.ItemsSource = MainWindow.DB.Softwares;
            windowOrder.comboBoxItem.SelectedIndex = 0;
            windowOrder.Show();
        }
    }
}
