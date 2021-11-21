using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class Parcel
    {
        public int Id;
        public CustomerAtParcel sender;
        public CustomerAtParcel target;
        public string Weight;//NEED TO MAKE ENUM CLASS FOR BOTH ATTRIBUTES
        public string Priority;
        public DroneAtParcel DroneParcel;
        public DateTime TimeOfCreation;
        public DateTime PairTime;
        public DateTime CollectTime;
        public DateTime DeliveryTime;

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
