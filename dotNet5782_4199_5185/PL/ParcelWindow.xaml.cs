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
    /// Interaction logic for ParcelWindow.xaml
    /// </summary>
    public partial class ParcelWindow : Window
    {

        Parcel baseStation = new Parcel();// insert the input of user to this object
        ObservableCollection<DroneAtParcel> ListOfInCharge = new ObservableCollection<DroneAtParcel>();
        private IBL BLAccess;
        public ParcelWindow(IBL BLAccess)
        {
            this.BLAccess = BLAccess;
            InitializeComponent();
            DroneINParcelListView.Visibility = Visibility.Hidden;

            IDfill.Visibility = Visibility.Hidden;
            labelInsertId.Visibility = Visibility.Hidden;
            labelArrivedTime.Visibility = Visibility.Hidden;
            labelCreationTime.Visibility = Visibility.Hidden;
            labelPairTime.Visibility = Visibility.Hidden;
            labelPickedUpTime.Visibility = Visibility.Hidden;
            labelDroneInParcel.Visibility = Visibility.Hidden;
            boxArrivedTime.Visibility = Visibility.Hidden;
            boxCollectedTime.Visibility = Visibility.Hidden;
            boxCreationTime.Visibility = Visibility.Hidden;
            boxPairTime.Visibility = Visibility.Hidden;
           

        }

        private void add_parcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
