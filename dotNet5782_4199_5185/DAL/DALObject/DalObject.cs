using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DalApi;



namespace DAL
{
    /// <summary>
    /// the class implement the idal class which deal with all actions on the entities lists.
    /// </summary>
    internal sealed partial class DALobject : IDal
    {
        //bonus lazy init
        #region singelton 
        public static readonly Lazy<DALobject> instance = new Lazy<DALobject>(() => new DALobject());//the "lazy" init made to improve the performance.the creation is deferred until it is first used
        static DALobject() { }// static ctor to ensure instance init is done just before first usage
        DALobject() { DataSource.Initialize(); } // default => private
        public static DALobject Instance { get => instance.Value; }// The public Instance property to use
        #endregion


        

      
        public double[] PowerConsumptionRequestDrone()
        {
            double[] arr = new double[] { DataSource.Config.Available, DataSource.Config.Light, DataSource.Config.Average, DataSource.Config.Heavy, DataSource.Config.ChargingPaceDrone };

            return arr;
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










