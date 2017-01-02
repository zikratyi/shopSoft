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
        /// <summary>
        /// Insert new item to collection Softwares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DB.Softwares.Add(CreateItem());
            comboBoxPrice.UpdateLayout();
            ClearForm();
            MessageBox.Show("Item add to price");
        }
        /// <summary>
        /// Clear all fields Form
        /// </summary>
        private void ClearForm()
        {
            textBoxName.Text = String.Empty;
            textBoxRegularPrice.Text = String.Empty;
            textBoxDiscount.Text = "0";
            textBoxAction.Text = "No action";
            textBoxActionPrice.Text = "0";
        }
        /// <summary>
        /// Create regular for check input for fields
        /// </summary>
        Regex inputRegex = new Regex(@"([0-9]|,)");
        void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Match match = inputRegex.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Load information from selected Item to Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadPrice_Click(object sender, RoutedEventArgs e)
        {
            ListSoftware priceItem = MainWindow.DB.Softwares[comboBoxPrice.SelectedIndex];
            textBoxName.Text = priceItem.NameItem;
            textBoxRegularPrice.Text = priceItem.RegularPrice.ToString();
            textBoxDiscount.Text = priceItem.Discount.ToString();
            textBoxAction.Text = priceItem.Action;
            textBoxActionPrice.Text = priceItem.ActionPrice.ToString();
        }

        private void comboBoxPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = comboBoxPrice.SelectedIndex;
        }
        /// <summary>
        /// Update info about selected Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DB.Softwares[comboBoxPrice.SelectedIndex] = CreateItem();
            comboBoxPrice.UpdateLayout();
            ClearForm();
            MessageBox.Show("Update OK!");
        }
        /// <summary>
        /// Create new Item from fields  Form
        /// </summary>
        /// <returns></returns>
        private ListSoftware CreateItem()
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
            return Item;
        }
        /// <summary>
        /// Delete selected Item from collection Softwares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.DB.Softwares.RemoveAt(comboBoxPrice.SelectedIndex);
            comboBoxPrice.UpdateLayout();
            ClearForm();
        }
        /// <summary>
        /// Clear Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
    }
}
