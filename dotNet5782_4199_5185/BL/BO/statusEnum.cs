﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// enum class using for get information for the entities
    /// </summary>
    public class statusEnum
    {
       // public enum Weight { available, Light, Average, Heavy }
        public enum PriorityStatus { Fast = 1, Regular, Emergency }
        public enum TopWeight { Light, Average, Heavy }
        public enum DroneStatus { TreatmentMode , Available , Busy  }
        public enum ParcelStatus { Paired = 1, PickedUp = 2, Arrived = 3, created = 4 }
        public enum DroneModel { Mavic_210 = 1, TELLO = 2, AirCombo = 3, Spark = 4, Strive_5 = 5 }

    }
}
