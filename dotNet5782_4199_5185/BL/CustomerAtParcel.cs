using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class CustomerAtParcel
    {
        public int Id{ get; set; }
        public string Name{ get; set; }


        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is :{Id}\n";
            printInfo += $"the Name is:{Name},\n";
            return printInfo;
        }
    }
}
