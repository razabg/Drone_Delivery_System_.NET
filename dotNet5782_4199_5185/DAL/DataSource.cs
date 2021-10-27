﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDAL.DO.DalObject
{
    class DataSource
    {
        public enum CustomerName { david  , shlomo, brook,barak,rachel,pnina,eyal,yosi,winston,leo,ayelet,rico,raz,addie };

        public static Enum genRandCustomer()
        {
            Random rand3 = new Random();
            CustomerName RandCustomer = (CustomerName)rand3.Next(1, Enum.GetNames(typeof(CustomerName)).Length);
            return RandCustomer;
        }





        public enum TopWeight { Heavy = 1, Average = 2, Light = 3 };
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
                    MaxWeight = genRandTop().ToString(),
                    Status = genRandStatus().ToString(),
                    Model =RandomIdFunc().ToString(),
                    Battary = rand.Next(0,100)
                }) ;

                CustomersList.Add(new Customer()
                {
                    Id = RandomIdFunc(),
                    Name = genRandCustomer().ToString(),
                    Phone = rand.Next(111111111, 999999999).ToString(),
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

                 internal class Config
        {
            public int RunIdParcel = 100001;
        }

    }
}
        }
    }
}