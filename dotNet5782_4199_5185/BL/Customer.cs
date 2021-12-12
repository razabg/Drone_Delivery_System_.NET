 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class Customer
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public int PhoneNumber{ get; set; }
        public Location location{ get; set; }
        public List<ParcelAtCustomer> FromCustomer{ get; set; }
        public List<ParcelAtCustomer> ToCustomer{ get; set; }

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
