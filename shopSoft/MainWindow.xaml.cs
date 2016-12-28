﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace shopSoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            listBoxManagers.ItemsSource = DB.Managers;
            
        }
        /// <summary>
        /// Create new data base
        /// </summary>
        public static class DB
        {
            static internal ObservableCollection<ClientPersonal> Clients = new ObservableCollection<ClientPersonal>();
            static internal ObservableCollection<Manager> Managers = new ObservableCollection<Manager>();
            static internal ObservableCollection<ListSoftware> Softwares = new ObservableCollection<ListSoftware>();
            static internal ObservableCollection<Request> Requests = new ObservableCollection<Request>();
        }
        /// <summary>
        /// Save information from List<> to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveDB_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("clients.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DB.Clients);
            }
            using (FileStream fs = new FileStream("managers.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DB.Managers);
            }
            using (FileStream fs = new FileStream("softwares.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DB.Softwares)
            }
            using (FileStream fs = new FileStream("requests.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, DB.Requests);
            }
            MessageBox.Show("db save OK!");
        }
        /// <summary>
        /// Create new window for input information about Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateClient_Click(object sender, RoutedEventArgs e)
        {
            WindowClient Window = new WindowClient();
            Window.Show();
        }
        /// <summary>
        /// Load DB (DB includes file: Clients, Managers, Softwares and Requests)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadDB_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("clients.dat", FileMode.OpenOrCreate))
            {
                DB.Clients = (ObservableCollection<ClientPersonal>)formatter.Deserialize(fs);
            }
            using (FileStream fs = new FileStream("managers.dat", FileMode.OpenOrCreate))
            {
                DB.Managers = (ObservableCollection<Manager>)formatter.Deserialize(fs);
                listBoxManagers.ItemsSource = DB.Managers;
            }
            using (FileStream fs = new FileStream("softwares.dat", FileMode.OpenOrCreate))
            {
                DB.Softwares = (ObservableCollection<ListSoftware>)formatter.Deserialize(fs);
            }
            using (FileStream fs = new FileStream("requests.dat", FileMode.OpenOrCreate))
            {
                DB.Requests = (ObservableCollection<Request>)formatter.Deserialize(fs);
            }
            MessageBox.Show("db load OK!");
        }
        /// <summary>
        /// View contests DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonViewDB_Click(object sender, RoutedEventArgs e)
        {
            WindowDataGrid windowResult = new WindowDataGrid();
            windowResult.dataGridClient.ItemsSource = DB.Clients;
            windowResult.dataGridManager.ItemsSource = DB.Managers;
            windowResult.dataGridSoftware.ItemsSource = DB.Softwares;
            windowResult.dataGridRequest.ItemsSource = DB.Requests;
            windowResult.Show();
        }
        /// <summary>
        /// Create new window for input information about Request with selected Manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            Manager manager;
            manager = (Manager)listBoxManagers.SelectedItem;
            manager.CreateRequest();
        }
        /// <summary>
        /// Create new window for input information about Manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateManager_Click(object sender, RoutedEventArgs e)
        {
            WindowManager Manager = new WindowManager();
            Manager.Owner = this;
            Manager.Show();
        }
        /// <summary>
        /// Create new window for input information about Software
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreatePrice_Click(object sender, RoutedEventArgs e)
        {
            WindowPrice Price = new WindowPrice();
            Price.Show();
        }

        
        
    }
}
