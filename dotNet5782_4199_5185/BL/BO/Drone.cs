using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl drone entity
    /// </summary>
    public class Drone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string MaxWeight { get; set; }
        public double Battery { get; set; }
        public string Status { get; set; }
        public ParcelInTransfer Parcel { get; set; }
        public Location CurrentLocation { get; set; }

        public override string ToString()
        {
            string printDroneInfo = "";
            printDroneInfo += $"Id:{Id},\n";
            printDroneInfo += $"model:{Model},\n";
            printDroneInfo += $"MaxWeight:{MaxWeight},\n";
            printDroneInfo += $"Status:{Status},\n";
            printDroneInfo += $"Battery left :{Battery},\n";
            printDroneInfo += $"Parcel:{Parcel},\n";
            printDroneInfo += $"Location:{CurrentLocation},\n";
            return printDroneInfo;
        }


    }
}
