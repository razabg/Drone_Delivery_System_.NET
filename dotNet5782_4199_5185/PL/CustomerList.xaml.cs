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
using BO;
using BlApi;
using System.Collections.ObjectModel;

namespace PL
{
    /// <summary>
    /// Interaction logic for CustomerList.xaml
    /// </summary>
    public partial class CustomerList : Window
    {
        private ObservableCollection<CustomerToList> collection = new ObservableCollection<CustomerToList>();
        private IBL BLAccess;
        public CustomerList(BlApi.IBL BLAccess)
        {
            InitializeComponent();
            this.BLAccess = BLAccess;
            collection = new ObservableCollection<CustomerToList>(BLAccess.GetCustomerToLists());
            CustomerListView.DataContext = collection;
           
           
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (CustomerListView.SelectedItem == null)
                return;
            Customer customer = new Customer();
            CustomerToList customerToList = CustomerListView.SelectedItem as CustomerToList;


            try
            {
                customer = BLAccess.DisplayCustomer(customerToList.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CustomerWindow customerWindow = new CustomerWindow(BLAccess, customer);
            customerWindow.ShowDialog();
            Update();
        }

        private void Update()
        {

            collection = new ObservableCollection<CustomerToList>(BLAccess.GetCustomerToLists());
            CustomerListView.DataContext = collection;

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow ToShow = new CustomerWindow(BLAccess);
            ToShow.ShowDialog();
            Update();

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
