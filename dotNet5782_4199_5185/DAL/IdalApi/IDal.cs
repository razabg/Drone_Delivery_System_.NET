using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;


namespace DalApi
{
    public interface IDal
    {
        #region *Add Functions*
        void AddCustomer(Customer AddCustomer);
        void AddDrone(Drone AddDrone);
        void AddParcel(Parcel AddParcel);
        void AddStation(Station sta);
        #endregion

        #region FIND AND PRINT METHODS
        void findAndPrint_Customer(int key);
        void findAndPrint_Drone(int key);
        void findAndPrint_Parcel(int key);
        void findAndPrint_Station(int key);
        #endregion

        #region UPDATE STATUS METHODS
        public void UpdateRecharge(Station s, Drone d);
        public void UpdateParcel(Parcel p);
        public void UpdateDrone(Drone d);
        public void UpdateStation(Station s);
        public void UpdateCustomer(Customer c);
        public void UpdateDeleteDroneInCharge(int DroneId);

        #endregion

        #region SHOW LISTS METHODS
        public void show_station_list();
        public void show_drone_list();
        public void show_parcel_list();
        public void show_customer_list();
        public void show_AvailableChargingStations_list();
        public void show_UnassignmentParcel_list();
        #endregion

        public double[] PowerConsumptionRequestDrone();
        public int ReturnParcelStatus(Parcel par);

        public IEnumerable<Drone> ReturnDroneList();
        public IEnumerable<Parcel> ReturnParcelList();
        public IEnumerable<DroneINCharge> ReturnDroneChargeList();
        public IEnumerable<Station> ReturnStationList();
        public IEnumerable<Customer> ReturnCustomerList();
    }
}
