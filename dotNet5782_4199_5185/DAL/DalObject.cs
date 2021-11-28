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
        public void  UpdateAssignment(int p, int d) 
        {
           var indexParcel  = DataSource.ParcelsList.FindIndex(x => x.Id == p);
            var indexDrone  = DataSource.DronesList.FindIndex(x => x.Id == d);
            if (indexDrone != -1 &&indexParcel != -1)
            {
                return; //חריגה בהמשך לבדוק שקיימים החבילה והרחפן ולבדוק שהרחפן פנוי ושהחבילה לא משוייכת
            }
            Parcel  helper = (DataSource.ParcelsList[indexParcel]); //in order to update the idrone in parcel.droneid we used helper to get the right id .
            helper.DroneId = DataSource.DronesList[indexDrone].Id;
            helper.ParingTime = DateTime.Now;
            (DataSource.ParcelsList[indexParcel]) = helper;


            Drone helper2 = DataSource.DronesList[indexDrone];//update the status of the drone
            helper2.Status = DataSource.DroneStatus.Busy.ToString();
            DataSource.DronesList[indexDrone] = helper2;

        }

        /// <summary>
        /// Update the time - when the drone picked the parcel
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdatePickedUp(int p, int d)
        {
            var indexParcel = DataSource.ParcelsList.FindIndex(x => x.Id == p);
            var indexDrone = DataSource.DronesList.FindIndex(x => x.Id == d);
            if (indexDrone != -1 && indexParcel != -1)
            {
                return; 
            }
            Parcel helper = (DataSource.ParcelsList[indexParcel]); //in order to update the idrone in parcel.droneid we used helper to get the right id .
            helper.PickedUp = DateTime.Now ;
            (DataSource.ParcelsList[indexParcel]) = helper;


            //DateTime picked = DateTime.Now;
            //p.PickedUp = picked;
        }

        /// <summary>
        /// Update the time - when the parcel dalivary & Update also the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void Delivery(Parcel p, Drone d)
        {
            DateTime delivery = DateTime.Now;
            d.Status = DataSource.DroneStatus.Available.ToString();
        }

        /// <summary>
        /// Charging a drone. Update the drone' status & Update also the number of available ChargeSlots in the station  
        /// Make the connection by creating a new entity of DroneCharge
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        public void UpdateRecharge(Station s, Drone d) //need to do here exeption  חריגה למקרה של אין מספיק עמדות טעינה
        {
            d.Status = DataSource.DroneStatus.TreatmentMode.ToString();
            DroneCharge DCharge = default;
            DCharge.DroneId=d.Id;
            DCharge.StationId = s.Id;
            s.ChargeSlots--;
        }

    }
}




