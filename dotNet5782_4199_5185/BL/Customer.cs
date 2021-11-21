using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class Customer
    {
        public int Id ;
        public string Name;
        public int PhoneNumber;
        public Location location;
        public List<ParcelAtCustomer> FromCustomer;
        public List<ParcelAtCustomer> ToCustomer;

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the phone number is{PhoneNumber},\n";
            printInfo += $"the location is{location},\n";
            printInfo += $"the list of customers at client (from) is{FromCustomer},\n";
            printInfo += $"the list of customers at client (to) is{ToCustomer},\n";
            return printInfo;
        }


    }
}
