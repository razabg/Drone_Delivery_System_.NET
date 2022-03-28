using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl entity to show the customers list
    /// </summary>
    public class CustomerToList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public Int32 NumOfParcelsThatSentAndArrived { get; set; }
        public Int32 NumOfParcelsThatSentAndNotArrived { get; set; }
        public Int32 NumOfArrivedParcels { get; set; }
        public Int32 NumOfParcelsOnTheWay { get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" ID:{Id}\n";
            printInfo += $"Name:{Name},\n";
            printInfo += $"Phone number:{PhoneNumber},\n";
            printInfo += $"the Number of parcels that sent and deliverd is:{NumOfParcelsThatSentAndArrived},\n";
            printInfo += $"Number of parcels that sent and not deliverd yet:{ NumOfParcelsThatSentAndNotArrived},\n";
            printInfo += $"Number of recevied parcels is:{NumOfArrivedParcels},\n";
            printInfo += $"Number of parcels that on the way is:{NumOfParcelsOnTheWay},\n";
            return printInfo;
        }


    }
}
