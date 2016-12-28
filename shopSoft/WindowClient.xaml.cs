using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace shopSoft
{
    /// <summary>
    /// Interaction logic for WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        public WindowClient()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            string lastName = textBoxLastName.Text;
            string firstName = textBoxFirstName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string city = textBoxCity.Text;
            string street = textBoxStreet.Text;
            string building = textBoxBuilding.Text;
            string apart = textBoxApart.Text;
            Address AddressClient = new Address(city, street, building, apart);
            ClientPersonal Client = new ClientPersonal(AddressClient, lastName, firstName, phone, email);
            MainWindow.DB.Clients.Add(Client);
            MessageBox.Show("Clients add");
        }
    }
}
