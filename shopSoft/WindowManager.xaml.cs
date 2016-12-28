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
    /// Interaction logic for WindowManager.xaml
    /// </summary>
    public partial class WindowManager : Window
    {
        public WindowManager()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = textBoxPass.Text;
            string lastName = textBoxLastName.Text;
            string firstName = textBoxFirstName.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string city = textBoxCity.Text;
            string street = textBoxStreet.Text;
            string building = textBoxBuilding.Text;
            string apart = textBoxApart.Text;
            Address AddressManager = new Address(city, street, building, apart);
            Manager Manager = new Manager(lastName, firstName, login, pass, phone, email, AddressManager);
            MainWindow.DB.Managers.Add(Manager);
            MessageBox.Show("Managers add");
            Close();
        }
    }
}
