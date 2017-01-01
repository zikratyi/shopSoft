using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            textBoxPrice.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            textBoxAmount.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            textBoxDiscount.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            textBoxTotal.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);

        }

        private void buttonCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Request order = new Request();
            order.Client = (ClientPersonal)comboBoxClient.SelectedItem;
            order.Manager = (Manager)labelManager.Content;
            order.Item = comboBoxItem.SelectedItem.ToString();
            order.Price = Convert.ToDouble(textBoxPrice.Text);
            order.Discount = Convert.ToInt32(textBoxDiscount.Text);
            order.Amount = Convert.ToInt32(textBoxAmount.Text);
            order.Total = Convert.ToDouble(textBoxTotal.Text);
            MainWindow.DB.Requests.Add(order);
            MessageBox.Show("Request add");
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            double total = 0;
            int discount = Convert.ToInt32(textBoxDiscount.Text);
            if (discount == 0)
            {
                total = Convert.ToDouble(textBoxPrice.Text) * Convert.ToDouble(textBoxAmount.Text);
            }
            else if (discount > 0 && discount < 100)
            {
                total = Convert.ToDouble(textBoxPrice.Text) * Convert.ToDouble(textBoxAmount.Text) * (1.0 - discount / 100.0);
            }
            else
            {
                MessageBox.Show("Input corect value for field 'Discount' (0,99)");
            }
            textBoxTotal.Text = total.ToString();
        }
        Regex inputRegex = new Regex(@"([0-9]|,)");
        void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }
    }
}
