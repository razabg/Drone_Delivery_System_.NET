using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
     public partial class BLObject
    {
        public BaseStation DisplayStation(int id)
        {
            var stationToDisplay = AccessToDataMethods.ReturnStationList().ToList().Find(x=>x.Id == id);
            IEnumerable<IDAL.DO.DroneINCharge> DroneINChargeListDal = AccessToDataMethods.ReturnDroneChargeList().Where(x=>x.StationId == stationToDisplay.Id);
            var droneBL = ListDroneBL.FindAll(x=>x.Id == )

            List<DroneInCharging> droneInChargingList = new List<DroneInCharging>();
            foreach (var drone in DroneINChargeListDal)
            {
                    // we have to add the battery
                    droneInChargingList.Add(new DroneInCharging() { Id = drone.DroneId });
            }
            foreach (IDAL.DO.Station station in StationListDal)
            {
                if (station.Id == id)
                {
                    var b = new BaseStation()
                    {
                        Id = station.Id,
                        location = new Location(station.Longitude, station.Longitude),
                        Name = station.Name,
                        NumberOfavailableChargingStations = station.ChargeSlots - droneInChargingList.Count,
                        DroneINCharge = droneInChargingList
                    };
                    return b;
                }

            }
            //didnt find any station with this id
            throw new Exception("Not found");
        }



    }
}
