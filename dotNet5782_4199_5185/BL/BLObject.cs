using System;
using IBL;
using System.Collections.Generic;
using System.Collections;


namespace IBL.BO
{
    public partial class BLObject : IBL
    {
        public IDAL.DO.IDal AccessToDataMethods;
        public static Random rand = new();
        public List<DroneToList> ListDroneBL = new List<DroneToList>();
       public List<ParcelToList> ListParcelBL = new List<ParcelToList>();


        public double AvailableWeightConsump;
        public double LightWeightConsump;
        public double AverageWeightConsump;
        public double HeavyWeightConsump;
        public double ChargingPaceDrone;


        public BLObject()
        {
            AccessToDataMethods = new DalObject.DalObject();
            double[] PowerConsumption = AccessToDataMethods.PowerConsumptionRequestDrone();
            AvailableWeightConsump = PowerConsumption[0];
            LightWeightConsump = PowerConsumption[1];
            AverageWeightConsump = PowerConsumption[2];
            HeavyWeightConsump = PowerConsumption[3];
            ChargingPaceDrone = PowerConsumption[4];

            // init the data layer entities;
            IEnumerable<IDAL.DO.Drone> DroneListDal = AccessToDataMethods.ReturnDroneList();
            IEnumerable<IDAL.DO.Parcel> ParcelListDal = AccessToDataMethods.ReturnParcelList();
            IEnumerable<IDAL.DO.Station> StationListDal = AccessToDataMethods.ReturnStationList();
            IEnumerable<IDAL.DO.Customer> CustomerListDal = AccessToDataMethods.ReturnCustomerList();


            foreach (var item in DroneListDal)
            {
                ListDroneBL.Add(new DroneToList()
                {
                    Id = item.Id,
                    Weight = item.MaxWeight,
                    Model = item.Model,
                    CurrentLocation =new(),
                });

            }

            foreach (var drone in ListDroneBL)
            {
                foreach (var parcel in ParcelListDal)
                {
                    if (parcel.DroneId == drone.Id && parcel.ArrivedTime == null)//in case the parcel is already paird but didnt arrived yet
                    {
                        drone.Status = Enum.DroneStatus.Busy.ToString();
                        if (parcel.ParingTime != null && parcel.PickedUp == null)   { //in case the parcel is already paird but didnt picked up yet
                            double senderLon = GetCustomerDetails(parcel.SenderId).Longitude;
                            double senderLat = GetCustomerDetails(parcel.SenderId).Latitude;
                            drone.CurrentLocation = ClosetStation(senderLon, senderLat, AccessToDataMethods.ReturnStationList()).Location;
                        }


                    }








                    }



                }


            }



            }







        }



    }
}
