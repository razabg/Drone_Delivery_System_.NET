using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public partial class BLObject //check if need to use the dal methods here.
    {

        public void UpdateDroneName(int droneid, string NewModel) //should i 
        {

            var index = AccessToDataMethods.ReturnDroneList().ToList().FindIndex(x => x.Id == droneid);
            
            if (index == -1)
            {
                throw new NotExistsException();
            }
            var DroneToUpdate = AccessToDataMethods.ReturnDroneList().ToList()[index];
            //used that way because the drone entity in dal is struct data type
            DroneToUpdate.Model = NewModel;
            AccessToDataMethods.ReturnDroneList().ToList()[index] = DroneToUpdate;
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
                        AccessToDataMethods.ReturnStationList().ToList()[index] = StationUpdate;//struct be value 

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
                    AccessToDataMethods.ReturnCustomerList().ToList()[index] = customerUpdate;
                }
                else if (customerName.Length > 0 && phoneNumber.Length == 0)
                {
                    customerUpdate.Name = customerName;
                    AccessToDataMethods.ReturnCustomerList().ToList()[index] = customerUpdate;
                }
                else if (customerName.Length == 0 && phoneNumber.Length > 0)
                {
                    customerUpdate.Phone = phoneNumber;
                    AccessToDataMethods.ReturnCustomerList().ToList()[index] = customerUpdate;
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
            if (!ListDroneBL.Exists(x => x.Status == statusEnum.DroneStatus.Available.ToString()))
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

           
            drone_to_charge.Battery = MinBattery;//
            drone_to_charge.CurrentLocation.Longitude = StationForCharge.Longitude;
            drone_to_charge.CurrentLocation.Latitude = StationForCharge.Latitude;
            drone_to_charge.Status = statusEnum.DroneStatus.TreatmentMode.ToString();
            //ListDroneBL[index] = drone_to_charge;
            var DalDrone = AccessToDataMethods.ReturnDroneList().ToList().Find(x => x.Id == drone_to_charge.Id);

            AccessToDataMethods.UpdateRecharge(StationForCharge, DalDrone);

        }
        public void ReleaseDroneFromCharge(int drone_id/*,double SumCharge*/)
        {
            if (!ListDroneBL.Exists(x => x.Id == drone_id))
            {
                throw new NotExistsException();
            }
            if (!ListDroneBL.Exists(x => x.Status == statusEnum.DroneStatus.TreatmentMode.ToString()))
            {
                throw new DroneIsNotAvailable(drone_id);
            }

            var DroneToRelease = ListDroneBL.Find(x => x.Id == drone_id);
            DroneToRelease.Status = statusEnum.DroneStatus.Available.ToString();
            DroneToRelease.Battery = 100;//check this because its not acurrate,need to calc the time the drone was in charge
            var DroneCharge = AccessToDataMethods.ReturnDroneChargeList().ToList().Find(x => x.DroneId == drone_id);
            var stationIndex = AccessToDataMethods.ReturnStationList().ToList().FindIndex(x => x.Id == DroneCharge.StationId);
            var station = AccessToDataMethods.ReturnStationList().ToList().Find(x => x.Id == DroneCharge.StationId);
            station.ChargeSlots++;
            AccessToDataMethods.ReturnStationList().ToList()[stationIndex] = station;//struct
            AccessToDataMethods.ReturnDroneChargeList().ToList().RemoveAll(x => x.DroneId == drone_id);


        }
        public void ParingParcelToDrone(int drone_id)
        {


            if (!ListDroneBL.Exists(x => x.Id == drone_id))
            {
                throw new NotExistsException();
            }
            if (!ListDroneBL.Exists(x => x.Status == statusEnum.DroneStatus.Available.ToString()))
            {
                throw new DroneIsNotAvailable(drone_id);


            }

            var droneToPare = ListDroneBL.Find(x => x.Id == drone_id); //we will update here the field and then we will insert it back to dal 

            //list sorted by priority
            IEnumerable<IDAL.DO.Parcel> EmergencyParcel = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.Priority == int.Parse(statusEnum.PriorityStatus.emergency.ToString())).Where(x => x.Weight == int.Parse(droneToPare.Weight));
            IEnumerable<IDAL.DO.Parcel> FastParcel = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.Priority == int.Parse(statusEnum.PriorityStatus.fast.ToString())).Where(x => x.Weight == int.Parse(droneToPare.Weight));
            IEnumerable<IDAL.DO.Parcel> RegualrParcel = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.Priority == int.Parse(statusEnum.PriorityStatus.regular.ToString())).Where(x => x.Weight == int.Parse(droneToPare.Weight));

            if (EmergencyParcel.Any())
            {
                IDAL.DO.Customer nearestCustomer = NearestParcel_SenderIdcustomer(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, EmergencyParcel);//the function returns first of all the cloesest customer for calc the distance
                var NearestParcel = EmergencyParcel.Where(x => x.SenderId == nearestCustomer.Id);//this the actual the nearset parcel
                var TargetCustomer = returnTargetCustomer(NearestParcel.First());

                IDAL.DO.Station nearestStaion = NearestStation(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList().ToList());

                #region check if the drone can pick up the parcel get to the target and then get to the station
                double DistFromCustomer = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestCustomer.Longitude, nearestCustomer.Latitude);
                double DistFromTarget = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, TargetCustomer.Longitude, TargetCustomer.Latitude);
                double DistFromStation = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestStaion.Longitude, nearestStaion.Latitude);
                double MinBattery_to_get_customer = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromCustomer;//The battery consumption that let the drone to get to the closest customer successfully
                double MinBattery_to_get_target = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromTarget;//The battery consumption that let the drone to get to the traget successfully
                double MinBattery_to_get_station = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromStation;//The battery consumption that let the drone to get to the closest station successfully
                #endregion
                if (MinBattery_to_get_customer + MinBattery_to_get_target + MinBattery_to_get_target < droneToPare.Battery)
                {
                    throw new CannotAssignDroneToParcelException(NearestParcel.First().Id);
                }
                droneToPare.Status = statusEnum.DroneStatus.Busy.ToString();
                var parcel_edit = NearestParcel.First();
                var parcelIndex = AccessToDataMethods.ReturnParcelList().ToList().FindIndex(x => x.Id == parcel_edit.Id); parcel_edit.ParingTime = DateTime.Now;
                AccessToDataMethods.ReturnParcelList().ToList()[parcelIndex] = parcel_edit;

            }
            else if (FastParcel.Any())
            {
                IDAL.DO.Customer nearestCustomer = NearestParcel_SenderIdcustomer(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, FastParcel);//the function returns first of all the cloesest customer for calc the distance
                var NearestParcel = FastParcel.Where(x => x.SenderId == nearestCustomer.Id);//this the actual the nearset parcel
                var TargetCustomer = returnTargetCustomer(NearestParcel.First());

                IDAL.DO.Station nearestStaion = NearestStation(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList().ToList());

                #region check if the drone can pick up the parcel get to the target and then get to the station
                double DistFromCustomer = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestCustomer.Longitude, nearestCustomer.Latitude);
                double DistFromTarget = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, TargetCustomer.Longitude, TargetCustomer.Latitude);
                double DistFromStation = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestStaion.Longitude, nearestStaion.Latitude);
                double MinBattery_to_get_customer = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromCustomer;//The battery consumption that let the drone to get to the closest customer successfully
                double MinBattery_to_get_target = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromTarget;//The battery consumption that let the drone to get to the traget successfully
                double MinBattery_to_get_station = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromStation;//The battery consumption that let the drone to get to the closest station successfully
                #endregion
                if (MinBattery_to_get_customer + MinBattery_to_get_target + MinBattery_to_get_target < droneToPare.Battery)
                {
                    throw new CannotAssignDroneToParcelException(NearestParcel.First().Id);
                }
                droneToPare.Status = statusEnum.DroneStatus.Busy.ToString();
                var parcel_edit = NearestParcel.First();
                var parcelIndex = AccessToDataMethods.ReturnParcelList().ToList().FindIndex(x => x.Id == parcel_edit.Id); parcel_edit.ParingTime = DateTime.Now;
                AccessToDataMethods.ReturnParcelList().ToList()[parcelIndex] = parcel_edit;
            }
            else if (RegualrParcel.Any())
            {

                IDAL.DO.Customer nearestCustomer = NearestParcel_SenderIdcustomer(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, RegualrParcel);//the function returns first of all the cloesest customer for calc the distance
                var NearestParcel = FastParcel.Where(x => x.SenderId == nearestCustomer.Id);//this the actual the nearset parcel
                var TargetCustomer = returnTargetCustomer(NearestParcel.First());

                IDAL.DO.Station nearestStaion = NearestStation(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, AccessToDataMethods.ReturnStationList().ToList());

                #region check if the drone can pick up the parcel get to the target and then get to the station
                double DistFromCustomer = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestCustomer.Longitude, nearestCustomer.Latitude);
                double DistFromTarget = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, TargetCustomer.Longitude, TargetCustomer.Latitude);
                double DistFromStation = CalcDistanceBetweenTwoCoordinates(droneToPare.CurrentLocation.Longitude, droneToPare.CurrentLocation.Latitude, nearestStaion.Longitude, nearestStaion.Latitude);
                double MinBattery_to_get_customer = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromCustomer;//The battery consumption that let the drone to get to the closest customer successfully
                double MinBattery_to_get_target = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromTarget;//The battery consumption that let the drone to get to the traget successfully
                double MinBattery_to_get_station = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(droneToPare.Weight) + 1] * DistFromStation;//The battery consumption that let the drone to get to the closest station successfully
                #endregion
                if (MinBattery_to_get_customer + MinBattery_to_get_target + MinBattery_to_get_target < droneToPare.Battery)
                {
                    throw new CannotAssignDroneToParcelException(NearestParcel.First().Id);
                }
                droneToPare.Status = statusEnum.DroneStatus.Busy.ToString();
                var parcel_edit = NearestParcel.First();
                var parcelIndex = AccessToDataMethods.ReturnParcelList().ToList().FindIndex(x => x.Id == parcel_edit.Id); parcel_edit.ParingTime = DateTime.Now;
                AccessToDataMethods.ReturnParcelList().ToList()[parcelIndex] = parcel_edit;

            }





        } //make this method more efficient by creating method that will calc the battery consumtion
        public void DroneCollectParcel(int drone_id)
        {
            if (!ListDroneBL.Exists(x => x.Id == drone_id))
            {
                throw new NotExistsException();
            }
            if (!ListDroneBL.Exists(x => x.Status == statusEnum.DroneStatus.Busy.ToString()))
            {
                throw new CannotPickUpException(drone_id);
            }
            var drone = ListDroneBL.Find(x => x.Id == drone_id);
            var parcelToPickup = AccessToDataMethods.ReturnParcelList().ToList().Find(x => x.DroneId == drone_id);
            var parcelToPickupIndex = AccessToDataMethods.ReturnParcelList().ToList().FindIndex(x => x.DroneId == drone_id);
            if (parcelToPickup.ParingTime != null && parcelToPickup.PickedUp == null)
            {
                var SenderCustomer = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcelToPickup.SenderId);
                double BatteryConsumptionToSender = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(drone.Weight) + 1] * CalcDistanceBetweenTwoCoordinates(drone.CurrentLocation.Longitude, drone.CurrentLocation.Longitude, SenderCustomer.Longitude, SenderCustomer.Latitude);

                drone.Battery -= BatteryConsumptionToSender;
                drone.IdOfParcelInTransfer = parcelToPickup.Id;
                drone.CurrentLocation.Longitude = SenderCustomer.Longitude;
                drone.CurrentLocation.Latitude = SenderCustomer.Latitude;
                parcelToPickup.PickedUp = DateTime.Now;
                AccessToDataMethods.ReturnParcelList().ToList()[parcelToPickupIndex] = parcelToPickup;

            }
            else
            {
                throw new CannotPickUpException(parcelToPickupIndex);
            }


        }
        public void DroneArrivedToDestination(int drone_id)
        {
            if (!ListDroneBL.Exists(x => x.Id == drone_id))
            {
                throw new NotExistsException();
            }
            if (!ListDroneBL.Exists(x => x.Status == statusEnum.DroneStatus.Busy.ToString()))
            {
                throw new CannotPickUpException(drone_id);
            }

            var drone = ListDroneBL.Find(x => x.Id == drone_id);
            var parcelArrived = AccessToDataMethods.ReturnParcelList().ToList().Find(x => x.DroneId == drone_id);
            var parcelToPickupIndex = AccessToDataMethods.ReturnParcelList().ToList().FindIndex(x => x.DroneId == drone_id);
            if (parcelArrived.PickedUp != null && parcelArrived.ArrivedTime == null)
            {
                var TargetCustomer = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcelArrived.TargetId);
                double BatteryConsumptionToTarget = AccessToDataMethods.PowerConsumptionRequestDrone()[int.Parse(drone.Weight) + 1] * CalcDistanceBetweenTwoCoordinates(drone.CurrentLocation.Longitude, drone.CurrentLocation.Longitude, TargetCustomer.Longitude, TargetCustomer.Latitude);

                drone.Battery -= BatteryConsumptionToTarget;
                drone.CurrentLocation.Longitude = TargetCustomer.Longitude;
                drone.CurrentLocation.Latitude = TargetCustomer.Latitude;
                drone.IdOfParcelInTransfer = null; //now the drone is empty
                parcelArrived.ArrivedTime = DateTime.Now;
                AccessToDataMethods.ReturnParcelList().ToList()[parcelToPickupIndex] = parcelArrived;

            }
            else
            {
                throw new CannotSupplyException(parcelToPickupIndex);
            }


        }

    }
}


  





