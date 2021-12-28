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
using IBL.BO;
namespace PL
{
    /// <summary>
    /// Interaction logic for DroneWindow.xaml
    /// </summary>
    public partial class DroneWindow : Window
    {
        private Ibl BLAccess;
        DroneToList drone = new DroneToList();// insert the input of user to this object
        public event Action Update = delegate { };
        public DroneWindow(Ibl accsess)
        {
            InitializeComponent();

            BLAccess = new BLObject();
            choose_model.ItemsSource = Enum.GetValues(typeof(statusEnum.DroneModel));
            StationForCharge.ItemsSource = BLAccess.GetBaseStationToLists().ToList();
            MaxWeight.ItemsSource = Enum.GetValues(typeof(statusEnum.TopWeight));


            txtBattery.Visibility = Visibility.Hidden;
            Latitude.Visibility = Visibility.Hidden;
            Longitude.Visibility = Visibility.Hidden;
            Status.Visibility = Visibility.Hidden;
            labelLatitude.Visibility = Visibility.Hidden;
            lableLongitude.Visibility = Visibility.Hidden;
            lableBattery.Visibility = Visibility.Hidden;
            lableStatus.Visibility = Visibility.Hidden;




        }

        public DroneWindow(Ibl BLaccess, Drone drone_arg)
        {

            InitializeComponent();

            //to remove close box from window
            Loaded += ToolWindow_Loaded;
            this.BLAccess = BLaccess;
            drone = new DroneToList();
            drone = drone_arg;
            grdAdd.Visibility = Visibility.Hidden;
            MaxWeight.Visibility = Visibility.Hidden;
            comboStatus.Visibility = Visibility.Hidden;
            grdRelease.Visibility = Visibility.Hidden;
            fillTextbox(drone);
            if (d.Status == statusEnum.DroneStatus.Available.ToString())
            {
                btnCharge.Visibility = Visibility.Visible;
                btnAssignment.Visibility = Visibility.Visible;
            }

            if (d.Status == statusEnum.DroneStatus.TreatmentMode.ToString())
            {
                btnRelease.Visibility = Visibility.Visible;
            }

            if (d.Status == statusEnum.DroneStatus.Busy.ToString())
            {
                btnDelivery.Visibility = Visibility.Visible;
                btnPickedup.Visibility = Visibility.Visible;
            }
            txtStatus.IsEnabled = false;
            txtMaxWeight.IsEnabled = false;
            txtId.IsEnabled = false;
            comboStatus.IsEnabled = false;
            comboMaxWeight.IsEnabled = false;
            txtBattery.IsEnabled = false;

            txtLongtitude.IsEnabled = false;
            txtLatitude.IsEnabled = false;
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



        }



        private void btnRelease_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCharge_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAssignment_Click(object sender, RoutedEventArgs e)
        {

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
