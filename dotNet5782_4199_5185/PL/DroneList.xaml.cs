using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DroneList.xaml
    /// </summary>
    public partial class DroneList : Window
    {

        private IBL BLAccess;//access to bl layer through ibl interface
        private ObservableCollection<DroneToList> collection;
        
        public DroneList(IBL access)
        {
            InitializeComponent();
            this.BLAccess = access;
            collection = new ObservableCollection<DroneToList>(BLAccess.GetDroneToLists());
            DataContext = collection;
            dronestatus.ItemsSource = Enum.GetValues(typeof(statusEnum.DroneStatus));
            MaxWeight.ItemsSource = Enum.GetValues(typeof(statusEnum.TopWeight));



        }


        public void Refresh()
        {
            collection = new ObservableCollection<DroneToList>(BLAccess.GetDroneToLists());
            DroneListView.DataContext = collection;
        }

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void StatusSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusEnum.DroneStatus status = (statusEnum.DroneStatus)dronestatus.SelectedItem;
            this.DroneListView.DataContext = collection.Where(x => x.Status == status.ToString());//BLAccess.GetDroneToLists().ToList().FindAll(x => x.Status == status.ToString());

        }

        private void MaxWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusEnum.TopWeight maxweight = (statusEnum.TopWeight)MaxWeight.SelectedItem;
            this.DroneListView.DataContext = collection.Where(x => x.Weight == maxweight.ToString());
            //this.DroneListView.DataContext = BLAccess.GetDroneToLists().ToList().FindAll(x => x.Weight == maxweight.ToString());
        }

        private void AddDrone_Click(object sender, RoutedEventArgs e)
        {
            DroneWindow ToShow = new DroneWindow(BLAccess);
            ToShow.ShowDialog();
            collection = new ObservableCollection<DroneToList>(BLAccess.GetDroneToLists());
            DroneListView.DataContext = collection;

        }


        /// <summary>
        /// open a certatin drone window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void List_viewDC(object sender, MouseButtonEventArgs e)
        {
            if (DroneListView.SelectedItem == null)
                return;
            DroneToList drone = new DroneToList();
            DroneToList drL = DroneListView.SelectedItem as DroneToList;

            try
            {
                drone = BLAccess.GetDroneToLists().ToList().Find(x => x.Id == drL.Id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            DroneWindow droneWindow = new DroneWindow(BLAccess, drone);
            droneWindow.Show();
            droneWindow.Update += DroneWindow_Update;

        }

        public void DroneWindow_Update()
        {
            collection = new ObservableCollection<DroneToList>(BLAccess.GetDroneToLists());
            DroneListView.DataContext = collection;
        }

        private void close_window_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// update list method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void updateList_Click(object sender, RoutedEventArgs e)
        {
            collection = new ObservableCollection<DroneToList>(BLAccess.GetDroneToLists());
            DroneListView.DataContext = collection;

        }
    }
}
