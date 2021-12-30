using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class DroneAtParcel
    {
        public int Id { get; set; }
        public double Battary { get; set; }
        public Location CurrentLocation { get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"Battary:{Battary},\n";
            printInfo += $"Location:{CurrentLocation},\n";
            return printInfo;
        }
    }
}
