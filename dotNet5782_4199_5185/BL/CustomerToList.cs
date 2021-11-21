using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class CustomerToList
    {
        public int Id;
        public string Name;
        public int PhoneNumber;
        public Int32 NumOfParcelsThatSentAndDelivered;
        public Int32 NumOfParcelsThatSentAndNotDelivered;
        public Int32 NumOfReceviedParcels;
        public Int32 NumOfParcelsOnTheWay;

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the phone number is{PhoneNumber},\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the Name is{Name},\n";
            return printInfo;
        }


    }
}
