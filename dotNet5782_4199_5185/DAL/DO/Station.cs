using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    /// <summary>
    /// An entetity. Include: 
    /// 1) Statition Id = also the station's key
    /// 2) The station's name 
    /// 3) Station's point on the map
    /// 4) Data about charge slots
    /// </summary>
    public struct Station
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int ChargeSlots { get; set; }

        /// <summary>
        /// Over-loading of "To String" for print the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string printStationInfo = "";
            printStationInfo += $" the Id is :{Id},\n";
            printStationInfo += $"the name is :{Name},\n";
            printStationInfo += $"Longitude :{Longitude},\n";
            printStationInfo += $"Latitude :{Latitude},\n";
            printStationInfo += $"ChargeSlots :{ChargeSlots},\n";
            return printStationInfo;
        }



    }
}

