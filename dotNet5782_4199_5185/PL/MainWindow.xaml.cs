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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BO;
using BlApi;



namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBL BLAccess; //access to bl layer through ibl interface
        public MainWindow()
        {
            var lp = new LoginPage();
            lp.ShowDialog();
            BLAccess = BlFactory.GetBl();
            InitializeComponent();


        }

        private void DroneList_click(object sender, RoutedEventArgs e)
        {
            new DroneList(BLAccess).Show();
        }

        private void ParcelList_click(object sender, RoutedEventArgs e)
        {
            new ParceList(BLAccess).Show();
        }

        private void CustomerList_click(object sender, RoutedEventArgs e)
        {
            new CustomerList(BLAccess).Show();
        }

        private void StationList_click(object sender, RoutedEventArgs e)
        {
            new StationList(BLAccess).Show();
        }
    }
}
