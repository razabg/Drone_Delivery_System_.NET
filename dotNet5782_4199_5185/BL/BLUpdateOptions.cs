using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public partial class BLObject
    {

        public void UpdateDroneName(int droneid, string NewModel) //shuld i 
        {
            List<IDAL.DO.Drone> DroneListDal = AccessToDataMethods.ReturnDroneList().ToList();
            var index = DroneListDal.FindIndex(x => x.Id == droneid);
            if (index == -1)
            {
                throw new NotExistsException();
            }
            IDAL.DO.Drone drone = DroneListDal[index]; //used that way because the drone entity in dal is struct data type
            drone.Model = NewModel;
            DroneListDal[index] = drone;
        } //update the drones model
        public void UpdateBaseStationData(int baseStationId, string baseStationName, int totalChargeSlots)
        {
            int numOfDronesInCharge = 0;
            List<IDAL.DO.Station> StationListDal = AccessToDataMethods.ReturnStationList().ToList();
            var StationUpdate = StationListDal.Find(x => x.Id == baseStationId);
            var index = StationListDal.FindIndex(x => x.Id == baseStationId);
            if (index == -1)
            {
                throw new NotExistsException();
            }

            {
                if (baseStationName.Length > 0 && totalChargeSlots > 0)
                {
                    numOfDronesInCharge = AccessToDataMethods.ReturnDroneChargeList().Count(x => x.StationId == baseStationId);
                    if (totalChargeSlots >= numOfDronesInCharge)
                    {
                        StationUpdate.ChargeSlots = totalChargeSlots;
                        StationUpdate.Name = int.Parse(baseStationName);

                    }   // need to take care in case of charge slot or name is empty
                    else
                    {
                        throw new NotEnoughChargeSlotsInThisStation(baseStationId);
                    }

                }
            }


        }
        public void UpdateCustomerData(int CustomerId, string customerName, string phoneNumber)
        {
            List<IDAL.DO.Customer> StationListDal = AccessToDataMethods.ReturnCustomerList().ToList();
            var customerUpdate = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == CustomerId);
            var index = AccessToDataMethods.ReturnCustomerList().ToList().FindIndex(x => x.Id == CustomerId);
            if (index == -1)
            {
                throw new NotExistsException();
            }
            try
            {
                if (customerName.Length > 0 && phoneNumber.Length < 0)
                {
                    customerUpdate.Name = customerName;
                    customerUpdate.Phone = phoneNumber;
                }
                else if (customerName.Length > 0 && phoneNumber.Length == 0)
                {
                    customerUpdate.Name = customerName;
                }
                else if (customerName.Length == 0 && phoneNumber.Length > 0)
                {
                    customerUpdate.Phone = phoneNumber;
                }
                else
                {
                    throw new NotExistsException("input is empty");
                }
            }
            catch
            {
                Console.WriteLine("input is empty");
            }

        }
        public void DroneToCharge(int droneid)
        {
            if (!ListDroneBL.Exists(x => x.Id == droneid))
            {
                throw new NotExistsException();
            }
            if (!ListDroneBL.Exists(x => x.Status == Enum.DroneStatus.Available.ToString()))
            {
                throw new DroneIsNotAvailable(droneid);
            }
            int index = ListDroneBL.FindIndex(x => x.Id == droneid);
            DroneToList drone_to_charge = ListDroneBL.Find(x => x.Id == droneid);
            IDAL.DO.Station StationForCharge = NearestStationToChargeDrone(drone_to_charge.CurrentLocation.Longitude, drone_to_charge.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList().ToList());
            double DistFromStation = CalcDistanceBetweenTwoCoordinates(drone_to_charge.CurrentLocation.Longitude, drone_to_charge.CurrentLocation.Latitude, StationForCharge.Longitude, StationForCharge.Latitude);
            double MinBattery = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(drone_to_charge.Weight) + 1] * DistFromStation;//The battery consumption that let the drone to get to station  successfully

            if (drone_to_charge.Battery < MinBattery)// check if there is enough battery to get the station
            {
                throw new CannotGoToChargeException(droneid);
            }


            drone_to_charge.Battery = MinBattery;// is it ok? reference? will the insert the value onto the list
            drone_to_charge.CurrentLocation.Longitude = StationForCharge.Longitude;
            drone_to_charge.CurrentLocation.Latitude = StationForCharge.Latitude;
            drone_to_charge.Status = Enum.DroneStatus.TreatmentMode.ToString();
            ListDroneBL[index] = drone_to_charge;
            var DalDrone = AccessToDataMethods.ReturnDroneList().ToList().Find(x => x.Id == drone_to_charge.Id);

            AccessToDataMethods.UpdateRecharge(StationForCharge, DalDrone);//check if we need list of drone charge

        }
        void ReleaseDroneFromCharge(int drone_id/*,double SumCharge*/)
        {
            if (!ListDroneBL.Exists(x => x.Id == drone_id))
            {
                throw new NotExistsException();
            }
            if (!ListDroneBL.Exists(x => x.Status == Enum.DroneStatus.TreatmentMode.ToString()))
            {
                throw new DroneIsNotAvailable(drone_id);
            }

            var DroneToRelease = ListDroneBL.Find(x => x.Id == drone_id);
            DroneToRelease.Status = Enum.DroneStatus.Available.ToString();
            DroneToRelease.Battery = 100;//check this because its not acurrate,need to calc the time the drone was in charge
            var DroneCharge = AccessToDataMethods.ReturnDroneChargeList().ToList().Find(x => x.DroneId == drone_id);
            var stationIndex = AccessToDataMethods.ReturnStationList().ToList().FindIndex(x => x.Id == DroneCharge.StationId);
            var station = AccessToDataMethods.ReturnStationList().ToList().Find(x => x.Id == DroneCharge.StationId);
            station.ChargeSlots++;
            AccessToDataMethods.ReturnStationList().ToList()[stationIndex] = station;//struct
            AccessToDataMethods.ReturnDroneChargeList().ToList().RemoveAll(x => x.DroneId == drone_id);


        }

        void ParingParcelToDrone(int drone_id)
        {
            if (!ListDroneBL.Exists(x => x.Id == drone_id))
            {
                throw new NotExistsException();
            }
            if (!ListDroneBL.Exists(x => x.Status == Enum.DroneStatus.Available.ToString()))
            {
                throw new DroneIsNotAvailable(drone_id);


            }

            var droneToPare = ListDroneBL.Find(x => x.Id == drone_id);

            //list sorted by priority
            IEnumerable<IDAL.DO.Parcel> EmergencyParcel = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.Priority == int.Parse(Enum.PriorityStatus.emergency.ToString())).Where(x => x.Weight == int.Parse(droneToPare.Weight));
            IEnumerable<IDAL.DO.Parcel> FastParcel = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.Priority == int.Parse(Enum.PriorityStatus.fast.ToString())).Where(x => x.Weight == int.Parse(droneToPare.Weight));
            IEnumerable<IDAL.DO.Parcel> RegualrParcel = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.Priority == int.Parse(Enum.PriorityStatus.regular.ToString())).Where(x => x.Weight == int.Parse(droneToPare.Weight));

            if (EmergencyParcel.Any())
            {
                IDAL.DO.Customer nearestCustomer = NearestParcel_customer(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude,EmergencyParcel);//the function returns first of all the cloesest customer for calc the distance
                var NearestParcel = EmergencyParcel.Where(x => x.SenderId == nearestCustomer.Id);//this the actual the nearset parcel
                IDAL.DO.Station nearestStaion = NearestStation(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList().ToList());


                double DistFromCustomer = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestCustomer.Longitude, nearestCustomer.Latitude);
                double DistFromTarget = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestCustomer.Longitude, nearestCustomer.Latitude);
                double DistFromStation = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestStaion.Longitude, nearestStaion.Latitude);
                double MinBattery_to_get_customer = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromCustomer;//The battery consumption that let the drone to get to the closest customer successfully
                double MinBattery_to_get_target = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromCustomer;//The battery consumption that let the drone to get to the traget successfully
                double MinBattery_to_get_station = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromCustomer;//The battery consumption that let the drone to get to the closest station successfully

            }





        }




    }




}





