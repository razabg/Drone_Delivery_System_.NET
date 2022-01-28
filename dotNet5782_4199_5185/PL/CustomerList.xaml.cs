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
    }
}
