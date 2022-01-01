using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DAL
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
            public static int RunIdParcel = 101;

            // the battery numbers refers  to consumption  % per km
            internal static double Available { get { return 5; } }
            internal static double Light { get { return 10; } }
            internal static double Average { get { return 15; } }
            internal static double Heavy { get { return 20; } }

            internal static double ChargingPaceDrone = 40;


        }

        #region initialize rand method
        /// random intel:
        /// we made a few random functions in order to generate random information. like id,locations,phone number etc.
        /// 


        public static Random rand = new Random();
        const int MinRange = 111;
        const int MaxRange = 999;
        public static string ConvertDecimalDegreesToSexagesimal(double decimalValueToConvert, string LongOrLat)
        {
            string direction = null;
            if (LongOrLat == "Longitude")
            {
                if (decimalValueToConvert >= 0)
                    direction = "N";
                else direction = "S";
            }

            if (LongOrLat == "Latitude")
            {
                if (decimalValueToConvert >= 0)
                    direction = "E";
                else direction = "W";
            }
            int sec = (int)Math.Round(decimalValueToConvert * 3600);
            int deg = sec / 3600;
            sec = Math.Abs(sec % 3600);
            int min = sec / 60;
            sec %= 60;

            return string.Format("{0}° {1}' {2}'' {3}", Math.Abs(deg), Math.Abs(min), Math.Abs(sec), direction);// return the complited number
        }
        public static Enum ModelRand()
        {

            Random rand = new Random();
            DalEnum.DroneModel RandModel = (DalEnum.DroneModel)rand.Next(1, Enum.GetNames(typeof(DalEnum.DroneModel)).Length + 1);
            return RandModel;
        }


        public static Enum genRandPriority()
        {
            Random rand4 = new Random();
            DalEnum.PriorityStatus RandPri = (DalEnum.PriorityStatus)rand4.Next(1, Enum.GetNames(typeof(DalEnum.PriorityStatus)).Length + 1);
            return RandPri;
        }


        public static Enum genRandCustomer()
        {
            Random rand3 = new Random();
            DalEnum.CustomerName RandCustomer = (DalEnum.CustomerName)rand3.Next(1, Enum.GetNames(typeof(DalEnum.CustomerName)).Length + 1);
            return RandCustomer;
        }

        public static Enum genRandTop()
        {

            Random rand2 = new Random();
            DalEnum.TopWeight RandomEnum = (DalEnum.TopWeight)rand2.Next(0, Enum.GetNames(typeof(DalEnum.TopWeight)).Length );
            return RandomEnum;
        }
        public static Enum genRandStatus()
        {
            Random rand3 = new Random();
            DalEnum.DroneStatus RandomEnum = (DalEnum.DroneStatus)rand3.Next(1, Enum.GetNames(typeof(DalEnum.DroneStatus)).Length + 1);
            return RandomEnum;
        }

        public static int RandomIdFunc()
        {
            return rand.Next(MinRange, MaxRange);
        }

        public static double Coordinates()
        {
            double Location = rand.Next(111111111, 999999999);
            return Location;

        }
        #endregion

        /// <summary>
        /// the initialize func making a fast inizialization of objects.
        /// </summary>
        public static void Initialize()
        {
            List<int> randIdOfCustomers = new List<int>();//this list used to init the customer id nunmbers to target and sender id's in the parcel entity

            for (int i = 0; i < 5; ++i)
            {
                StationsList.Add(new Station()
                {
                    Id = RandomIdFunc(),
                    Name = rand.Next(MinRange / 3, MaxRange / 3),
                    ChargeSlots = rand.Next(1, 15),
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
                    Model = ModelRand().ToString(),

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

                randIdOfCustomers.Add(CustomersList[i].Id);//check how to insert this to target an
            }
            for (int i = 0; i < 6; i++)
            {
                int index = rand.Next(0, randIdOfCustomers.Count);
                DateTime currentDate = DateTime.Now;
                if (index < 9)
                {

                    ParcelsList.Add(new Parcel
                    {
                        Id = DataSource.Config.RunIdParcel++,
                        SenderId = randIdOfCustomers[index],
                        TargetId = randIdOfCustomers[index + 1],//check for future tests
                        Weight = genRandTop().ToString(),
                        Priority = genRandPriority().ToString(),
                        DroneId = null,
                        ParingTime = null,
                        PickedUp = null,
                        ArrivedTime = null,
                        CreationTime = null

                    });
                }
            }
        }

    }
}




