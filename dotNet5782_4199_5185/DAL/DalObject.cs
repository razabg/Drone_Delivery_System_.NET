using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDAL.DO
{
    namespace DalObject
    {

        public class DataSource
        {
            internal static List<Drone> DronesList = new List<Drone>();
            internal static List<Station> StationsList = new List<Station>();
            internal static List<Customer> CustomersList = new List<Customer>();
            internal static List<Parcel> ParcelsList = new List<Parcel>();

            static Random rand = new Random();
            const int MinRange = 111111111;
            const int MaxRange = 999999999;
            static void Initialize()
            {
                
                for (int i = 0; i < 10; i++)
                {
                    StationsList.Add(new Station()
                    {
                        Id = rand.Next(MinRange, MaxRange),
                        Name = rand.Next(MinRange / 3, MaxRange / 3),
                        ChargeSlots= rand.Next(1, 100),
                        Longitude=rand.Next(111111111,999999999)
                    }) 
                }
                

            }
        }
    }
}