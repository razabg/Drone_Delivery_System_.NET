using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl entity to show to list of stations
    /// </summary>
    public class BaseStationToList
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int NumOfAvailableChargingSlots { set; get; }
        public int NumOfUnavailableChargingSlots { set; get; }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $" Name:{Name},\n";
            printInfo += $" Available Charging Stations :{NumOfAvailableChargingSlots},\n";
            printInfo += $" Unavailable Charging Stations :{NumOfUnavailableChargingSlots},\n";
            return printInfo;
        }

    }
}
