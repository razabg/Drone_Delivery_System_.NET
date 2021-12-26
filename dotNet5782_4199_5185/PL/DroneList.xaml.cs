﻿using System;
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
    /// Interaction logic for DroneList.xaml
    /// </summary>
    public partial class DroneList : Window
    {

        private Ibl BLAccess ;//access to bl layer through ibl interface
        public DroneList(Ibl access)
        {
            InitializeComponent();
            BLAccess = new BLObject();
            DroneListView.ItemsSource = BLAccess.GetDroneToLists();
            dronestatus.ItemsSource = Enum.GetValues(typeof(statusEnum.DroneStatus));
            MaxWeight.ItemsSource = Enum.GetValues(typeof(statusEnum.Weight));

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
            statusEnum.Weight maxweight = (statusEnum.Weight)MaxWeight.SelectedItem;
            this.DroneListView.ItemsSource = BLAccess.GetDroneToLists().ToList().FindAll(x => x.Weight == maxweight.ToString());
        }
    }
}
