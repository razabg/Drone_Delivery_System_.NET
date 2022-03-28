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
    /// Interaction logic for DroneWindow.xaml
    /// </summary>
    public partial class DroneWindow : Window
    {
        private IBL BLAccess;
        ObservableCollection<DroneToList> collection;
        DroneToList drone = new DroneToList();// insert the input of user to this object

        public event Action Update = delegate { };
        /// <summary>
        /// ctor for adding a drone
        /// </summary>
        /// <param name="BLAccess"></param>
        public DroneWindow(IBL BLAccess)
        {
            this.BLAccess = BLAccess;
            InitializeComponent();


            choose_model.DataContext = Enum.GetValues(typeof(statusEnum.DroneModel));
            StationForCharge.ItemsSource = BLAccess.GetBaseStationToLists().ToList();
            MaxWeight.ItemsSource = Enum.GetValues(typeof(statusEnum.TopWeight));


            txtBattery.Visibility = Visibility.Hidden;
            Latitude.Visibility = Visibility.Hidden;
            Longitude.Visibility = Visibility.Hidden;
            Status.Visibility = Visibility.Hidden;
            labelLatitude.Visibility = Visibility.Hidden;
            labelLongitude.Visibility = Visibility.Hidden;
            labelBattery.Visibility = Visibility.Hidden;
            labelStatus.Visibility = Visibility.Hidden;

            btnPickedup.IsEnabled = false;
            btnArrived.IsEnabled = false;
            btnCharge.IsEnabled = false;
            btnPairDrone_parcel.IsEnabled = false;
            btnArrived.IsEnabled = false;
            btnUpdateModel.IsEnabled = false;
            btnRelease_from_charge.IsEnabled = false;
           
            ShowModel.Visibility = Visibility.Hidden;
            ShowWeight.Visibility = Visibility.Hidden;




        }

        /// <summary>
        /// ctor for get information and updating a drone
        /// </summary>
        /// <param name="BLaccess"></param>
        /// <param name="drone_arg"></param>
        public DroneWindow(IBL BLaccess, DroneToList drone_arg)
        {

            InitializeComponent();

            this.BLAccess = BLaccess;
            drone = new DroneToList();
            drone = drone_arg;


            if (drone.Status == statusEnum.DroneStatus.Available.ToString())
            {
                btnRelease_from_charge.IsEnabled = false;
                btnPickedup.IsEnabled = false;
                btnArrived.IsEnabled = false;

            }

            if (drone.Status == statusEnum.DroneStatus.TreatmentMode.ToString())
            {
                btnCharge.IsEnabled = false;
                btnPickedup.IsEnabled = false;
                btnArrived.IsEnabled = false;
                btnPairDrone_parcel.IsEnabled = false;


            }

            if (drone.Status == statusEnum.DroneStatus.Busy.ToString())
            {
                if (drone.IdOfParcelInTransfer != null )
                {
                    btnPairDrone_parcel.IsEnabled = false;
                    btnPickedup.IsEnabled = false;
                    btnRelease_from_charge.IsEnabled = false;

                }
                else
                {
                    btnPairDrone_parcel.IsEnabled = false;
                    btnArrived.IsEnabled = false;
                }


            }
            add_drone.Visibility = Visibility.Hidden;
            StationForCharge.Visibility = Visibility.Hidden;
            labelStation.Visibility = Visibility.Hidden;
            labelInsertId.IsEnabled = false;
            choose_model.Visibility = Visibility.Hidden;
            MaxWeight.Visibility = Visibility.Hidden;
           


            txtBattery.Text = drone.Battery.ToString();
            ShowWeight.Text = drone.Weight;
            ShowModel.Text = drone.Model;
            IDfill.Text = drone.Id.ToString();
            Status.Text = drone.Status.ToString();
            Latitude.Text = drone.CurrentLocation.Latitude.ToString();
            Longitude.Text = drone.CurrentLocation.Longitude.ToString();


        }


        private void fillTextbox(DroneToList d)
        {

            Status.Text = d.Status.ToString();
            ShowModel.Text = d.Weight.ToString();
            IDfill.Text = d.Id.ToString();
            ShowModel.Text = d.Model.ToString();
            txtBattery.Text = d.Battery.ToString() + "%";

            Longitude.Text = d.CurrentLocation.Longitude.ToString();
            Latitude.Text = d.CurrentLocation.Latitude.ToString();
        }



        private void choose_model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void StationForCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MaxWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void IDfill_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void add_drone_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            try
            {
                drone.Id = Convert.ToInt32(IDfill.Text);
                drone.Model = choose_model.SelectedItem.ToString();
                drone.Weight = MaxWeight.SelectedItem.ToString();
                BaseStationToList stationId = (BaseStationToList)StationForCharge.SelectedItem;
                BLAccess.AddDrone(drone, Convert.ToInt32(stationId.Id));
                MessageBox.Show("the drone was successfully added");


            }
            catch (AlreadyExistsException)//check why the massage in not shown
            {
                MessageBox.Show("this id already exist");
                flag = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                flag = false;
            }
            if (!flag)
            {
                var bc = new BrushConverter();
                IDfill.BorderBrush = (Brush)bc.ConvertFrom("#FFE92617");

            }
            // new DroneWindow(BLAccess);
            if (flag)
            {

                this.Close();
            }




        }


        /// <summary>
        /// release the drone from chrage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRelease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLAccess.ReleaseDroneFromCharge(drone.Id/*int.Parse(charging_time.Text)*/);
                MessageBox.Show("the drone was release from charge");
                DroneToList dr = BLAccess.GetDroneToLists().ToList().Find(x => x.Id == drone.Id);
                fillTextbox(dr);
                btnRelease_from_charge.IsEnabled = false;
                btnArrived.IsEnabled = false;
                btnPairDrone_parcel.IsEnabled = true;
                btnPickedup.IsEnabled = false;
                if (dr.IdOfParcelInTransfer != null)
                {
                    btnArrived.IsEnabled = true;
                }
              

                Update();
            }
            catch (CannotReleaseFromChargeException ex)
            {
                MessageBox.Show("Cannot release the drone from charging station");


            }

        }
        /// <summary>
        /// send drone to charge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCharge_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                BLAccess.DroneToCharge(drone.Id);
                MessageBox.Show("the drone was sent to charge");
                DroneToList dr = BLAccess.GetDroneToLists().FirstOrDefault(X => X.Id == drone.Id);
                fillTextbox(dr);
                btnRelease_from_charge.IsEnabled = true;
                btnCharge.IsEnabled = false;
                btnPairDrone_parcel.IsEnabled = false;
                btnPickedup.IsEnabled = false;
                btnArrived.IsEnabled = false;


                Update();
            }
            catch (CannotGoToChargeException ex)
            {
                MessageBox.Show("faild to send the drone to charge");

            }

        }
        /// <summary>
        /// pair with parcel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAssignment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLAccess.ParingParcelToDrone(drone.Id);
                MessageBox.Show("The drone paired to parcel");
                DroneToList dr = BLAccess.GetDroneToLists().FirstOrDefault(x => x.Id == drone.Id);
                fillTextbox(dr);
                btnPickedup.IsEnabled = true;
                btnArrived.IsEnabled = false;
                btnCharge.IsEnabled = true;
                btnRelease_from_charge.IsEnabled = false;
                btnPairDrone_parcel.IsEnabled = false;
                
                Update();
            }
            catch (CannotAssignDroneToParcelException ex)
            {

                MessageBox.Show("Cannot pair");
            }
        }
        /// <summary>
        /// drone arrived to dest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                BLAccess.DroneArrivedToDestination(drone.Id);
                MessageBox.Show("the parcel was delivered to the customer");
                DroneToList dr = BLAccess.GetDroneToLists().ToList().Find(x => x.Id == drone.Id);
                fillTextbox(dr);


                btnPickedup.IsEnabled = false;
                btnCharge.IsEnabled = true;
                btnPairDrone_parcel.IsEnabled = true;
                btnArrived.IsEnabled = false;
                btnRelease_from_charge.IsEnabled = false;
                Update();

            }
            catch (CannotSupplyException ex)
            {

                MessageBox.Show("Cannot finish the delivery");
            }
        }
        /// <summary>
        /// drone picked up the parcel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickedup_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                BLAccess.DroneCollectParcel(drone.Id);
                DroneToList dr = BLAccess.GetDroneToLists().FirstOrDefault(x => x.Id == drone.Id);
                fillTextbox(dr);
                MessageBox.Show("the parcel was collected by the drone");


                btnPickedup.IsEnabled = false;
                btnCharge.IsEnabled = true;
                btnPairDrone_parcel.IsEnabled = false;
                btnArrived.IsEnabled = true;
                btnRelease_from_charge.IsEnabled = false;

               
                Update();

            }
            catch (CannotPickUpException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// update model of the drone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateModel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string model = ShowModel.Text;
                BLAccess.UpdateDroneModel(drone.Id, model);
                MessageBox.Show("the model of the drone was successfully updated");

                DroneToList dr = BLAccess.GetDroneToLists().ToList().Find(x => x.Id == drone.Id);
                fillTextbox(dr);
                Update();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot update the model");

            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtBattery_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Longitude_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Latitude_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Status_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ShowWeight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void charging_time_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
