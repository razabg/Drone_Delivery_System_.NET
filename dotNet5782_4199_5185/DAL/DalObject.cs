using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;



namespace DalObject
{
    public partial class DalObject : IDal
    {
        public DalObject() { DataSource.Initialize(); } //ctor initialize the class and also run the initialize method. 

        /// <summary>
        /// Pairing parcel to drone & Update the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void  UpdateParing(int p, int d) //לבדוק האם זה מטפל רק בישות  אחת
        {
           var indexParcel  = DataSource.ParcelsList.FindIndex(x => x.Id == p);
            var indexDrone  = DataSource.DronesList.FindIndex(x => x.Id == d);
            if (indexDrone != -1 &&indexParcel != -1)
            {
                return; //חריגה בהמשך לבדוק שקיימים החבילה והרחפן ולבדוק שהרחפן פנוי ושהחבילה לא משוייכת,לוודא שמשקל מתאים לרחפן
            }
            Parcel  helper = (DataSource.ParcelsList[indexParcel]); //in order to update the idrone in parcel.droneid we used helper to get the right id .
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
            if ( indexParcel != -1)
            {
                return; 
            }
            Parcel helper = (DataSource.ParcelsList[indexParcel]); //in order to update the idrone in parcel.droneid we used helper to get the right id .
            helper.PickedUp = DateTime.Now ;
            (DataSource.ParcelsList[indexParcel]) = helper;

        }

        /// <summary>
        /// Update the time - when the parcel dalivary & Update also the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdateArrived(int p)
        {//לבדוק מצב סוללה של הרחפן
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p);
   
            if ( indexParcel != -1)
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
        public void UpdateRecharge(Station s, Drone d) //need to do here exeption  חריגה למקרה של אין מספיק עמדות טעינה
        {
           
            DroneCharge DCharge = default;
            DCharge.DroneId=d.Id;
            DCharge.StationId = s.Id;
            s.ChargeSlots--;
        }

        public IEnumerable<double> PowerConsumptionRequestDrone()
        {
            double[] arr = new double[] { DataSource.Config.Available, DataSource.Config.Light, DataSource.Config.Average, DataSource.Config.Heavy, DataSource.Config.ChargingPaceDrone };

            return arr ;
        }


        public IEnumerable<Drone> ReturnDroneList()
        {
            return DataSource.DronesList;
        }

        public IEnumerable<Parcel> ReturnParcelList()
        {
            return DataSource.ParcelsList;
        }

        IEnumerable<Station> ReturnStationList()
        {
            return DataSource.StationsList;
        }
        IEnumerable<Customer> ReturnCustomerList()
        {
            return DataSource.CustomersList;
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




