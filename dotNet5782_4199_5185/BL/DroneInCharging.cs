using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class DroneInCharging
    {
        public int Id {get;set; }
        public int Battary {get;set; }

        public override string ToString()
        {
              string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the battary status is{Battary},\n";
            return printInfo;
        }
    }
}
