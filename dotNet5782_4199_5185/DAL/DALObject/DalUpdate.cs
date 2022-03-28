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
        #region Update methods
       
        /// <summary>
        /// Charging a drone. Update the drone' status & Update also the number of available ChargeSlots in the station  
        /// Make the connection by creating a new entity of DroneCharge
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        public void UpdateRecharge(Station s, Drone d,DateTime chargeTime) //need to do here exeption  
        {
            var indexStation = ReturnStationList().ToList().FindIndex(x => x.Id == s.Id);
            DroneINCharge DCharge = new DroneINCharge();
            DCharge.DroneId = d.Id;
            DCharge.StationId = s.Id;
            DCharge.ChargeTime = chargeTime;
            s.ChargeSlots--;
            DataSource.StationsList[indexStation] = s;
            DataSource.DroneChargeList.Add(DCharge);
        }

        public void UpdateCustomer(Customer c)
        {
            var indexCustomer = ReturnCustomerList().ToList().FindIndex(x => x.Id == c.Id);
            if (indexCustomer == -1)
            {
                throw new NotExistsException();
            }
            DataSource.CustomersList[indexCustomer] = c;
        }

        public void UpdateDeleteDroneInCharge(int DroneId)
        {
            var indexDrone = ReturnDroneChargeList().ToList().FindIndex(x => x.DroneId == DroneId);
            if (indexDrone == -1)
            {
                throw new NotExistsException();
            }
            DataSource.DroneChargeList.RemoveAt(indexDrone);
        }

        public void ResetListDroneInCharge()
        {
            List<DroneINCharge> listOfAllDrones = ReturnDroneChargeList().ToList();

            listOfAllDrones.Clear();
          
        }


        public void UpdateParcel(Parcel p)
        {
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p.Id);

            if (indexParcel == -1)
            {
                throw new NotExistsException();
            }
            DataSource.ParcelsList[indexParcel] = p;

        }

        public void UpdateDrone(Drone d)
        {
            var indexDrone = DataSource.ParcelsList.FindIndex(x => x.Id == d.Id);
            if (indexDrone == -1)
            {
                throw new NotExistsException();
            }
            (DataSource.DronesList[indexDrone]) = d;
        }

        public void UpdateStation(Station s)
        {
            int stationIndex = DataSource.StationsList.FindIndex(x => x.Id == s.Id);
            if (stationIndex == -1)
            {
                throw new NotExistsException();
            }
            s.ChargeSlots += 1;
            DataSource.StationsList[stationIndex] = s;
        }


            #endregion

        }

}


