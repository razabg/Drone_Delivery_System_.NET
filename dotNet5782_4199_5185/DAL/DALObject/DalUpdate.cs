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
        /// Pairing parcel to drone & Update the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdateParing(Parcel p, int d) //
        {
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p.Id);
            
            if ( indexParcel == -1)
            {
                throw new Exception("the parcel is not here"); //
            }
            //in order to update the idrone in parcel.droneid we used helper to get the right id .
            (DataSource.ParcelsList[indexParcel]) = p;


        }

        /// <summary>
        /// Charging a drone. Update the drone' status & Update also the number of available ChargeSlots in the station  
        /// Make the connection by creating a new entity of DroneCharge
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        public void UpdateRecharge(Station s, Drone d) //need to do here exeption  
        {
            var indexStation = ReturnStationList().ToList().FindIndex(x => x.Id == s.Id);
            DroneINCharge DCharge = new DroneINCharge();
            DCharge.DroneId = d.Id;
            DCharge.StationId = s.Id;
            s.ChargeSlots--;
            DataSource.StationsList[indexStation] = s;
            DataSource.DroneChargeList.Add(DCharge);
        }

        /// <summary>
        /// Update the time - when the drone picked the parcel
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdatePickedUp(int p)
        {
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p);
            if (indexParcel == -1)
            {
                return;
            }
            Parcel helper = (DataSource.ParcelsList[indexParcel]); //in order to update the idrone in parcel.droneid we used helper to get the right id .
            helper.PickedUp = DateTime.Now;
            (DataSource.ParcelsList[indexParcel]) = helper;
        }

        /// <summary>
        /// Update the time - when the parcel dalivary & Update also the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdateArrived(int p)
        {
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p);

            if (indexParcel == -1)
            {
                return;
            }
            Parcel helper = (DataSource.ParcelsList[indexParcel]);
            helper.ArrivedTime = DateTime.Now; //update the arrival time of the parcel
            (DataSource.ParcelsList[indexParcel]) = helper;

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
        public void UpdateStation(Station stationTemp)
        {
            int stationIndex = DataSource.StationsList.FindIndex(x => x.Id == stationTemp.Id);
            if (stationIndex == -1)
            {
                throw new NotExistsException();
            }
            DataSource.StationsList[stationIndex] = stationTemp;
        }


            #endregion

        }

}


