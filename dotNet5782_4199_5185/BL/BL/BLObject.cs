using System;
using BO;
using System.Collections.Generic;
using System.Collections;
using BlApi;
using DalApi;
using System.Linq;

namespace BL
{
    internal sealed partial class BLObject : IBL
    {
        #region singelton
        public static readonly Lazy<BLObject> instance = new Lazy<BLObject>(() => new BLObject());
        static BLObject() { }// static ctor to ensure instance init is done just before first usage
        public static BLObject Instance { get => instance.Value; }// The public Instance property to use
        #endregion




        public IDal AccessToDataMethods;
        public static Random rand = new Random();
        public List<DroneToList> ListDroneBL = new List<DroneToList>();


        public double AvailableWeightConsump;
        public double LightWeightConsump;
        public double AverageWeightConsump;
        public double HeavyWeightConsump;
        public double ChargingPaceDrone;


        public BLObject() //ctor
        {
            AccessToDataMethods = DalFactory.GetDal("2");// 2 for using xml files ,1 run without xml files
            double[] PowerConsumption = AccessToDataMethods.PowerConsumptionRequestDrone();
            AvailableWeightConsump = PowerConsumption[0];
            LightWeightConsump = PowerConsumption[1];
            AverageWeightConsump = PowerConsumption[2];
            HeavyWeightConsump = PowerConsumption[3];
            ChargingPaceDrone = PowerConsumption[4];

            // init the data layer entities;
            IEnumerable<DO.Drone> DroneListDal = AccessToDataMethods.ReturnDroneList();
            IEnumerable<DO.Parcel> ParcelListDal = AccessToDataMethods.ReturnParcelList();
            IEnumerable<DO.Station> StationListDal = AccessToDataMethods.ReturnStationList();
            IEnumerable<DO.Customer> CustomerListDal = AccessToDataMethods.ReturnCustomerList();


            foreach (var item in DroneListDal)
            {
                ListDroneBL.Add(new DroneToList()
                {
                    Id = item.Id,
                    Weight = item.MaxWeight,
                    Model = item.Model,
                    CurrentLocation = new()
                });

            }

            foreach (var drone in ListDroneBL)
            {
                foreach (var parcel in ParcelListDal)
                {
                    if (parcel.DroneId == drone.Id && parcel.ArrivedTime == null)//in case the parcel is already paird but didnt arrived yet
                    {
                        drone.Status = statusEnum.DroneStatus.Busy.ToString();
                        if (parcel.ParingTime != null && parcel.PickedUp == null)
                        { //in case the parcel is already paird but didnt picked up yet
                            double senderLon = GetCustomerDetails(parcel.SenderId).Longitude;
                            double senderLat = GetCustomerDetails(parcel.SenderId).Latitude;
                            drone.CurrentLocation.Latitude = NearestStation(senderLon, senderLat, AccessToDataMethods.ReturnStationList()).Latitude;
                            drone.CurrentLocation.Longitude = NearestStation(senderLon, senderLat, AccessToDataMethods.ReturnStationList()).Longitude;
                        }
                        if (parcel.PickedUp != null && parcel.ArrivedTime == null)
                        {
                            drone.CurrentLocation.Longitude = GetCustomerDetails(parcel.SenderId).Longitude;
                            drone.CurrentLocation.Latitude = GetCustomerDetails(parcel.SenderId).Latitude;
                        }
                        double TargetLongi = GetCustomerDetails(parcel.TargetId).Longitude;
                        double TargerLatit = GetCustomerDetails(parcel.TargetId).Latitude;
                        double TargetDist = CalcDistanceBetweenTwoCoordinates(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, TargetLongi, TargerLatit);
                        double MinBattery1 = PowerConsumption[POWERindex(drone)] * TargetDist;//The battery consumption that enables the drone to supply the parcel successfully
                        Location nearestStation = new Location();
                        nearestStation.Longitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Longitude;
                        nearestStation.Latitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Latitude;
                        double MinBattery2 = AvailableWeightConsump * CalcDistanceBetweenTwoCoordinates(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, nearestStation.Longitude, nearestStation.Latitude);//The battery consumption that enables to the drone to arrive the station for charge
                        drone.Battery = Math.Round(rand.NextDouble() * (MinBattery1 + MinBattery2) + (100 - (MinBattery1 + MinBattery2)));
                    }
                }
                //If the drone is not busy

                if (drone.Status != statusEnum.DroneStatus.Busy.ToString())
                {
                    statusEnum.DroneStatus status = (statusEnum.DroneStatus)rand.Next(0, 2);
                    drone.Status = status.ToString();
                }
                if (drone.Status == statusEnum.DroneStatus.TreatmentMode.ToString())
                {

                    var RandomStation = AccessToDataMethods.ReturnStationList().ToList();
                    int index = rand.Next(RandomStation.Count);

                    drone.CurrentLocation.Longitude = RandomStation[index].Longitude;
                    drone.CurrentLocation.Latitude = RandomStation[index].Latitude;
                    drone.Battery = rand.Next(0, 21);
                    if (RandomStation[index].ChargeSlots >= AccessToDataMethods.ReturnDroneChargeList().Count(x => x.StationId == RandomStation[index].Id))
                    {
                        AccessToDataMethods.UpdateRecharge(RandomStation[index], AccessToDataMethods.ReturnDroneList().ToList().Find(x => x.Id == drone.Id),DateTime.Now);
                    }
                    else
                    {
                        DO.Station station = RandomStation[index];
                        station.ChargeSlots++;
                        AccessToDataMethods.UpdateStation(station);
                        AccessToDataMethods.UpdateRecharge(RandomStation[index], AccessToDataMethods.ReturnDroneList().ToList().Find(x => x.Id == drone.Id), DateTime.Now);
                    }



                }
                if (drone.Status == statusEnum.DroneStatus.Available.ToString())
                {
                    List<DO.Parcel> ParcelList = (List<DO.Parcel>)ParcelListDal;
                    List<DO.Parcel> ArrivedParcels = ParcelList.FindAll(x => x.ArrivedTime != null);
                    List<DO.Customer> CustomerThatReceiveParcels = new();
                    foreach (var parcel in ArrivedParcels)
                    {
                        foreach (var customer in CustomerListDal)
                        {
                            if (parcel.TargetId == customer.Id)
                            {
                                CustomerThatReceiveParcels.Add(customer);
                            }
                        }
                    }
                    if (CustomerThatReceiveParcels.Count != 0)
                    { //the list isn't empty 
                        int index = rand.Next(0, CustomerThatReceiveParcels.Count);
                        drone.CurrentLocation.Latitude = CustomerThatReceiveParcels[index].Latitude;
                        drone.CurrentLocation.Longitude = CustomerThatReceiveParcels[index].Longitude;
                    }
                    else    //rand a base station from the list and set the Location of the drone in the station
                    {
                        List<DO.Station> stations = (List<DO.Station>)StationListDal;
                        int index = rand.Next(0, stations.Count);
                        drone.CurrentLocation.Latitude = stations[index].Latitude;
                        drone.CurrentLocation.Longitude = stations[index].Longitude;

                    }

                    double DroneLatit = drone.CurrentLocation.Latitude;
                    double DroneLongit = drone.CurrentLocation.Longitude;
                    Location nearestStation = new Location();
                    nearestStation.Longitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Longitude;
                    nearestStation.Latitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Latitude;
                    double StationDist = CalcDistanceBetweenTwoCoordinates(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, nearestStation.Longitude, nearestStation.Latitude);
                    double MinBattery1 = (PowerConsumption[POWERindex(drone)] * StationDist) + 20;
                    drone.Battery = Math.Round(rand.NextDouble() * (100 - MinBattery1) + MinBattery1);

                }
            }

            
            foreach (var item in ListDroneBL)//release all the drone from charge when using xml files
            {
                if (item.Status == statusEnum.DroneStatus.TreatmentMode.ToString())
                {
                    ReleaseDroneFromCharge(item.Id);
                }

            }
            AccessToDataMethods.ResetListDroneInCharge();
            

        }
    }
}




