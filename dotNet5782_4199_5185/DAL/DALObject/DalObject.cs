using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DalApi;



namespace DAL
{
    internal sealed partial class DALobject : IDal
    {
        //bonus lazy init
        #region singelton 
        public static readonly Lazy<DALobject> instance = new Lazy<DALobject>(() => new DALobject());//the "lazy" init made to improve the performance.the creation is deferred until it is first used
        static DALobject() { }// static ctor to ensure instance init is done just before first usage
        DALobject() { DataSource.Initialize(); } // default => private
        public static DALobject Instance { get => instance.Value; }// The public Instance property to use
        #endregion
         

        /// <summary>
        /// Pairing parcel to drone & Update the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdateParing(int p, int d) //
        {
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p);
            var indexDrone = DataSource.DronesList.FindIndex(x => x.Id == d);
            if (indexDrone != -1 && indexParcel != -1)
            {
                return; //
            }
            Parcel helper = (DataSource.ParcelsList[indexParcel]); //in order to update the idrone in parcel.droneid we used helper to get the right id .
            helper.DroneId = DataSource.DronesList[indexDrone].Id;
            helper.ParingTime = DateTime.Now;
            (DataSource.ParcelsList[indexParcel]) = helper;


        }

        /// <summary>
        /// Update the time - when the drone picked the parcel
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdatePickedUp(int p)
        {
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p);
            if (indexParcel != -1)
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

            if (indexParcel != -1)
            {
                return;
            }
            Parcel helper = (DataSource.ParcelsList[indexParcel]);
            helper.ArrivedTime = DateTime.Now; //update the arrival time of the parcel
            (DataSource.ParcelsList[indexParcel]) = helper;

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
            DroneINCharge DCharge = default;
            DCharge.DroneId = d.Id;
            DCharge.StationId = s.Id;
            s.ChargeSlots--;
            DataSource.StationsList[indexStation] = s;
            ReturnDroneChargeList().ToList().Add(DCharge);

        }

        public double[] PowerConsumptionRequestDrone()
        {
            double[] arr = new double[] { DataSource.Config.Available, DataSource.Config.Light, DataSource.Config.Average, DataSource.Config.Heavy, DataSource.Config.ChargingPaceDrone };

            return arr;
        }


        public IEnumerable<Drone> ReturnDroneList()
        {
            return DataSource.DronesList;
        }

        public IEnumerable<Parcel> ReturnParcelList()
        {
            return DataSource.ParcelsList;
        }

        public IEnumerable<Station> ReturnStationList()
        {
            return DataSource.StationsList;
        }
        public IEnumerable<Customer> ReturnCustomerList()
        {
            return DataSource.CustomersList;
        }

        public IEnumerable<DroneINCharge> ReturnDroneChargeList()
        {
            return DataSource.DroneChargeList;
        }

        public int ReturnParcelStatus(Parcel par)
        {
            if (par.ArrivedTime != null)
            {
                return 3;
            }
            if (par.PickedUp != null)
            {
                return 2;
            }
            if (par.ParingTime != null)
            {
                return 1;
            }
            return 0;
        }


    }



}




