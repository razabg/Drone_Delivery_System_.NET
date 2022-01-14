using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ParcelInTransfer
    {
        public int Id { set; get; }
        public string Weight { set; get; }
        public string Priority { set; get; }
        public CustomerAtParcel Sender { set; get; }
        public CustomerAtParcel Reciever { set; get; }
        public Location CollectionLocation { set; get; }
        public Location DestLocation { set; get; }
        public double TransportDistance { set; get; }


        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"Weight:{Weight},\n";
            printInfo += $"Priority:{Priority},\n";
            printInfo += $"Sender of the parcel:{Sender},\n";
            printInfo += $"Reciever of the parcel is:{Reciever},\n";
            printInfo += $"Collection Location:{ CollectionLocation},\n";
            printInfo += $"Destination Location:{DestLocation},\n";
            printInfo += $"Transport distance:{TransportDistance},\n";
            return printInfo;
        }

    }
}
