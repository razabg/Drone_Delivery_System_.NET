using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ParcelAtCustomer
    {
        public int Id { set; get; }
        public string Weight { set; get; }
        public string Priority { set; get; }
        public string Status { set; get; }
        public CustomerAtParcel DestOrSrc { set; get; }




        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"Weight:{Weight},\n";
            printInfo += $"Status:{Status},\n";
            printInfo += $"Priority:{Priority},\n";
            printInfo += $"Dest or src:{DestOrSrc},\n";
            return printInfo;
        }

    }
}
