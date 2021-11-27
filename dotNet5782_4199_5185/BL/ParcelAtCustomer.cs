using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class ParcelAtCustomer
    {
        public int Id {set;get: }
        public string Weight {set;get: }
        public string Priority {set;get: }
        public string Status {set;get: }
        public CustomerAtParcel DestOrSrc {set;get: }


             public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the weight is{Weight},\n";
            printInfo += $"the status is{Status},\n";
            printInfo += $"the priority is{Priority},\n";
            printInfo += $"the dest or src is{DestOrSrc},\n";
            return printInfo;
        }

    }
}
