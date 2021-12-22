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
            IDAL.DO.Station station_to_list = new IDAL.DO.Station();

            station_to_list.Id = BaseToAdd.Id;
            station_to_list.Latitude = BaseToAdd.location.Latitude;
            station_to_list.Longitude = BaseToAdd.location.Longitude;
            station_to_list.Name = BaseToAdd.Name;
            station_to_list.ChargeSlots = new();

            BaseToAdd.DroneINCharge = new List<DroneInCharging>();

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
            IDAL.DO.Drone drone_to_list = new IDAL.DO.Drone();
            IDAL.DO.Station TempStation = AccessToDataMethods.ReturnStationList().ToList().Find(x => x.Id == StationId);
            drone_to_list.Id = DroneToBl.Id;
            drone_to_list.MaxWeight = DroneToBl.Weight;
            drone_to_list.Model = DroneToBl.Model;


            if (!AccessToDataMethods.ReturnStationList().ToList().Exists(x => x.Id == StationId))//check if the given station id is exist;
            {
                throw new AlreadyExistsException();
            }

            try
            {
                AccessToDataMethods.AddDrone(drone_to_list);
            }
            catch (AlreadyExistsException ex1)
            {

                Console.WriteLine(ex1); ;
            }
            DroneToBl.CurrentLocation = new(TempStation.Longitude, TempStation.Latitude);
            DroneToBl.Battery = rand.Next(20, 40);
            DroneToBl.Status = Enum.DroneStatus.TreatmentMode.ToString();
            ListDroneBL.Add(DroneToBl); //the bl drone list which hold the specific drone with its location
        }
        public void AddCustomer(Customer CustomerToAdd)
        {
            IDAL.DO.Customer CustomerAdd = new IDAL.DO.Customer();
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
            IDAL.DO.Parcel parcelToDal = new();

            parcelToDal.CreationTime = DateTime.Now;
            parcelToDal.ArrivedTime = null;
            parcelToDal.PickedUp = null;
            parcelToDal.DroneId = null;
            parcelToDal.ParingTime = null;
            parcelToDal.Id = ParcelToAdd.Id;
            parcelToDal.SenderId = ParcelToAdd.sender.Id;
            parcelToDal.TargetId = ParcelToAdd.target.Id;
            parcelToDal.Priority = int.Parse(ParcelToAdd.Priority);
            parcelToDal.Weight = int.Parse(ParcelToAdd.Weight);

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
