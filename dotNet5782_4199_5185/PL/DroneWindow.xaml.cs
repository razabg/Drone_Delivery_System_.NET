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
namespace PL
{
    /// <summary>
    /// Interaction logic for DroneWindow.xaml
    /// </summary>
    public partial class DroneWindow : Window
    {
        private IBL BLAccess;
        DroneToList drone = new DroneToList();// insert the input of user to this object
        public event Action Update = delegate { };
        public DroneWindow(IBL accsess)
        {
            InitializeComponent();

            BLAccess = BlFactory.GetBl();
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




        }

        public DroneWindow(IBL BLaccess, DroneToList drone_arg)
        {

            InitializeComponent();

            //to remove close box from window
            //Loaded += ToolWindow_Loaded;
            this.BLAccess = BLaccess;
            drone = new DroneToList();
            drone = drone_arg;
           

            if (drone.Status == statusEnum.DroneStatus.Available.ToString())
            {
                btnCharge.Visibility = Visibility.Visible;
                btnPairDrone_parcel.Visibility = Visibility.Visible;
            }

            if (drone.Status == statusEnum.DroneStatus.TreatmentMode.ToString())
            {
                btnRelease_from_charge.Visibility = Visibility.Visible;
            }

            if (drone.Status == statusEnum.DroneStatus.Busy.ToString())
            {
                btnArrived.Visibility = Visibility.Visible;
                btnPickedup.Visibility = Visibility.Visible;
            }
            add_drone.Visibility = Visibility.Hidden;
            StationForCharge.Visibility = Visibility.Hidden;
            labelStation.Visibility = Visibility.Hidden;
            labelInsertId.IsEnabled = false;
            choose_model.Visibility = Visibility.Hidden;
            MaxWeight.Visibility = Visibility.Hidden;


            txtBattery.Text = drone.Battery.ToString();
            ShowWeight.Text = drone.Weight;
            ShowModel.Text = drone.Status;
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
            catch (AlreadyExistsException ex)//check why the massage in not shown
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
            new DroneWindow(BLAccess);
            if (flag)
                this.Close();

            Update();



        }



        private void BtnRelease_Click(object sender, RoutedEventArgs e)
        {



        }

        private void btnCharge_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                BLAccess.DroneToCharge(drone.Id);
                MessageBox.Show("the drone was sent to charge");
                DroneToList dr = BLAccess.GetDroneToLists().FirstOrDefault(X => X.Id == drone.Id);
                fillTextbox(dr);
                btnRelease_from_charge.Visibility = Visibility.Visible;
                btnCharge.Visibility = Visibility.Hidden;
                btnPairDrone_parcel.Visibility = Visibility.Hidden;
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("faild to send the drone to charge");

            }

        }

        private void btnAssignment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLAccess.ParingParcelToDrone(drone.Id);
                MessageBox.Show("The drone paired to parcel");
                DroneToList dr = BLAccess.GetDroneToLists().FirstOrDefault(x=>x.Id==drone.Id);
                fillTextbox(dr);
                btnPickedup.Visibility = Visibility.Visible;
                btnArrived.Visibility = Visibility.Hidden;
                btnCharge.Visibility = Visibility.Hidden;
                btnPairDrone_parcel.Visibility = Visibility.Hidden;
                Update();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPickedup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateModel_Click(object sender, RoutedEventArgs e)
        {


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
    }
}
