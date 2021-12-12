using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class Location
    {
        public Double Longitude { get; set; }
        public Double Latitude { get; set; }



        public override string ToString()
        {
            string printlocationInfo = "";
            printlocationInfo += $" the longitude is {Longitude}\n";
            printlocationInfo += $"the latitude is{Latitude},\n";

            return printlocationInfo;
        }

    }



}
