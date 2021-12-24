using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class BaseStation
    {
        public int Id{ get; set; }
        public int Name{ get; set; }
        public Location location{ get; set; }
        public int NumberOfavailableChargingSlots{ get; set; }
        public IEnumerable<DroneInCharging> DroneINCharge{ get; set; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the location is{location},\n";
            printInfo += $"the list of available stations is{NumberOfavailableChargingSlots},\n";
            printInfo += $"the list of drone in charging is{DroneINCharge},\n";
            return printInfo;
        }
    }
}
