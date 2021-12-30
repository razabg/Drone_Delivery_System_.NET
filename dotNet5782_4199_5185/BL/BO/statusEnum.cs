using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class statusEnum
    {
        public enum Weight { available, light, Average, Heavy }
        public enum PriorityStatus { fast = 1, regular, emergency }
        public enum TopWeight { Light, Average, Heavy }
        public enum DroneStatus { TreatmentMode = 1, Available = 2, Busy = 3 }
        public enum ParcelStatus { Paired = 1, PickedUp = 2, Arrived = 3, created = 4 }
        public enum DroneModel { Mavic_210 = 1, TELLO = 2, AirCombo = 3, Spark = 4, Strive_5 = 5 }

    }
}
