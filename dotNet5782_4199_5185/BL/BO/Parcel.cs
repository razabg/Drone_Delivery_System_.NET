using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl entity of parcel
    /// </summary>
    public class Parcel
    {
        public int Id { get; set; }
        public CustomerAtParcel sender { get; set; }
        public CustomerAtParcel target { get; set; }
        public string Weight { get; set; }
        public string Priority { get; set; }
        public DroneAtParcel DroneParcel { get; set; }
        public DateTime? TimeOfCreation { get; set; }
        public DateTime? PairTime { get; set; }
        public DateTime? CollectTime { get; set; }
        public DateTime? DeliveryTime { get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"Sender:{sender},\n";
            printInfo += $"Target:{target},\n";
            printInfo += $"Weight:{Weight},\n";
            printInfo += $"Drone at parcel:{DroneParcel},\n";
            printInfo += $"Collection time:{CollectTime}\n";
            printInfo += $"Paring time:{PairTime},\n";
            printInfo += $"Creation time:{TimeOfCreation},\n";
            printInfo += $"Delivery time:{DeliveryTime},\n";

            return printInfo;
        }
    }


}

