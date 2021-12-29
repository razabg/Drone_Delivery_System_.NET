using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Location
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Location()
        {

        }
        public Location(double longitude, double latitude)
        {
            Longitude = latitude;
            Latitude = longitude;
        }

        public override string ToString()
        {
            string printlocationInfo = "";
            printlocationInfo += $"Longitude:{Longitude}\n";
            printlocationInfo += $"Latitude:{Latitude},\n";

            return printlocationInfo;
        }

    }



}
