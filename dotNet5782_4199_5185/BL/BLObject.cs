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
                    CurrentLocation = new(),
                });

            }

            foreach (var drone in ListDroneBL)
            {
                foreach (var parcel in ParcelListDal)
                {
                    if (parcel.DroneId == drone.Id && parcel.ArrivedTime == null)//in case the parcel is already paird but didnt arrived yet
                    {
                        drone.Status = Enum.DroneStatus.Busy.ToString();
                        if (parcel.ParingTime != null && parcel.PickedUp == null)
                        { //in case the parcel is already paird but didnt picked up yet
                            double senderLon = GetCustomerDetails(parcel.SenderId).Longitude;
                            double senderLat = GetCustomerDetails(parcel.SenderId).Latitude;
                            drone.CurrentLocation.Latitude = NearestStation(senderLon, senderLat, AccessToDataMethods.ReturnStationList()).Lattitude;
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
                        double MinBattery1 = PowerConsumption[int.Parse(drone.Weight) + 1] * TargetDist;//The battery consumption that enables the drone to supply the parcel successfully
                        Location nearestStation = new Location();
                        nearestStation.Longitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Longitude;
                        nearestStation.Latitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Lattitude;
                        double MinBattery2 = AvailableWeightConsump * CalcDistanceBetweenTwoCoordinates(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, nearestStation.Longitude, nearestStation.Latitude);//The battery consumption that enables to the drone to arrive the station for charge
                        drone.Battery = Math.Round(rand.NextDouble() * (MinBattery1 + MinBattery2) + (100 - (MinBattery1 + MinBattery2)));
                    }
                }
                //If the drone is not busy
                if (drone.Status != Enum.DroneStatus.Busy.ToString())
                {
                    Enum.DroneStatus status = (Enum.DroneStatus)rand.Next(1, 2);
                    drone.Status = status.ToString();
                }
                if (drone.Status == Enum.DroneStatus.TreatmentMode.ToString())
                {
                    double longi = 0;
                    double latit = 0;
                    int count = 0;
                    foreach (var item in StationListDal)
                    {
                        count++;
                    }
                    int index = rand.Next(0, count);
                    int count2 = 0;
                    foreach (var item in StationListDal)
                    {
                        count2++;
                        if (count2 == index)
                        {
                            longi = item.Longitude;
                            latit = item.Lattitude;
                        }
                    }
                    drone.CurrentLocation.Longitude = longi;
                    drone.CurrentLocation.Latitude = latit;
                    drone.Battery = rand.Next(0, 20);

                }
                if (drone.Status == Enum.DroneStatus.Available.ToString())
                {
                    List<IDAL.DO.Parcel> ParcelList = (List<IDAL.DO.Parcel>)ParcelListDal;
                    List<IDAL.DO.Parcel> ArrivedParcels = ParcelList.FindAll(x => x.ArrivedTime != null);
                    List<IDAL.DO.Customer> CustomerThatReceiveParcels = new();
                    foreach (var parcel in ArrivedParcels)
                    {
                        foreach (var customer in CustomerThatReceiveParcels)
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
                    else    //rand a base station from the list and set the location of the drone in the station
                    {
                        List<IDAL.DO.Station> stations = (List<IDAL.DO.Station>)StationListDal;
                        int index = rand.Next(0, stations.Count);
                        drone.CurrentLocation.Latitude = stations[index].Lattitude;
                        drone.CurrentLocation.Longitude = stations[index].Longitude;

                    }

                    double DroneLatit = drone.CurrentLocation.Latitude;
                    double DroneLongit = drone.CurrentLocation.Longitude;
                    Location nearestStation = new Location();
                    nearestStation.Longitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Longitude;
                    nearestStation.Latitude = NearestStation(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList()).Lattitude;
                    double StationDist = CalcDistanceBetweenTwoCoordinates(drone.CurrentLocation.Longitude, drone.CurrentLocation.Latitude, nearestStation.Longitude, nearestStation.Latitude);
                    double MinBattery1 = PowerConsumption[int.Parse(drone.Weight) + 1] * StationDist;
                    drone.Battery = Math.Round(rand.NextDouble() * (100 - MinBattery1) + MinBattery1);

                }
            }
        }
    }
}




