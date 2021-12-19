using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public partial class BLObject
    {
        int numOfDronesInCharge = 0;
        void UpdateDroneName(int droneid, string NewModel)
        {
            List<IDAL.DO.Drone> DroneListDal = AccessToDataMethods.ReturnDroneList().ToList();
            var index = DroneListDal.FindIndex(x => x.Id == droneid);
            if (index == -1)
            {
                throw new NotExistsException();
            }
            IDAL.DO.Drone drone = DroneListDal[index]; //used that way because the drone entity in dal is struct data type
            drone.Model = NewModel;
            DroneListDal[index] = drone;
        } //update the drones model
        void UpdateBaseStationData(int baseStationId, string baseStationName, int totalChargeSlots)
        {
            List<IDAL.DO.Station> StationListDal = AccessToDataMethods.ReturnStationList().ToList();
            var StationUpdate = StationListDal.Find(x => x.Id == baseStationId);
            var index = StationListDal.FindIndex(x => x.Id == baseStationId);
            if (index == -1)
            {
                throw new NotExistsException();
            }

            {
                if (baseStationName.Length > 0 && totalChargeSlots > 0)
                {
                    numOfDronesInCharge = AccessToDataMethods.ReturnDroneChargeList().Count(x => x.StationId == baseStationId);
                    if (totalChargeSlots >= numOfDronesInCharge)
                    {
                        StationUpdate.ChargeSlots = totalChargeSlots;
                        StationUpdate.Name = int.Parse(baseStationName);

                    }
                    else
                    {
                        throw new NotEnoughChargeSlotsInThisStation(baseStationId);
                    }

                }
            }


        } // need to take care in case of charge slot or name is empty



    }



}

