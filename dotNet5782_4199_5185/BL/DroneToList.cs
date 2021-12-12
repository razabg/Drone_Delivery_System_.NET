using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class DroneToList
    {
        public int Id{ get; set; }
        public string Model{ get; set; }
        public string Weight{ get; set; }
        public double Battery{ get; set; }
        public string Status{ get; set; }
        public Location CurrentLocation{ get; set; }
        public int IdOfParcelInTransfer {get;set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Model},\n";
            printInfo += $"the weight is{Weight},\n";
            printInfo += $"the battary status is{Battery},\n";
            printInfo += $"the status is{Status},\n";
            printInfo += $"the location is{CurrentLocation},\n";
            printInfo += $"the id of the parcel in transport is{IdOfParcelInTransfe},\n";
            return printInfo;
        }

    }
}
