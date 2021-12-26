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
        public DroneWindow(Ibl accsess)
        {
            InitializeComponent();
            DroneToList drone= new();
            BLAccess = new BLObject();
            choose_model.ItemsSource = Enum.GetValues(typeof(statusEnum.DroneModel));
            StationForCharge.ItemsSource = BLAccess.GetBaseStationToLists().ToList();
            MaxWeight.ItemsSource = Enum.GetValues(typeof(statusEnum.TopWeight));


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

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

      
    }
}
