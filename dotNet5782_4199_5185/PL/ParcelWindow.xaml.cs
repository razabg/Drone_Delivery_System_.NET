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

        Parcel parcelTo = new Parcel();// insert the input of user to this object
        ObservableCollection<DroneAtParcel> ListOfInCharge = new ObservableCollection<DroneAtParcel>();
        private IBL BLAccess;
        public ParcelWindow(IBL BLAccess)
        {
            this.BLAccess = BLAccess;
            InitializeComponent();
            SendersBox.DataContext = BLAccess.GetCustomerAtParcels();
            ReceiverBox.DataContext = BLAccess.GetCustomerAtParcels();
            BoxPriority.DataContext = Enum.GetValues(typeof(statusEnum.PriorityStatus));
            BoxWeight.DataContext = Enum.GetValues(typeof(statusEnum.TopWeight));
            DroneINParcelListView.Visibility = Visibility.Hidden;
            ParcelCollected.Visibility = Visibility.Hidden;
            ParcelDeliverd.Visibility = Visibility.Hidden;

            boxSender_txt.Visibility = Visibility.Hidden;
            boxReceiver_txt.Visibility = Visibility.Hidden;
            boxWeight_txt.Visibility = Visibility.Hidden;
            boxPriority_txt.Visibility = Visibility.Hidden;

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

        public ParcelWindow(IBL BLAccess, Parcel parcel)
        {
            parcelTo = parcel;
            this.BLAccess = BLAccess;
            InitializeComponent();
            SendersBox.Visibility = Visibility.Hidden;
            ReceiverBox.Visibility = Visibility.Hidden;
            BoxPriority.Visibility = Visibility.Hidden;
            BoxWeight.Visibility = Visibility.Hidden;


            List<DroneAtParcel> displayDrone = new();
            displayDrone.Add(parcel.DroneParcel);
            if (parcel.DroneParcel.Id == 0)
            {
                DroneINParcelListView.Visibility = Visibility.Hidden;
            }


            add_parcel.IsEnabled = false;

            if (parcel.PairTime != null && parcel.CollectTime == null)
            {
                ParcelCollected.IsEnabled = true;
                ParcelDeliverd.IsEnabled = false;
            }

            if (parcel.PairTime != null && parcel.CollectTime != null && parcel.DeliveryTime == null)
            {
                ParcelCollected.IsEnabled = false;
                ParcelDeliverd.IsEnabled = true;
            }

            if (parcel.PairTime == null)
            {
                ParcelCollected.IsEnabled = false;
                ParcelDeliverd.IsEnabled = false;
            }

            boxCreationTime.Text = parcel.TimeOfCreation.ToString();
            boxCollectedTime.Text = parcel.CollectTime.ToString();
            boxArrivedTime.Text = parcel.DeliveryTime.ToString();
            boxPairTime.Text = parcel.PairTime.ToString();
            IDfill.Text = parcel.Id.ToString();
            DroneINParcelListView.DataContext = displayDrone;



            boxSender_txt.Text = parcel.sender.ToString();
            boxReceiver_txt.Text = parcel.target.ToString();
            boxWeight_txt.Text = parcel.Weight;
            boxPriority_txt.Text = parcel.Priority;


        }



        private void add_parcel_Click(object sender, RoutedEventArgs e)
        {
            CustomerAtParcel Sender = (CustomerAtParcel)SendersBox.SelectedItem;
            CustomerAtParcel Target = (CustomerAtParcel)ReceiverBox.SelectedItem;


            parcelTo.Priority = BoxPriority.SelectedItem.ToString();
            parcelTo.Weight = BoxWeight.SelectedItem.ToString();
            parcelTo.sender = Sender;
            parcelTo.target = Target;



            try
            {
                BLAccess.AddParcel(parcelTo);
                MessageBox.Show("the parcel was successfully added");
                //ParcelEntityAddButton.IsEnabled = false;
                //SenderIDSelector.IsEnabled = false;
                //TargetIDSelector.IsEnabled = false;
                //WeightSelector.IsEnabled = false;
                //PrioritySelector.IsEnabled = false;
            }
            catch (AlreadyExistsException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DroneINParcelListView.SelectedItem == null)
                return;
            DroneToList drone = new DroneToList();
            DroneAtParcel droneToList = DroneINParcelListView.SelectedItem as DroneAtParcel;

            try
            {
                drone = BLAccess.GetDroneToLists().ToList().Find(x => x.Id == droneToList.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DroneWindow droneWindow = new DroneWindow(BLAccess, drone);
            droneWindow.ShowDialog();
        }

        private void ParcelCollected_Click(object sender, RoutedEventArgs e)
        {
            int drone = parcelTo.DroneParcel.Id;

            try
            {
                BLAccess.DroneCollectParcel(drone);
                MessageBox.Show("the parcel was collected by the drone");
                ParcelDeliverd.IsEnabled = true;
                ParcelCollected.IsEnabled = false;
                Parcel parcel = BLAccess.DisplayParcel(parcelTo.Id);
                boxCollectedTime.Text = parcel.CollectTime.ToString();


            }
            catch (CannotPickUpException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Parcel_Deliverd(object sender, RoutedEventArgs e)
        {
            int drone = parcelTo.DroneParcel.Id;

            try
            {
                BLAccess.DroneArrivedToDestination(drone);
                MessageBox.Show("the parcel was delivered to the customer");
                ParcelDeliverd.IsEnabled = false;
                ParcelCollected.IsEnabled = false;
                Parcel parcel = BLAccess.DisplayParcel(parcelTo.Id);
                boxArrivedTime.Text = parcel.DeliveryTime.ToString();
           

            }
            catch (CannotSupplyException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
