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
    /// Interaction logic for WindowRequest.xaml
    /// </summary>
    public partial class WindowRequest : Window
    {
        public WindowRequest()
        {
            InitializeComponent();
            
        }

        private void buttonCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Request order = new Request();
            order.Client = (ClientPersonal)comboBoxClient.SelectedItem;
            order.Manager = (Manager)labelManager.Content;
            order.Item = comboBoxItem.SelectedItem.ToString();
            order.Price = Convert.ToDouble(textBoxPrice.Text);
            order.Discount = Convert.ToDouble(textBoxDiscount.Text);
            order.Total = Convert.ToDouble(textBoxTotal.Text);
            MainWindow.DB.Requests.Add(order);
            MessageBox.Show("Request add");
        }
    }
}
