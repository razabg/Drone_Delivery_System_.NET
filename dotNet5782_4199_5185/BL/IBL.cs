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
        public void DroneToCharge(int droneid);
        public IDAL.DO.Customer GetCustomerDetails(int id);
        public IDAL.DO.Station NearestStation(double longi, double lati, IEnumerable<IDAL.DO.Station> station);
        public IDAL.DO.Station NearestStationToChargeDrone(double longi, double lati, IEnumerable<IDAL.DO.Station> station);
        public void UpdateBaseStationData(int baseStationId, string baseStationName, int totalChargeSlots);
        public void UpdateCustomerData(int CustomerId, string customerName, string phoneNumber);
        public void UpdateDroneName(int droneid, string NewModel);

    }
}
