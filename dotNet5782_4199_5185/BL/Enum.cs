using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    class Enum
    {
        public enum Weight { available, light, average, heavy }
        public enum PriorityStatus { fast = 1, regular, emergency }
        public enum TopWeight { Heavy = 1, Average = 2, Light = 3 }
        public enum DroneStatus { Available = 1, Busy = 2, TreatmentMode = 3 }
    }
}
