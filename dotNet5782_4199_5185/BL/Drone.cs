using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
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
            printDroneInfo += $" the Id is {Id},\n";
            printDroneInfo += $"the model is{Model},\n";
            printDroneInfo += $"the MaxWeight is{MaxWeight},\n";
            printDroneInfo += $"the Status is {Status},\n";
            printDroneInfo += $"Battary left {Battery},\n";
            printDroneInfo += $"Parcel  {Parcel},\n";
            printDroneInfo += $"the location is {CurrentLocation},\n";
            return printDroneInfo;
        }


    }
}
