using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Dal layer enumrations.
    /// </summary>
    class DalEnum
    {
        public enum PriorityStatus { Fast = 1, Regular, Emergency };
        public enum DroneModel { Mavic_210 = 1, TELLO = 2, AirCombo = 3, Spark = 4, Strive_5 = 5 }
        public enum CustomerName { david, shlomo, brook, barak, rachel, pnina, eyal, yosi, winston, leo, ayelet, rico, raz, addie };
        public enum TopWeight { Light, Average, Heavy };
        public enum DroneStatus { Available = 1, Busy = 2, TreatmentMode = 3 }

    }
}
