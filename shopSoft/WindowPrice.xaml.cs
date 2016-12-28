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
    /// Interaction logic for WindowPrice.xaml
    /// </summary>
    public partial class WindowPrice : Window
    {
        public WindowPrice()
        {
            InitializeComponent();
        }

        private void buttonCreateItem_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text;
            double regularPrice = Convert.ToDouble(textBoxRegularPrice.Text);
            double discount = Convert.ToDouble(textBoxDiscount.Text);
            string action = textBoxAction.Text;
            double actionPrice = Convert.ToDouble(textBoxPrice.Text);
            ListSoftware Item;
            if (action == String.Empty)
            {
                Item = new ListSoftware(name, regularPrice);
            }
            else
            {
                Item = new ListSoftware(name, regularPrice, discount, action, actionPrice);
            }
            MainWindow.DB.Softwares.Add(Item);
            MessageBox.Show("Item add to price");
        }
    }
}
