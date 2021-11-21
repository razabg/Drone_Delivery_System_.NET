using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class BaseStation
    {
        public int Id;
        public int Name;
        public Location location;
        public int NumberOfavailableChargingStations;
        public List<DroneInCharging> DroneINCharge;

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the Name is{Name},\n";
            printInfo += $"the location is{location},\n";
            printInfo += $"the list of available stations is{NumberOfavailableChargingStations},\n";
            printInfo += $"the list of drone in charging is{DroneINCharge},\n";
            return printInfo;
        }
    }
}
