using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public interface Ibl
    {
        void AddCustomer(Customer CustomerToAdd);
        void AddDrone(DroneToList DroneToBl, int StationId);
        void AddParcel(Parcel ParcelToAdd);
        void AddStation(BaseStation BaseToAdd);
        double CalcDistanceBetweenTwoCoordinates(double longi1, double lati1, double longi2, double lati2);
        void DroneArrivedToDestination(int drone_id);
        void DroneCollectParcel(int drone_id);
        void DroneToCharge(int droneid);
        IDAL.DO.Customer GetCustomerDetails(int id);
        BaseStation getStationStringByID(int id);
        IDAL.DO.Customer NearestParcel_SenderIdcustomer(double longi, double lati, IEnumerable<IDAL.DO.Parcel> parceList);
        IDAL.DO.Station NearestStation(double longi, double lati, IEnumerable<IDAL.DO.Station> station);
        IDAL.DO.Station NearestStationToChargeDrone(double longi, double lati, IEnumerable<IDAL.DO.Station> station);
        void ParingParcelToDrone(int drone_id);
        void ReleaseDroneFromCharge(int drone_id);
        IDAL.DO.Customer returnTargetCustomer(IDAL.DO.Parcel parcel);
        void UpdateBaseStationData(int baseStationId, string baseStationName, int totalChargeSlots);
        void UpdateCustomerData(int CustomerId, string customerName, string phoneNumber);
        void UpdateDroneName(int droneid, string NewModel);

    }
}
