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
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the name is{Name},\n";
            printInfo += $"the number of available charging stations is{NumOfAvailableChargingSlots},\n";
            printInfo += $"the number of unavailable charging stations is{NumOfUnavailableChargingSlots},\n";
            return printInfo;
        }

    }
}
