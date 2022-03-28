using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;

namespace BL
{
    internal sealed partial class BLObject
    {
        /// <summary>
        /// the method provide info about certain customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DO.Customer GetCustomerDetails(int id)
        {
            List<DO.Customer> CustomerListDal = AccessToDataMethods.ReturnCustomerList().ToList();
            int index = CustomerListDal.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                throw new NotExistsException();
            }
            return CustomerListDal[index];
        }
        /// <summary>
        /// calc distance between two locations
        /// </summary>
        /// <param name="longi1"></param>
        /// <param name="lati1"></param>
        /// <param name="longi2"></param>
        /// <param name="lati2"></param>
        /// <returns></returns>
        public double CalcDistanceBetweenTwoCoordinates(double longi1, double lati1, double longi2, double lati2)
        {
            double distance = Math.Sqrt(Math.Pow(longi2 - longi1, 2) + Math.Pow(lati2 - lati1, 2));
            
            return distance*10;

        }
        /// <summary>
        /// the method check the parcel status according to its time;
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></returns>
        public string parcelStatus(DO.Parcel parcel)
        {
            if (parcel.ArrivedTime != null)
            {
                return statusEnum.ParcelStatus.Arrived.ToString();
            }
            else if (parcel.PickedUp != null)
            {
                return statusEnum.ParcelStatus.PickedUp.ToString();
            }
            else if (parcel.ParingTime != null)
            {
                return statusEnum.ParcelStatus.Paired.ToString();
            }

            return statusEnum.ParcelStatus.created.ToString();



        }
        /// <summary>
        /// the method look for the nearest station
        /// </summary>
        /// <param name="longi"></param>
        /// <param name="lati"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        public DO.Station NearestStation(double longi, double lati, IEnumerable<DO.Station> station)
        {
            double MinDist = CalcDistanceBetweenTwoCoordinates(longi, lati, station.First().Longitude, station.First().Latitude);
            DO.Station StationToReturn = station.First();
            foreach (var item in station)
            {
                double temp = CalcDistanceBetweenTwoCoordinates(longi, lati, item.Longitude, item.Latitude);
                if (MinDist > temp)
                {
                    MinDist = temp;
                    StationToReturn = item;
                }
            }
            return StationToReturn;

        }
        /// <summary>
        ///  the method look for the nearest station that is available for charging
        /// </summary>
        /// <param name="longi"></param>
        /// <param name="lati"></param>
        /// <param name="station"></param>
        /// <returns></returns>
        public DO.Station NearestStationToChargeDrone(double longi, double lati, IEnumerable<DO.Station> station)
        {

            double MinDist = CalcDistanceBetweenTwoCoordinates(longi, lati, station.First().Longitude, station.First().Latitude);
            bool flag = true;
            List<DO.Station> StationToskip = new List<DO.Station>();
            DO.Station StationToReturn = station.First();
            while (flag == true) //iterate on the stations list until we will find the nearest station that has free charge slot
            {
                foreach (var item in station)
                {
                    double temp = CalcDistanceBetweenTwoCoordinates(longi, lati, item.Longitude, item.Latitude);
                    if (MinDist > temp)
                    {
                        if (!StationToskip.Contains(item)) //it the specific item is on the "black" list which contains the full stations skip to the next station
                        {
                            MinDist = temp;
                            StationToReturn = item;
                        }

                    }
                }
                int numOfDronesInCharge = AccessToDataMethods.ReturnDroneChargeList().Count(x => x.StationId == StationToReturn.Id);// num of the drones that getting charged in the station
                if (numOfDronesInCharge < StationToReturn.ChargeSlots) // if the station has room for another drone
                {
                    return StationToReturn;
                    //flag = false; //stop the outer while loop
                }
                else if (numOfDronesInCharge >= StationToReturn.ChargeSlots)  // if there is no room in the station add the station to the "black list
                {
                    StationToskip.Add(StationToReturn);
                    // flag = true;
                }
                else if (StationToskip.Equals(station))
                {
                    throw new NoStationsWithFreeChargeException();
                }

            }
            return StationToReturn;
        }
        /// <summary>
        /// the method look for the nearest parcel to be collected
        /// </summary>
        /// <param name="longi"></param>
        /// <param name="lati"></param>
        /// <param name="parceList"></param>
        /// <returns></returns>
        public DO.Customer NearestParcel_SenderIdcustomer(double longi, double lati, IEnumerable<DO.Parcel> parceList)
        {
            List<DO.Customer> SenderOfTheParcel = new List<DO.Customer>();//this list going to contain the customers so that we will know the Location of the parcels
            List<DO.Parcel> helpList = parceList.ToList();//help us in the end to extract the closest parcel

            foreach (var parcel in parceList)
            {
                foreach (var customer in AccessToDataMethods.ReturnCustomerList())
                {
                    if (parcel.SenderId == customer.Id)
                    {
                        SenderOfTheParcel.Add(customer);//build a new list of customers that contained the locations of the parcel list in the parameters;
                    }//with this list can calc and finf the closest parcel to our drone

                }

            }

            double MinDist = CalcDistanceBetweenTwoCoordinates(longi, lati, SenderOfTheParcel.First().Longitude, SenderOfTheParcel.First().Latitude);
            DO.Customer customerToReturn = SenderOfTheParcel.First();
            foreach (var item in SenderOfTheParcel)
            {
                double temp = CalcDistanceBetweenTwoCoordinates(longi, lati, item.Longitude, item.Latitude);
                if (MinDist > temp)
                {
                    MinDist = temp;
                    customerToReturn = item;
                }
            }


            var parcelToReturn = helpList.Find(x => x.SenderId == customerToReturn.Id);//we find parcel that hold the sender-customer id which he is the closest parcel to the drone

            //return parcelToReturn;
            return customerToReturn;


        }


        /// <summary>
        /// the method return the dest customer
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></returns>
        public DO.Customer returnTargetCustomer(DO.Parcel parcel)
        {
            return AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcel.TargetId);
        }
        /// <summary>
        /// the method return the right index for the calc of battery cunsumption
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public int POWERindex(DroneToList check)
        {
            if (check.Weight == statusEnum.TopWeight.Light.ToString())
            {
                return 1;
            }
            if (check.Weight == statusEnum.TopWeight.Average.ToString())
            {
                return 2;
            }
            if (check.Weight == statusEnum.TopWeight.Heavy.ToString())
            {
                return 3;
            }
            return 0;

        }
        /// <summary>
        /// the method calc the battery consumption
        /// </summary>
        /// <param name="drone"></param>
        /// <returns></returns>
        public double CalcBattery(DroneToList drone)
        {
            double pace = AccessToDataMethods.PowerConsumptionRequestDrone().Last();//the pace of charging
            double timeDifference = (DateTime.Now - (DateTime)AccessToDataMethods.GetDroneInCharge(drone.Id).ChargeTime).TotalSeconds;// how much time has passed
            drone.Battery += pace * timeDifference;//how much the battert should be


            if (drone.Battery > 100)
                return 100;


            return drone.Battery;


        }


    }

}
