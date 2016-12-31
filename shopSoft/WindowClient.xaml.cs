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
            loadDataToComboBox();
        }
        /// <summary>
        /// Index current Client in List<Client>
        /// </summary>
        int index = 0;
        /// <summary>
        /// Create new Client and add to List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            ClientPersonal client = new ClientPersonal();
            MainWindow.DB.Clients.Add(CreateClient(client));
            loadDataToComboBox();
            ClearForm();
            MessageBox.Show("Clients add");
        }
        /// <summary>
        /// Load information about selected Client into fields form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadClient_Click(object sender, RoutedEventArgs e)
        {
            ClientPersonal client = (ClientPersonal)comboBoxClients.SelectedItem;
            index = MainWindow.DB.Clients.IndexOf(client);
            textBoxLastName.Text = client.lastName;
            textBoxFirstName.Text = client.firstName;
            textBoxPhone.Text = client.phone;
            textBoxEmail.Text = client.email;
            textBoxCity.Text = client.AddressClient.city;
            textBoxStreet.Text = client.AddressClient.street;
            textBoxBuilding.Text = client.AddressClient.building;
            textBoxApart.Text = client.AddressClient.apart;
         }
        /// <summary>
        /// Update current Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            ClientPersonal client = MainWindow.DB.Clients[index];
            CreateClient(client);
            loadDataToComboBox();
            ClearForm();
            MessageBox.Show("Clients update");

        }
        /// <summary>
        /// Create new Client from fields form
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private ClientPersonal CreateClient(ClientPersonal client)
        {
            client.lastName = textBoxLastName.Text.ToString();
            client.firstName = textBoxFirstName.Text.ToString();
            client.phone = textBoxPhone.Text.ToString();
            client.email = textBoxEmail.Text.ToString();
            string city = textBoxCity.Text.ToString();
            string street = textBoxStreet.Text.ToString();
            string building = textBoxBuilding.Text;
            string apart = textBoxApart.Text;
            Address addressClient = new Address(city, street, building, apart);
            client.AddressClient = addressClient;
            return client;
        }
        /// <summary>
        /// Load List<Client> to comboBox
        /// </summary>
        private void loadDataToComboBox()
        {
            comboBoxClients.ItemsSource = MainWindow.DB.Clients;
            comboBoxClients.SelectedIndex = 0;
        }
        /// <summary>
        /// Clear fields form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
        /// <summary>
        /// Delete selected Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            ClientPersonal client = MainWindow.DB.Clients[index];
            MainWindow.DB.Clients.RemoveAt(index);
            ClearForm();
            MessageBox.Show(String.Format("Client {0} deleted!", client.ToString()));
        }
        private  void ClearForm()
        {
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
