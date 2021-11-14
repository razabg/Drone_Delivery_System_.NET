using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;



namespace DalObject
{
    public partial class DalObject
    {
        public DalObject() { DataSource.Initialize(); } //ctor initialize the class and also run the initialize method. 

        /// <summary>
        /// Pairing parcel to drone & Update the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdateAssignment(Parcel p, Drone d)
        {
            p.DroneId = d.Id;
            d.Status= DataSource.DroneStatus.Busy.ToString();
        }
        
        /// <summary>
        /// Update the time - when the drone picked the parcel
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void UpdatePickedUp(Parcel p, Drone d)
        {
            DateTime picked = DateTime.Now;
            p.PickedUp = picked;
        }

        /// <summary>
        /// Update the time - when the parcel dalivary & Update also the status of the drone
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        public void Delivery(Parcel p, Drone d)
        {
            DateTime delivery = DateTime.Now;
            d.Status = DataSource.DroneStatus.Busy.ToString();
        }

        /// <summary>
        /// Charging a drone. Update the drone' status & Update also the number of available ChargeSlots in the station  
        /// Make the connection by creating a new entity of DroneCharge
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        public void UpdateRecharge(Station s, Drone d)
        {
            d.Status = DataSource.DroneStatus.TreatmentMode.ToString();
            DroneCharge DCharge = default;
            DCharge.DroneId=d.Id;
            DCharge.StationId = s.Id;
            s.ChargeSlots--;
        }

    }
}




