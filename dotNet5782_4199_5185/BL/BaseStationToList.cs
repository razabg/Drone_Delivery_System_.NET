using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
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
