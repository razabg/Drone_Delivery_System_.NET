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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL.BO.IBL BLAccess = new IBL.BO.BLObject(); //access to bl layer through ibl interface
        public MainWindow(/*ref*/ IBL.BO.IBL  BLAccess)
        {
            
            InitializeComponent();
        }

        private void DroneList_click(object sender, RoutedEventArgs e)
        {
            new DroneList(BLAccess).Show();
        }

       
    }
}
