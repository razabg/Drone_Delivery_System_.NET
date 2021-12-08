using System;
using IBL;
using System.Collections.Generic;
using System.Collections;


namespace IBL.BO
{
    public partial class BLObject : IBL
    {
        public IDAL.DO.IDal AccessToDataMethods;
        internal List<DroneToList> ListDroneBL = new List<DroneToList>();
        internal List<ParcelToList> ListParcelBL = new List<ParcelToList>();

        public BLObject()
        {
            AccessToDataMethods = new DalObject.DalObject();
            IEnumerable<double> PowerConsumption = AccessToDataMethods.PowerConsumptionRequestDrone();
            IEnumerable <IDAL.DO.Drone> DroneListDal = AccessToDataMethods.ReturnDroneList();
            IEnumerable<IDAL.DO.Parcel> ParcelListDal = AccessToDataMethods.ReturnParcelList();
            foreach (var item in DroneListDal)
            {
                ListDroneBL.Add(new DroneToList()
                {
                    Id = item.Id,
                    Weight =item.MaxWeight,
                    Model =item.Model,
                });

            }



            Enum ParS = new Enum();
            
            foreach (var item in ParcelListDal)
            {
                ParS =(ParS)AccessToDataMethods.ReturnParcelStatus(item);
                ListParcelBL.Add(new ParcelToList
                {
                    Id = item.Id,
                    SenderName = item.SenderId.ToString(),
                    ReceiverName =item.TargetId.ToString(),
                    Weight = item.Weight.ToString(),
                    Priority = item.Priority.ToString(),
                     = AccessToDataMethods.ReturnParcelStatus(item),
                });

            }
          






            }



    }
}
