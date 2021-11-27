using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class StationBaseToList
    {
        public int Id {  set; get;}
        public string Name{  set; get;}
        public int NumOfAvailableChargingStations{  set; get;}
        public int NumOfUnavailableChargingStations{  set; get;}

        public override string ToString()
        {
             string printInfo = "";
            printInfo += $" the ID is {Id}\n";
            printInfo += $"the name is{Name},\n";
              printInfo += $"the number of available charging stations is{NumOfAvailableCharghingStations},\n";
              printInfo += $"the number of unavailable charging stations is{NumOfUnavailableCharghingStations},\n";
            return printInfo;
        }

    }
}
