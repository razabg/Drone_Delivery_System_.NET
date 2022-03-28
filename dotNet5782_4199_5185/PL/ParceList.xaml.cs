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
    /// Interaction logic for ParceList.xaml
    /// </summary>
    public partial class ParceList : Window
    {
        private IBL BLAccess;
        private ObservableCollection<ParcelToList> collection = new ObservableCollection<ParcelToList>();
        public ParceList(IBL BLAccess)
        {
            InitializeComponent();
            this.BLAccess = BLAccess;
            FilterByPriority.ItemsSource = Enum.GetValues(typeof(statusEnum.PriorityStatus));
            FilterByStatus.ItemsSource = Enum.GetValues(typeof(statusEnum.ParcelStatus));
            FilterByWeight.ItemsSource = Enum.GetValues(typeof(statusEnum.TopWeight));
            collection = new ObservableCollection<ParcelToList>(BLAccess.GetParcelToLists());
            ParcelListView.DataContext = collection;
        }


        private void ParcelListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// three filter method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FilterByStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusEnum.ParcelStatus status = (statusEnum.ParcelStatus)FilterByStatus.SelectedItem;
            this.ParcelListView.DataContext = collection.Where(x => x.Status == status.ToString());
        }

        public void FilterByWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            statusEnum.TopWeight weight = (statusEnum.TopWeight)FilterByWeight.SelectedItem;
            this.ParcelListView.DataContext = collection.Where(x => x.Weight == weight.ToString());
        }

        public void FilterByPriority_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            statusEnum.PriorityStatus Priority = (statusEnum.PriorityStatus)FilterByPriority.SelectedItem;
            this.ParcelListView.DataContext = collection.Where(x => x.Priority == Priority.ToString());
        }

        public void Filters()
        {




        }
        /// <summary>
        /// three method of grupe by without using linq
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Group_By_Click(object sender, RoutedEventArgs e)//by sender
        {

            CollectionView viewClear = (CollectionView)CollectionViewSource.GetDefaultView(ParcelListView.ItemsSource);
            viewClear.GroupDescriptions.Clear();


            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ParcelListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("SenderName");
            view.GroupDescriptions.Add(groupDescription);

        }

        private void Group_By_receiver_Click(object sender, RoutedEventArgs e)
        {

            CollectionView viewClear = (CollectionView)CollectionViewSource.GetDefaultView(ParcelListView.ItemsSource);
            viewClear.GroupDescriptions.Clear();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ParcelListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("ReceiverName");
            view.GroupDescriptions.Add(groupDescription);


        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
           
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ParcelListView.ItemsSource);
            view.GroupDescriptions.Clear();
            this.ParcelListView.DataContext = collection;



        }

        private void AddParcel_Click(object sender, RoutedEventArgs e)
        {
            ParcelWindow ToShow = new ParcelWindow(BLAccess);
            ToShow.ShowDialog();
            Update();
        }

        private void Update()
        {
            collection = new ObservableCollection<ParcelToList>(BLAccess.GetParcelToLists());
            ParcelListView.DataContext = collection;

        }
        /// <summary>
        /// event of opening window of specific parcel for info and update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoubleClickEvent(object sender, MouseButtonEventArgs e)
        {
            if (ParcelListView.SelectedItem == null)
                return;
            Parcel parcel = new Parcel();
            ParcelToList parcelToList = ParcelListView.SelectedItem as ParcelToList;
            

            try
            {
                parcel = BLAccess.DisplayParcel(parcelToList.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ParcelWindow stationWindow = new ParcelWindow(BLAccess, parcel);
            stationWindow.ShowDialog();
            Update();
        }
    }
}
