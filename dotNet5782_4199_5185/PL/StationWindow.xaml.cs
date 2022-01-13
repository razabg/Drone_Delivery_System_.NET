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
    /// Interaction logic for StationWindow.xaml
    /// </summary>
    public partial class StationWindow : Window
    {
        BaseStation baseStation = new BaseStation();// insert the input of user to this object
        private IBL BLAccess;
        public StationWindow(IBL BLAccess)
        {
            this.BLAccess = BLAccess;
            InitializeComponent();
            btnUpdateChargeSlots.Visibility = Visibility.Hidden;
            btnUpdateName.Visibility = Visibility.Hidden;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void add_Station_Click(object sender, RoutedEventArgs e)
        {



            baseStation.DroneINCharge = null;
            baseStation.Id = int.Parse(IDfill.Text);
            baseStation.Name = txtName.Text;
            baseStation.NumberOfavailableChargingSlots = int.Parse(AvailableSlots.Text);
            baseStation.location.Latitude = double.Parse(labelLocation_lati.Text);
            baseStation.location.Longitude = double.Parse(labelLocation_longi.Text);

            //try
            //{
                BLAccess.AddStation(baseStation);
            //    StationEntityAddButton.IsEnabled = false;
            //    InvalidInputBlock.Text = "Station added!";
            //    InvalidInputBlock.Visibility = Visibility.Visible;
            //    InvalidInputBlock.Foreground = Brushes.Green;
            //    IDBox.IsEnabled = false;
            //    NamelBlock.IsEnabled = false;
            //    AvailableSlotsBox.IsEnabled = false;
            //    EnterLongitudeBox.IsEnabled = false;
            //    EnterLatitudeBox.IsEnabled = false;
            //    IconEntityAdded.Visibility = Visibility.Visible;
            //}
            //catch (Exception exp)
            //{
            //    InvalidInputBlock.Text = exp.Message;
            //    InvalidInputBlock.Visibility = Visibility.Visible;
            //}

        }
    }
}
