using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDAL.DO.DalObject
{
    class DataSource
    {

        public static Random rand = new Random();
        //public string CarringAbility()
        enum MaxWeight { Heavy = 1, Average = 2, Light = 3 }
        static MaxWeight RandomEnum = (MaxWeight)rand.Next(1, Enum.GetNames(typeof(string)).Length);

        public enum DroneStatus { Available = 1, Busy = 2, TreatmentMode = 3 }
        internal static List<Drone> DronesList = new List<Drone>();
        internal static List<Station> StationsList = new List<Station>();
        internal static List<Customer> CustomersList = new List<Customer>();
        internal static List<Parcel> ParcelsList = new List<Parcel>();


        const int MinRange = 111111111;
        const int MaxRange = 999999999;

        //public static string Status { get; private set; }
        public static int RandomIdFunc()
        {
            return rand.Next(MinRange, MaxRange);
        }
        public static double Coordinates()
        {
            return rand.Next(111111111, 999999999);
        }
        static void Initialize()
        {

            for (int i = 0; i < 10; i++)
            {
                StationsList.Add(new Station()
                {
                    Id = RandomIdFunc(),
                    Name = rand.Next(MinRange / 3, MaxRange / 3),
                    ChargeSlots = rand.Next(1, 100),
                    Longitude = Coordinates(),
                    Lattitude = Coordinates()
                });

                DronesList.Add(new Drone()
                {
                    Id = RandomIdFunc(),
                    //Model = 
                    MaxWeight = RandomEnum.ToString(),//(string)rand.Next((MaxWeight.Heavy, MaxWeight.Light),// have to check if the return value is a string type

                    Status = (string)(Enum.GetValues((Type)MaxWeight)[rand.Next(0, 2)]),//MaxWeight.[rand.Next(1,3)],
                    Battary = (double)rand.Next(0, 100)
                });

                CustomersList.Add(new Customer()
                {
                    Id = RandomIdFunc(),
                    Name = ,
                    Phone =,
                    Longitude = Coordinates(),
                    Latitude = Coordinates()
                });

                ParcelsList.Add(new Parcel
                {
                    Id = RandomIdFunc(),
                    SenderId = RandomIdFunc(),
                    TargetId = RandomIdFunc(),
                    Weight =
                    Priority =
                    DroneId = RandomIdFunc(),
                    Scheduled =
                    PickedUp =
                    Delivered =
                    Requested =

                });


            }
        }
    }
}
