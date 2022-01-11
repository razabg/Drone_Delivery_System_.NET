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
    /// Interaction logic for StationList.xaml
    /// </summary>
    public partial class StationList : Window
    {
        public StationList(BlApi.IBL BLAccess)
        {
            InitializeComponent();
            BLAccess = BlFactory.GetBl();
            StationListView.DataContext = BLAccess.GetBaseStationToLists();
        }

        private void StationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
