using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class Parcel
    {
        public int Id { get; set; }
        public CustomerAtParcel sender { get; set; }
        public CustomerAtParcel target { get; set; }
        public string Weight { get; set; }//NEED TO MAKE ENUM CLASS FOR BOTH ATTRIBUTES
        public string Priority { get; set; }
        public DroneAtParcel DroneParcel { get; set; }
        public DateTime? TimeOfCreation { get; set; }
        public DateTime? PairTime { get; set; }
        public DateTime? CollectTime { get; set; }
        public DateTime? DeliveryTime { get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the sender is{sender},\n";
            printInfo += $"the target is{target},\n";
            printInfo += $"the weight is{Weight},\n";
            printInfo += $"the the drone at parcel is{DroneParcel},\n";
            printInfo += $"the collection time  is{CollectTime}\n";
            printInfo += $"the time of pairing  is{PairTime},\n";
            printInfo += $"the time of creation  is{TimeOfCreation},\n";
            printInfo += $"the time of delivery  is{DeliveryTime},\n";

            return printInfo;
        }
    }


}
}
