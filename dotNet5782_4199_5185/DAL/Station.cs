using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct Station
        {
            public int Id { get; set; }
            public int Name { get; set; }
            public double Longitude { get; set; }
            public double Lattitude { get; set; }
            public int ChargeSlots { get; set; }

            public override string ToString()
            {
                string printStationInfo = "";
                printStationInfo += $" the Id is {Id},\n";
                printStationInfo += $"the name is{Name},\n";
                printStationInfo += $"Longitude {Longitude},\n";
                printStationInfo += $"Lattitude {Lattitude},\n";
                printStationInfo += $"ChargeSlots {ChargeSlots},\n";
                return printStationInfo;
            }



        }
    }
}
