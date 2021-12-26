using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public interface Ibl
    {
        public void AddCustomer(Customer CustomerToAdd);
        public void AddDrone(DroneToList DroneToBl, int StationId);
        public void AddParcel(Parcel ParcelToAdd);
        public void AddStation(BaseStation BaseToAdd);
        public double CalcDistanceBetweenTwoCoordinates(double longi1, double lati1, double longi2, double lati2);
        public void DroneArrivedToDestination(int drone_id);
        public void DroneCollectParcel(int drone_id);
        public void DroneToCharge(int droneid);
        public IDAL.DO.Customer GetCustomerDetails(int id);
        public IDAL.DO.Customer NearestParcel_SenderIdcustomer(double longi, double lati, IEnumerable<IDAL.DO.Parcel> parceList);
        public IDAL.DO.Station NearestStation(double longi, double lati, IEnumerable<IDAL.DO.Station> station);
        public IDAL.DO.Station NearestStationToChargeDrone(double longi, double lati, IEnumerable<IDAL.DO.Station> station);
        public void ParingParcelToDrone(int drone_id);
        public void ReleaseDroneFromCharge(int drone_id);
        public IDAL.DO.Customer returnTargetCustomer(IDAL.DO.Parcel parcel);
        public void UpdateBaseStationData(int baseStationId, string baseStationName, int totalChargeSlots);
        public void UpdateCustomerData(int CustomerId, string customerName, string phoneNumber);
        public void UpdateDroneName(int droneid, string NewModel);
        public BaseStation DisplayStation(int station_id);
        public Drone DisplayDrone(int drone_id);
        public Customer DisplayCustomer(int customer_id);
        public Parcel DisplayParcel(int parcel_id);
        public IEnumerable<BaseStationToList> GetBaseStationToLists();
        public IEnumerable<DroneToList> GetDroneToLists();
        public IEnumerable<CustomerToList> GetCustomerToLists();
        public IEnumerable<ParcelToList> GetParcelToLists();
        public IEnumerable<ParcelToList> GetNotPairedParcels();


    }
}
