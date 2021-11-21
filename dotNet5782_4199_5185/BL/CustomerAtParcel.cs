using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class CustomerAtParcel
    {
        public int Id;
        public string Name;


        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Name},\n";
            return printInfo;
        }
    }
}
