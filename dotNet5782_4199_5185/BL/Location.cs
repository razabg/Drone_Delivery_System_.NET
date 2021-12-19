﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
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
            printlocationInfo += $" the longitude is {Longitude}\n";
            printlocationInfo += $"the latitude is{Latitude},\n";

            return printlocationInfo;
        }

    }



}
