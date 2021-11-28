using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;

namespace DalObject
{
    interface IDal
    {
        void AddCustomer();
        void AddDrone();
        void AddParcel();
        void AddStation();
        double[] PowerConsumptionRequestDrone();
       //void  findAndPrint_Customer(int key);
       //void  findAndPrint_Drone(int key);
       // void findAndPrint_Parcel(int key);
       // void findAndPrint_Station(int key);
        //public static void show_drone_list();
        public void UpdateRecharge(Station s, Drone d);
        public void UpdateAssignment(int p, int d);



    }
}
