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

        public void AddStation(BaseStation BaseToAdd)
        {
            DO.Station station_to_list = new DO.Station();

            station_to_list.Id = BaseToAdd.Id;
            station_to_list.Latitude = BaseToAdd.Location.Latitude;
            station_to_list.Longitude = BaseToAdd.Location.Longitude;
            station_to_list.Name = BaseToAdd.Name;
            station_to_list.ChargeSlots = BaseToAdd.NumberOfavailableChargingSlots;

            BaseToAdd.DroneINCharge = new List<DroneInCharging>();//check this if its right

            try
            {
                AccessToDataMethods.AddStation(station_to_list);
            }
            catch (AlreadyExistsException ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddDrone(DroneToList DroneToBl, int StationId)
        {
            DO.Drone drone_to_list = new DO.Drone();
            DO.Station TempStation = AccessToDataMethods.ReturnStationList().ToList().Find(x => x.Id == StationId);
            drone_to_list.Id = DroneToBl.Id;
            drone_to_list.MaxWeight = DroneToBl.Weight;
            drone_to_list.Model = DroneToBl.Model;


            if (!AccessToDataMethods.ReturnStationList().ToList().Exists(x => x.Id == StationId))//check if the given station id is exist;
            {
                throw new NotExistsException();
            }

            try
            {
                AccessToDataMethods.AddDrone(drone_to_list);
                AccessToDataMethods.UpdateRecharge(TempStation, drone_to_list, DateTime.Now);
            }
            catch (AlreadyExistsException ex1)
            {
                throw ex1;
            }
            DroneToBl.CurrentLocation = new(TempStation.Longitude, TempStation.Latitude);
            DroneToBl.Battery = rand.Next(20, 40);
            DroneToBl.Status = statusEnum.DroneStatus.TreatmentMode.ToString();
            ListDroneBL.Add(DroneToBl); //the bl drone list which hold the specific drone with its Location
        }
        public void AddCustomer(Customer CustomerToAdd)
        {
            DO.Customer CustomerAdd = new DO.Customer();
            CustomerAdd.Id = CustomerToAdd.Id;
            CustomerAdd.Name = CustomerToAdd.Name;
            CustomerAdd.Phone = CustomerToAdd.PhoneNumber.ToString();
            CustomerAdd.Longitude = CustomerToAdd.location.Longitude;
            CustomerAdd.Latitude = CustomerToAdd.location.Latitude;
            try
            {
                AccessToDataMethods.AddCustomer(CustomerAdd);
            }
            catch (AlreadyExistsException ex)
            {
                Console.WriteLine(ex);
            }


        }
        public void AddParcel(Parcel ParcelToAdd)
        {
            DO.Parcel parcelToDal = new();

            parcelToDal.CreationTime = DateTime.Now;
            parcelToDal.ArrivedTime = null;
            parcelToDal.PickedUp = null;
            parcelToDal.DroneId = null;
            parcelToDal.ParingTime = null;
            parcelToDal.Id = ParcelToAdd.Id;
            parcelToDal.SenderId = ParcelToAdd.sender.Id;
            parcelToDal.TargetId = ParcelToAdd.target.Id;
            parcelToDal.Priority = ParcelToAdd.Priority;
            parcelToDal.Weight = ParcelToAdd.Weight;

            try // two exeptions checks whether the sender and target exists or not
            {
                GetCustomerDetails(ParcelToAdd.sender.Id);
            }
            catch (NotExistsException ex)
            {

                Console.WriteLine(ex);
            }
            try
            {
                GetCustomerDetails(ParcelToAdd.target.Id);
            }
            catch (NotExistsException ex)
            {

                Console.WriteLine(ex);
            }

            try
            {
                AccessToDataMethods.AddParcel(parcelToDal);
            }
            catch (AlreadyExistsException ex)
            {
                Console.WriteLine(ex);
            }

        }



    }
}
