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

namespace PL
{
    /// <summary>
    /// Interaction logic for DroneList.xaml
    /// </summary>
    public partial class DroneList : Window
    {

        private IBL.BO.Ibl BLAccess;//access to bl layer through ibl interface
        public DroneList(IBL.BO.Ibl BLAccess)
        {
            BLAccess = new IBL.BO.BLObject();
            InitializeComponent();
        }

        private void DroneListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DroneListView.ItemsSource = BLAccess.GetDroneToLists();//add the fuc
        }
    }
}
