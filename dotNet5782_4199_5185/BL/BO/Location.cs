using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl entity the hold the location information
    /// </summary>
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
            string sLatit = ConvertCoordinates(Latitude), sLong = ConvertCoordinates(Longitude);    /// Converts the coordinates to be in base 60 (bonus).
            return sLatit + "N, " + sLong + "E";
        }
        /// <summary>
        /// the method convert the Location to sexagesimal representaion
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ConvertCoordinates(double number)
        {
            int sec = (int)Math.Round(number * 3600);
            int deg = sec / 3600;
            sec = Math.Abs(sec % 3600);
            int min = sec / 60;
            sec %= 60;
            return deg + "" + (char)176 + " " + min + " " + sec;
        }

    }



}
