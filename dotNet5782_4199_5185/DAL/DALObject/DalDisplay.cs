using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;


namespace DAL
{
    internal sealed partial class DALobject
    {
        #region Show methods
       
        /// <summary>
        /// run on the items of ParcelsList - checks the drone-id - and print every parcel that her droneid' isn't equal to one from the drones
        /// </summary>
        public void show_UnassignmentParcel_list()// FIX
        {
            foreach (Parcel parcel in DataSource.ParcelsList)
            {
                if (parcel.DroneId == 0)
                {
                    Console.WriteLine(parcel);
                    Console.WriteLine($"\n");
                }
            }
        }
      
        
        /// <summary>
        /// Print a list of available Charging Stations
        /// </summary>
        public void show_AvailableChargingStations_list()//FIX
        {
            foreach (Station item in DataSource.StationsList)
            {
                if (item.ChargeSlots > 0)
                {
                    Console.WriteLine(item);
                    Console.WriteLine($"\n");
                }
            }

        }
        #endregion


        #region Find and print methods
        /// <summary>
        /// Use the "key" to find a Customer and return it
        /// </summary>
        /// <param name="key"></param>
        public Customer GetCustomer(int key)
        {
            Customer customer = DataSource.CustomersList.Find(x => x.Id == key);
            if (customer.Id != 0)
            {
                return customer;
            }
            else
            {
                throw new NotExistsException();
            }
        }
        /// <summary>
        /// Use the "key" to find a station and return it
        /// </summary>
        /// <param name="key"></param>
        public Station GetStation(int key)
        {
            Station station = DataSource.StationsList.Find(x => x.Id == key);
            if (station.Id != 0)
            {
                return station;
            }
            else
            {
                throw new NotExistsException();
            }
        }
        /// <summary>
        /// Use the "key" to find a drone and return it 
        /// </summary>
        /// <param name="key"></param>
        public Drone GetDrone(int key)
        {
            Drone drone= DataSource.DronesList.Find(x => x.Id == key);
            if (drone.Id != 0)
            {
                return drone;
            }
            else
            {
                throw new NotExistsException();
            }
        }
        /// <summary>
        /// Use the "key" to find a Parcel and return it
        /// <param name="key"></param>
        public Parcel GetParcel(int key)
        {
            Parcel parcel = DataSource.ParcelsList.Find(x => x.Id == key);
            if (parcel.Id != 0)
            {
                return parcel;
            }
            else
            {
                throw new NotExistsException();
            }
        }


        public DroneINCharge GetDroneInCharge(int key)
        {
            DroneINCharge droneINCharge = DataSource.DroneChargeList.Find(x => x.DroneId == key);
            if (droneINCharge.DroneId != 0)
            {
                return droneINCharge;
            }
            else
            {
                throw new NotExistsException();
            }
        }
        #endregion

        /// <summary>
        /// Method to return drone list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Drone> ReturnDroneList(Func<Drone, bool> predicate = null)
        {
            return DataSource.DronesList;
        }
        /// <summary>
        /// Method to return parcel list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Parcel> ReturnParcelList(Func<Parcel, bool> predicate = null)
        {
            return  DataSource.ParcelsList;
        }
        /// <summary>
        /// Method to return station list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Station> ReturnStationList(Func<Station, bool> predicate = null)
        {
            return DataSource.StationsList;
        }
        /// <summary>
        /// Method to return customer list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> ReturnCustomerList(Func<Customer, bool> predicate = null)
        {
            return DataSource.CustomersList;
        }
        /// <summary>
        /// Method to return drone charge list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DroneINCharge> ReturnDroneChargeList(Func<DroneINCharge, bool> predicate = null)
        {
            return DataSource.DroneChargeList;
        }
    }

}
