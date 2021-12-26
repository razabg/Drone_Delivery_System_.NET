using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
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
            printInfo += $" the ID is :{Id}\n";
            printInfo += $"the weight is:{Weight},\n";
            printInfo += $"the priority is:{Priority},\n";
            printInfo += $"the sender parcel is:{Sender},\n";
            printInfo += $"the reciever parcel is:{Reciever},\n";
            printInfo += $"the collection location is:{ CollectionLocation},\n";
            printInfo += $"the destination location is:{DestLocation},\n";
            printInfo += $"the transport distance is:{TransportDistance},\n";
            return printInfo;
        }

    }
}
