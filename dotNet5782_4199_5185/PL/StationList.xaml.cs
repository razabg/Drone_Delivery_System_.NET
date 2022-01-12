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
    /// Interaction logic for StationList.xaml
    /// </summary>
    public partial class StationList : Window
    {
        private IBL BLAccess;//access to bl layer through ibl interface
        private ObservableCollection<BaseStationToList> collection = new ObservableCollection<BaseStationToList>();
        public StationList(BlApi.IBL BLAccess)
        {
            InitializeComponent();
            BLAccess = BlFactory.GetBl();
            collection = new ObservableCollection<BaseStationToList>(BLAccess.GetBaseStationToLists());
            StationListView.DataContext = collection;
        }

        private void StationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StationListView.ItemsSource);
            view.GroupDescriptions.Clear();
        }

        private void Group_By_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(StationListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("NumOfAvailableChargingSlots");
            view.GroupDescriptions.Add(groupDescription);
            

        }
    }
}
