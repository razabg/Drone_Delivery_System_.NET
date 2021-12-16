using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IBL.BO
{
    public partial class BLObject 
    {
        
        public void AddStation(BaseStation BaseToAdd)
        {
            IDAL.DO.Station station_to_list = new();

            station_to_list.Id = BaseToAdd.Id;
            station_to_list.Lattitude = BaseToAdd.location.Latitude;
            station_to_list.Longitude = BaseToAdd.location.Longitude;
            station_to_list.Name = BaseToAdd.Name;
            station_to_list.ChargeSlots = new();
            BaseToAdd.DroneINCharge = new List<DroneInCharging>();
            AccessToDataMethods.AddStation(station_to_list);           
        }

        public void AddParcel(Parcel ParcelToAdd)
        {
            IDAL.DO.Parcel parcel_to_add = new();
            parcel_to_add.ArrivedTime = ParcelToAdd.DeliveryTime;
            parcel_to_add.CreationTime = ParcelToAdd.TimeOfCreation;
            // parcel_to_add.DroneId = ParcelToAdd.
            parcel_to_add.Id = ParcelToAdd.Id;
            parcel_to_add.ParingTime = ParcelToAdd.PairTime;
            //parcel_to_add.PickedUp= ParcelToAdd.
            parcel_to_add.Priority = Int32.Parse(ParcelToAdd.Priority);
            parcel_to_add.SenderId = ParcelToAdd.sender.Id;
            parcel_to_add.Weight = Int32.Parse(ParcelToAdd.Weight);

            AccessToDataMethods.AddParcel(parcel_to_add);
        }



    }
}
