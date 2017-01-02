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
            MainWindow.DB.Managers.Add(CreateNewManager());
            comboBoxManagers.UpdateLayout();
            MessageBox.Show("Managers add");
            ClearForm();
            
        }
        /// <summary>
        /// Load selected Manager to fields Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadManagers_Click(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].login;
            textBoxPass.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].password;
            textBoxLastName.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].lastName;
            textBoxFirstName.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].firstName;
            textBoxPhone.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].phone;
            textBoxEmail.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].email;
            textBoxCity.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].AddressManager.city;
            textBoxStreet.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].AddressManager.street;
            textBoxBuilding.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].AddressManager.building;
            textBoxApart.Text = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex].AddressManager.apart;
        }

        private void buttonUpdateManager_Click(object sender, RoutedEventArgs e)
        {
            Manager selectedManager = CreateNewManager();
            MainWindow.DB.Managers.RemoveAt(comboBoxManagers.SelectedIndex);
            MainWindow.DB.Managers.Insert(comboBoxManagers.SelectedIndex, selectedManager);
            comboBoxManagers.UpdateLayout();
            ClearForm();
        }
        private Manager CreateNewManager()
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
            Address addressManager = new Address(city, street, building, apart);
            Manager manager = new Manager(lastName, firstName, login, pass, phone, email, addressManager);
            return manager;
        }

        private void buttonDeleteManager_Click(object sender, RoutedEventArgs e)
        {
            bool isHaveRequet = false;
            Manager deletedManager = MainWindow.DB.Managers[comboBoxManagers.SelectedIndex];
            foreach (Request r in MainWindow.DB.Requests)
            {
                if (r.Manager.ID == deletedManager.ID) isHaveRequet = true;
            }
            if (!isHaveRequet)
            {
                MainWindow.DB.Managers.RemoveAt(comboBoxManagers.SelectedIndex);
                MessageBox.Show("Deleted OK!");
                comboBoxManagers.UpdateLayout();
                ClearForm();
            }
            else
            {
                MessageBox.Show("You don't deleted this Manager, because he has Request");
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            textBoxLogin.Text = String.Empty;
            textBoxPass.Text = String.Empty;
            textBoxLastName.Text = String.Empty;
            textBoxFirstName.Text = String.Empty;
            textBoxPhone.Text = String.Empty;
            textBoxEmail.Text = String.Empty;
            textBoxCity.Text = String.Empty;
            textBoxStreet.Text = String.Empty;
            textBoxBuilding.Text = String.Empty;
            textBoxApart.Text = String.Empty;
        }
    }
}
