using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDAL.DO
{
    namespace DalObject
    {
        
        public enum MaxWeight { Heavy =1, Average=2, Light=3 }
        
        public enum DroneStatus {Available=1, Busy=2, TreatmentMode=3 }
        public class DataSource
        {
            internal static List<Drone> DronesList = new List<Drone>();
            internal static List<Station> StationsList = new List<Station>();
            internal static List<Customer> CustomersList = new List<Customer>();
            internal static List<Parcel> ParcelsList = new List<Parcel>();

     


            internal class Config
            {
                public int RunIdParcel = 100001;
            }

        }
    }
}