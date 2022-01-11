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

        #region FIND entity
        Customer GetCustomer(int key);
        Drone GetDrone(int key);
        Parcel GetParcel(int key);
        Station GetStation(int key);
        DroneINCharge GetDroneInCharge(int key);
        #endregion

        #region UPDATE STATUS METHODS
        void UpdateRecharge(Station s, Drone d);
        void UpdateParcel(Parcel p);
        void UpdateDrone(Drone d);
        void UpdateStation(Station s);
        void UpdateCustomer(Customer c);
        void UpdateDeleteDroneInCharge(int DroneId);

        #endregion

        #region SHOW LISTS METHODS
         void show_AvailableChargingStations_list();
         void show_UnassignmentParcel_list();
        #endregion

         double[] PowerConsumptionRequestDrone();
         int ReturnParcelStatus(Parcel par);

         IEnumerable<Drone> ReturnDroneList(Func<Drone, bool> predicate = null);
         IEnumerable<Parcel> ReturnParcelList(Func<Parcel, bool> predicate = null);
         IEnumerable<DroneINCharge> ReturnDroneChargeList(Func<DroneINCharge, bool> predicate = null);
         IEnumerable<Station> ReturnStationList(Func<Station, bool> predicate = null);
         IEnumerable<Customer> ReturnCustomerList(Func<Customer, bool> predicate = null);
    }
}
