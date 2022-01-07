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

        private IBL BLAccess ;//access to bl layer through ibl interface
        private ObservableCollection<DroneToList> collection;
        public DroneList(IBL access)
        {
            InitializeComponent();
            BLAccess = BlFactory.GetBl();
            DroneListView.DataContext = BLAccess.GetDroneToLists();
            dronestatus.ItemsSource = Enum.GetValues(typeof(statusEnum.DroneStatus));
            MaxWeight.ItemsSource = Enum.GetValues(typeof(statusEnum.TopWeight));

            collection = new ObservableCollection<DroneToList>(BLAccess.GetDroneToLists());
            DroneListView.ItemsSource = collection;
           

        }

       
        public void Refresh()
        {

            DroneListView.DataContext = BLAccess.GetDroneToLists();

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void StatusSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusEnum.DroneStatus status = (statusEnum.DroneStatus)dronestatus.SelectedItem;
            this.DroneListView.ItemsSource = BLAccess.GetDroneToLists().ToList().FindAll(x=>x.Status == status.ToString());
            
        }

        private void MaxWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusEnum.TopWeight maxweight = (statusEnum.TopWeight)MaxWeight.SelectedItem;
            this.DroneListView.ItemsSource = BLAccess.GetDroneToLists().ToList().FindAll(x => x.Weight == maxweight.ToString());
        }

        private void AddDrone_Click(object sender, RoutedEventArgs e)
        {
           DroneWindow ToShow = new DroneWindow(BLAccess);
            ToShow.Show();


        }

       

        private void List_viewDC(object sender, MouseButtonEventArgs e)
        {
            if (DroneListView.SelectedItem == null)
                return;
            DroneToList drone = new DroneToList();
            DroneToList drL = DroneListView.SelectedItem as DroneToList;

            try
            {
                drone = BLAccess.GetDroneToLists().ToList().Find(x=>x.Id==drL.Id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            DroneWindow droneWindow = new DroneWindow(BLAccess, drone);
            droneWindow.Show();
            droneWindow.Update += DroneWindow_Update;

        }

        private void DroneWindow_Update()
        {
            collection = new ObservableCollection<DroneToList>(BLAccess.GetDroneToLists());
            DroneListView.ItemsSource = collection;
        }

        private void close_window_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void updateList_Click(object sender, RoutedEventArgs e)
        {
            DroneListView.ItemsSource = BLAccess.GetDroneToLists();
        }
    }
}
