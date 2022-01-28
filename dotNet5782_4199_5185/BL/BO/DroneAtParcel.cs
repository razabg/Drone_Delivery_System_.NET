using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class DroneAtParcel
    {
        public int Id { get; set; }
        public double Battery { get; set; }
        public Location CurrentLocation { get; set; }

        public DroneAtParcel() { }
        public DroneAtParcel(int id, double battery, Location location)
        {
            Id = id;
            Battery = battery;
            CurrentLocation = location;
        }

        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"Battery:{Battery},\n";
            printInfo += $"Location:{CurrentLocation},\n";
            return printInfo;
        }
    }
}
