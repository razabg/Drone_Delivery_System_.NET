using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct DroneINCharge
        {
            public int DroneId { get; set; }
            public int StationId { get; set; }

            public override string ToString()
            {
                string printChargeInfo = "";
                printChargeInfo += $" the DroneId is {DroneId},\n";
                printChargeInfo += $"the StationId is{StationId},\n";
                return printChargeInfo;
            }

        }

    }
}
