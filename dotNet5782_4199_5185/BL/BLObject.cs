using System;
using IBL;
using System.Collections.Generic;
using System.Collections;


namespace IBL.BO
{
    public partial class BLObject : IBL
    {
        public IDAL.DO.IDal AccessToDataMethods;
        internal List<DroneToList> ListDrone = new List<DroneToList>();

        public BLObject()
        {
            AccessToDataMethods = new DalObject.DalObject();
            IEnumerable<double> PowerConsumption = AccessToDataMethods.PowerConsumptionRequestDrone();            
                                                                         
            





        }



    }
}
