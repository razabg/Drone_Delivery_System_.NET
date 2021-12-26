using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class CustomerToList
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int PhoneNumber{ get; set; }
        public Int32 NumOfParcelsThatSentAndArrived{ get; set; }
        public Int32 NumOfParcelsThatSentAndNotArrived{ get; set; }
        public Int32 NumOfArrivedParcels{ get; set; }
        public Int32 NumOfParcelsOnTheWay{ get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the phone number is{PhoneNumber},\n";
            printInfo += $"the number of parcels that sent and deliverd is{NumOfParcelsThatSentAndArrived},\n";
            printInfo += $"the the number of parcels that sent and not deliverd yet is{ NumOfParcelsThatSentAndNotArrived},\n";
            printInfo += $"the number of recevied parcels is{NumOfArrivedParcels},\n";
            printInfo += $"the number of parcels that on the way is{NumOfParcelsOnTheWay},\n";
            return printInfo;
        }


    }
}
