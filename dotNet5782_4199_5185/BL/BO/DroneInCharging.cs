using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl entity of drone in charge
    /// </summary>
    public class DroneInCharging
    {
        public int Id { get; set; }
        public double Battery { get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"Battery:{Battery},\n";
            return printInfo;
        }
    }
}
