using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class Location
    {
        public Double Longitude;
       public Double Latitude;



        public override string ToString()
        {
            string printlocationInfo = "";
            printlocationInfo += $" the longitude is {Longitude}\n";
            printlocationInfo += $"the latitude is{Latitude},\n";

            return printlocationInfo;
        }

    }

   

}
