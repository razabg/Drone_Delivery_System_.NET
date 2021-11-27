using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class CustomerToList
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int PhoneNumber{ get; set; }
        public Int32 NumOfParcelsThatSentAndDelivered{ get; set; }
        public Int32 NumOfParcelsThatSentAndNotDelivered{ get; set; }
        public Int32 NumOfReceviedParcels{ get; set; }
        public Int32 NumOfParcelsOnTheWay{ get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the phone number is{PhoneNumber},\n";
            printInfo += $"the number of parcels that sent and deliverd is{NumOfParcelsThatSentAndDelivered},\n";
            printInfo += $"the the number of parcels that sent and not deliverd yet is{ NumOfParcelsThatSentAndNotDelivered},\n";
            printInfo += $"the number of recevied parcels is{NumOfReceviedParcels},\n";
            printInfo += $"the number of parcels that on the way is{NumOfParcelsOnTheWay},\n";
            return printInfo;
        }


    }
}
