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
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        /// <param name="key"></param>
        public void show_customer_list()
        {

            foreach (Customer item in DataSource.CustomersList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public void show_parcel_list()
        {
            foreach (Parcel item in DataSource.ParcelsList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }
        /// <summary>
        /// run on the items of ParcelsList - checks the drone-id - and print every parcel that her droneid' isn't equal to one from the drones
        /// </summary>
        public void show_UnassignmentParcel_list()
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
        /// /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public void show_drone_list()
        {
            foreach (Drone item in DataSource.DronesList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public void show_station_list()
        {
            foreach (Station item in DataSource.StationsList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }
        /// <summary>
        /// Print a list of available Charging Stations
        /// </summary>
        public void show_AvailableChargingStations_list()
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
        /// Use the "key" to find a Customer and print his data
        /// </summary>
        /// <param name="key"></param>
        public void findAndPrint_Customer(int key)
        {
            Customer ForPrint = DataSource.CustomersList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// Use the "key" to find a station and print his data
        /// </summary>
        /// <param name="key"></param>
        public void findAndPrint_Station(int key)
        {
            Station ForPrint = DataSource.StationsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// Use the "key" to find a drone and print his data
        /// </summary>
        /// <param name="key"></param>
        public void findAndPrint_Drone(int key)
        {
            Drone ForPrint = DataSource.DronesList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// Use the "key" to find a Parcel and print his data
        /// </summary>
        /// <param name="key"></param>
        public void findAndPrint_Parcel(int key)
        {
            Parcel ForPrint = DataSource.ParcelsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        #endregion

        /// <summary>
        /// Method to return drone list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Drone> ReturnDroneList()
        {
            return DataSource.DronesList;
        }
        /// <summary>
        /// Method to return parcel list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Parcel> ReturnParcelList()
        {
            return DataSource.ParcelsList;
        }
        /// <summary>
        /// Method to return station list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Station> ReturnStationList()
        {
            return DataSource.StationsList;
        }
        /// <summary>
        /// Method to return customer list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> ReturnCustomerList()
        {
            return DataSource.CustomersList;
        }
        /// <summary>
        /// Method to return drone charge list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DroneINCharge> ReturnDroneChargeList()
        {
            return DataSource.DroneChargeList;
        }
    }

}
