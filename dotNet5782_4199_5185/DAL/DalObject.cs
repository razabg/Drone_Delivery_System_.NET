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

            static Random rand = new Random();
            const int MinRange = 111111111;
            const int MaxRange = 999999999;

            public static string Status { get; private set; }

            static void Initialize()
            {

                for (int i = 0; i < 10; i++)
                {
                    StationsList.Add(new Station()
                    {
                        Id = rand.Next(MinRange, MaxRange),
                        Name = rand.Next(MinRange / 3, MaxRange / 3),
                        ChargeSlots = rand.Next(1, 100),
                        Longitude = rand.Next(111111111, 999999999),
                        Lattitude = rand.Next(111111111, 999999999)
                    });

                    DronesList.Add(new Drone()
                    {
                        Id = rand.Next(MinRange, MaxRange),
                        //Model = 
                        MaxWeight = (string)rand.Next((MaxWeight.Heavy, MaxWeight.Light),// have to check if the return value is a string type
                        
                        Status =  (string)(Enum.GetValues((Type) MaxWeight)[rand.Next(0,2)]),//MaxWeight.[rand.Next(1,3)],
                        Battary = (double)rand.Next(0, 100)
                    }) ;
             
                }

                
            }


            internal class Config
            {
                public int RunIdParcel = 100001;
            }

        }
    }
}