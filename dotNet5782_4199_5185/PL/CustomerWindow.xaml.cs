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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {

        Customer CustomerTo = new Customer();// insert the input of user to this object
        //ObservableCollection<> ListOfInCharge = new ObservableCollection<DroneAtParcel>();
        private IBL BLAccess;
        /// <summary>
        /// general ctor for adding a customer
        /// </summary>
        /// <param name="BlAccess"></param>
        public CustomerWindow(IBL BlAccess)
        {
            InitializeComponent();
            this.BLAccess = BlAccess;
            btnUpdateName_Copy.Visibility = Visibility.Hidden;
            btnUpdatePhoneNumber.Visibility = Visibility.Hidden;

            labelParcelRe.Visibility = Visibility.Hidden;
            labelParcelSent.Visibility = Visibility.Hidden;
            ParcelReceivedListView.Visibility = Visibility.Hidden;
            SentParcelListView.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// ctor in case of a certain customer
        /// </summary>
        /// <param name="BlAccess"></param>
        /// <param name="customer"></param>
        public CustomerWindow(IBL BlAccess,Customer customer)
        {
           
            this.BLAccess = BlAccess;
            InitializeComponent();
            IDfill.Text = customer.Id.ToString();
            txtName.Text = customer.Name;
            txtPhone.Text = customer.PhoneNumber.ToString();
            Location_lati.Text = customer.location.Latitude.ToString();
            Location_longi.Text = customer.location.Longitude.ToString();
            addCustomer.Visibility = Visibility.Hidden;
            Location_lati.IsEnabled = false;
            Location_longi.IsEnabled = false;
            IDfill.IsEnabled = false;

            ParcelReceivedListView.DataContext = customer.ToCustomer;
            SentParcelListView.DataContext = customer.FromCustomer;




        }
        /// <summary>
        /// add customer click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerTo.Id = Convert.ToInt32(IDfill.Text);
            CustomerTo.Name = txtName.Text;
            CustomerTo.PhoneNumber = Convert.ToInt32(txtPhone.Text);
            CustomerTo.location = new(Convert.ToDouble(Location_longi.Text), Convert.ToDouble(Location_lati.Text));

            try
            {
                BLAccess.AddCustomer(CustomerTo);
                MessageBox.Show("the customer was successfully added");
                
            }
            catch (AlreadyExistsException)
            {
                MessageBox.Show("already there");

            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// update phone number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdatePhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLAccess.UpdateCustomerData(Convert.ToInt32(IDfill.Text), null, txtPhone.Text);
                MessageBox.Show("The phone number of the customer was successfully updated");
            }
            catch (Exception)
            {
                MessageBox.Show("cannot update the phone number");

            }



        }
        /// <summary>
        /// update name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateName_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLAccess.UpdateCustomerData(Convert.ToInt32(IDfill.Text), txtName.Text, null);
                MessageBox.Show("The name of the customer was successfully updated");
            }
            catch (Exception)
            {
                MessageBox.Show("cannot update the name");

            }



        }
    }
}
