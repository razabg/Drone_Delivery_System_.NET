using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;

namespace DalObject
{
   public class DataSource
    {

        internal static List<Drone> DronesList = new List<Drone>();
        internal static List<Station> StationsList = new List<Station>();
        internal static List<Customer> CustomersList = new List<Customer>();
        internal static List<Parcel> ParcelsList = new List<Parcel>();
        internal static List<DroneINCharge> DroneChargeList = new List<DroneINCharge>();
        internal class Config
        {
            public static int RunIdParcel = 10000001;

            // the battery numbers refers  to consumption  % per km
            internal static double Available  { get{return 5; } }
            internal static double Light { get { return 10; } }
            internal static double Average { get { return 15; } }
            internal static double Heavy { get { return 20; } }

            internal static double ChargingPaceDrone = 40;


        }

        #region initialize rand method
        /// random intel:
        /// we made a few random functions in order to generate random information. like id,locations,phone number etc.
        /// 
        public enum PriorityStatus { fast = 1, regular, emergency };

        public static int genRandPriority()
        {
            Random rand4 = new Random();
            int RandPri = (int)rand4.Next(1, Enum.GetNames(typeof(PriorityStatus)).Length);
            return RandPri;
        }


        public enum CustomerName { david, shlomo, brook, barak, rachel, pnina, eyal, yosi, winston, leo, ayelet, rico, raz, addie };

        public static Enum genRandCustomer()
        {
            Random rand3 = new Random();
            CustomerName RandCustomer = (CustomerName)rand3.Next(1, Enum.GetNames(typeof(CustomerName)).Length);
            return RandCustomer;
        }

        public enum TopWeight { available, Light, Average, Heavy };
        public static Enum genRandTop()
        {

            Random rand2 = new Random();
            TopWeight RandomEnum = (TopWeight)rand2.Next(1, Enum.GetNames(typeof(TopWeight)).Length);
            return RandomEnum;
        }
        public enum DroneStatus { Available = 1, Busy = 2, TreatmentMode = 3 }
        public static Enum genRandStatus()
        {
            Random rand3 = new Random();
            DroneStatus RandomEnum = (DroneStatus)rand3.Next(1, Enum.GetNames(typeof(DroneStatus)).Length);
            return RandomEnum;
        }
        public static Random rand = new Random();




        const int MinRange = 111;
        const int MaxRange = 999;

        public static int RandomModelFunc()
        {
            return rand.Next(1, 5);
        }

        public static int RandomIdFunc()
        {
            return rand.Next(MinRange, MaxRange);
        }
        public static double Coordinates()
        {
            return rand.Next(111111111, 999999999);
        }
        #endregion

        /// <summary>
        /// the initialize func making a fast inizialization of objects.
        /// </summary>
        public static void Initialize()
        {


            for (int i = 0; i < 2; ++i)
            {
                StationsList.Add(new Station()
                {
                    Id = RandomIdFunc(),
                    Name = rand.Next(MinRange / 3, MaxRange / 3),
                    ChargeSlots = rand.Next(1, 100),
                    Longitude = Coordinates(),
                    Latitude = Coordinates()
                });
                DroneChargeList.Add(new DroneINCharge()
                {
                    DroneId = 0,
                    StationId = 0,
                });

            }
            for (int i = 0; i < 5; ++i)
            {
                DronesList.Add(new Drone()
                {
                    Id = RandomIdFunc(),
                    MaxWeight = genRandTop().ToString(),
                    Model = RandomModelFunc().ToString(),

                });
            }
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                CustomersList.Add(new Customer()
                {
                    Id = RandomIdFunc(),
                    Name = genRandCustomer().ToString(),
                    Phone = rand.Next(111111111, 999999999).ToString(),
                    Longitude = Coordinates(),
                    Latitude = Coordinates()
                });
                List<int> randIdOfCustomers = new List<int>();
                randIdOfCustomers.Add(CustomersList[i].Id);
            }
            for (int i = 0; i < 1; i++) {

                DateTime currentDate = DateTime.Now;
                ParcelsList.Add(new Parcel
                {
                    Id = RandomIdFunc(),
                    SenderId = rnd.Next(CustomersList[i].Id),
                    TargetId = CustomersList[i].Id,
                    Weight = rand.Next(1, 300),
                    Priority = genRandPriority(),
                    DroneId = RandomIdFunc(),
                    ParingTime = null,
                    PickedUp = null,
                    ArrivedTime = null,
                    CreationTime = null

                });
            }
        }



    }
}




