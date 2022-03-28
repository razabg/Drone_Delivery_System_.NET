using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl entity for customer
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public Location location { get; set; }
        public List<ParcelAtCustomer> FromCustomer { get; set; }
        public List<ParcelAtCustomer> ToCustomer { get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"Name:{Name},\n";
            printInfo += $"phone number :{PhoneNumber},\n";
            printInfo += $"Location :{location},\n";
            printInfo += $"List parcels that sent:{FromCustomer},\n";
            printInfo += $"List parcels that get/on the way:{ToCustomer},\n";
            return printInfo;
        }


    }
}
