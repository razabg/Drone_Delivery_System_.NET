﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;

namespace IBL.BO
{

    // An exceptions class for the business layer

    /// <summary>
    ///This exception will be thrown when the object isn't exist
    /// </summary>
    [Serializable]
    public class NotExistsException : Exception
    {
        public int ID;
        public NotExistsException() : base() { }
        public NotExistsException(string msg) { Console.WriteLine(msg); }
        public NotExistsException(int id, string message, Exception innerException) : base(message, innerException) => ID = ((IDAL.DO.NotExistException)innerException).ID;
        public override string ToString() => base.ToString() + $",The id does not exist";

    }

    /// <summary>
    /// This exception will be thrown when the object is already exist
    /// </summary>
    [Serializable]
    public class AlreadyExistsException : Exception
    {
        public int ID;
        public AlreadyExistsException() : base() { }
        public AlreadyExistsException(int id, string message, Exception innerException) : base(message, innerException) => ID = ((IDAL.DO.AlreadyExistsException)innerException).ID;
        public override string ToString() => base.ToString() + $", The id is already exists";

    }

    /// <summary>
    ///This Exception will be thrown when the drone cannot go to charge
    /// </summary>
    [Serializable]
    public class CannotGoToChargeException : Exception
    {
        public int DroneID;
        public CannotGoToChargeException(int id) : base() => DroneID = id;
        public CannotGoToChargeException(int id, string message) : base(message) => DroneID = id;
        public CannotGoToChargeException(int id, string message, Exception innerException) : base(message, innerException) => DroneID = id;
        public override string ToString() => base.ToString() + $", This drone cannot go to charge";

    }

    /// <summary>
    /// This Exception will be thrown when the drone cannot release from charging
    /// </summary>
    [Serializable]
    public class CannotReleaseFromChargeException : Exception
    {
        public int DroneID;
        public CannotReleaseFromChargeException(int id) : base() => DroneID = id;
        public CannotReleaseFromChargeException(int id, string message) : base(message) => DroneID = id;
        public CannotReleaseFromChargeException(int id, string message, Exception innerException) : base(message, innerException) => DroneID = id;
        public override string ToString() => base.ToString() + $", This drone cannot release from charge";

    }

    /// <summary>
    /// This Exception will be thrown when the drone cannot assign to parcel
    /// </summary>
    [Serializable]
    public class CannotAssignDroneToParcelException : Exception
    {
        public int DroneID;
        public CannotAssignDroneToParcelException(int id) : base() => DroneID = id;
        public CannotAssignDroneToParcelException(int id, string message) : base(message) => DroneID = id;
        public CannotAssignDroneToParcelException(int id, string message, Exception innerException) : base(message, innerException) => DroneID = id;
        public override string ToString() => base.ToString() + $", This drone cannot be assigned to this parcel:";
    }

    /// <summary>
    /// This Exception will be thrown when the drone is not available now from some reasons
    /// </summary>
    [Serializable]
    public class DroneIsNotAvailable : Exception
    {
        public int DroneID;
        public DroneIsNotAvailable(int id) : base() => DroneID = id;
        public DroneIsNotAvailable(int id, string message) : base(message) => DroneID = id;
        public DroneIsNotAvailable(int id, string message, Exception innerException) : base(message, innerException) => DroneID = id;
        public override string ToString() => base.ToString() + $", The drone is not available now:";
    }

    /// <summary>
    /// This Exception will be thrown when the station haven't enough charge slots 
    /// </summary>
    [Serializable]
    public class NotEnoughChargeSlotsInThisStation : Exception
    {
        public int stationId;
        public NotEnoughChargeSlotsInThisStation(int id) : base() => stationId = id;
        public NotEnoughChargeSlotsInThisStation(int id, string message) : base(message) => stationId = id;
        public NotEnoughChargeSlotsInThisStation(int id, string message, Exception innerException) : base(message, innerException) => stationId = id;
        public override string ToString() => base.ToString() + $", There are'nt enough charge slots in this station";
    }

    /// <summary>
    /// This Exception will be thrown when the drone cannot pick up a parcel from some reasons 
    /// </summary>
    [Serializable]
    public class CannotPickUpException : Exception
    {
        public int DroneID;
        public CannotPickUpException(int id) : base() => DroneID = id;
        public CannotPickUpException(string msg) { Console.WriteLine(msg); }
        public CannotPickUpException(int id, string message) : base(message) => DroneID = id;
        public CannotPickUpException(int id, string message, Exception innerException) : base(message, innerException) => DroneID = id;
        public override string ToString() => base.ToString() + $", The drone cannot pick up the parcel";
    }

    /// <summary>
    /// This Exception will be thrown when the drone cannot supply a parcel from some reasons 
    /// </summary>
    [Serializable]
    public class CannotSupplyException : Exception
    {
        public int DroneID;
        public CannotSupplyException(int id) : base() => DroneID = id;
        public CannotSupplyException(string msg) { Console.WriteLine(msg); }
        public CannotSupplyException(int id, string message) : base(message) => DroneID = id;
        public CannotSupplyException(int id, string message, Exception innerException) : base(message, innerException) => DroneID = id;
        public override string ToString() => base.ToString() + $", The drone cannot supply the parcel";
    }

    /// <summary>
    /// This Exception will be thrown when there don't have stations with free charge slots 
    /// </summary>
    [Serializable]
    public class NoStationsWithFreeChargeException : Exception
    {
        public int firstChargeStation;
        public NoStationsWithFreeChargeException() : base() { }
        public NoStationsWithFreeChargeException(int id) : base() => firstChargeStation = id;
        public NoStationsWithFreeChargeException(int id, string message) : base(message) => firstChargeStation = id;
        public NoStationsWithFreeChargeException(int id, string message, Exception innerException) : base(message, innerException) => firstChargeStation = id;
        public override string ToString() => base.ToString() + $", This station doesn't have enough slots for charge";

    }
}
