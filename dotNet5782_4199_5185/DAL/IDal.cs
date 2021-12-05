using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;

namespace IDAL.DO
{
   public interface IDal
    {
        #region *Add Functions*
        void AddCustomer();
        void AddDrone();
        void AddParcel();
        void AddStation();
        #endregion

        #region FIND AND PRINT METHODS
        void findAndPrint_Customer(int key);
       void  findAndPrint_Drone(int key);
        void findAndPrint_Parcel(int key);
        void findAndPrint_Station(int key);
        #endregion

        #region UPDATE STATUS METHODS
        public void UpdateRecharge(Station s, Drone d);
        public void UpdateParing(int p, int d);
        public void UpdateArrived(int p);
        public void UpdatePickedUp(int p);
        #endregion

        #region SHOW LISTS METHODS
        public void show_station_list();
        public void show_drone_list();
        public void show_parcel_list();
        public void show_customer_list();
        public void show_AvailableChargingStations_list();
        public void show_UnassignmentParcel_list();
        #endregion

        IEnumerable<double> PowerConsumptionRequestDrone();

         IEnumerable<Drone> ReturnDroneList();
        
        IEnumerable<Parcel> ReturnParcelList();
      int ReturnParcelStatus(Parcel par);

    }
}
