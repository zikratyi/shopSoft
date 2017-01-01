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
    /// Interaction logic for WindowPrice.xaml
    /// </summary>
    public partial class WindowPrice : Window
    {
        public WindowPrice()
        {
            InitializeComponent();
            textBoxRegularPrice.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            textBoxDiscount.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
            textBoxActionPrice.PreviewTextInput += new TextCompositionEventHandler(TextBox_PreviewTextInput);
        }

        private void buttonCreateItem_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text;
            double regularPrice = Convert.ToDouble(textBoxRegularPrice.Text);
            int discount = Convert.ToInt32(textBoxDiscount.Text);
            string action = textBoxAction.Text;
            double actionPrice = Convert.ToDouble(textBoxActionPrice.Text);
            ListSoftware Item;
            if (action == "No action")
            {
                Item = new ListSoftware(name, regularPrice, discount);
            }
            else
            {
                Item = new ListSoftware(name, regularPrice, discount, action, actionPrice);
            }
            MainWindow.DB.Softwares.Add(Item);
            ClearForm();
            MessageBox.Show("Item add to price");
        }
        private void ClearForm()
        {
            textBoxName.Text = String.Empty;
            textBoxRegularPrice.Text = String.Empty;
            textBoxDiscount.Text = "0";
            textBoxAction.Text = "No action";
            textBoxActionPrice.Text = "0";
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
