using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDAL
{
    namespace DO
    {
        namespace DalObject
        {
            class DataSource
            {

                internal static List<Drone> DronesList = new List<Drone>();
                internal static List<Station> StationsList = new List<Station>();
                internal static List<Customer> CustomersList = new List<Customer>();
                internal static List<Parcel> ParcelsList = new List<Parcel>();

                internal class Config
                {
                    public static int RunIdParcel = 10000001;
                }


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




                const int MinRange = 1111111;
                const int MaxRange = 9999999;



                public static int RandomIdFunc()
                {
                    return rand.Next(MinRange, MaxRange);
                }
                public static double Coordinates()
                {
                    return rand.Next(111111111, 999999999);
                }


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
                            Lattitude = Coordinates()
                        });
                    }
                    for (int i = 0; i < 5; ++i)
                    {
                        DronesList.Add(new Drone()
                        {
                            Id = RandomIdFunc(),
                            MaxWeight = genRandTop().ToString(),
                            Status = genRandStatus().ToString(),
                            Model = RandomIdFunc().ToString(),

                        });
                    }
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

                        DateTime currentDate = DateTime.Now;
                        ParcelsList.Add(new Parcel
                        {
                            Id = RandomIdFunc(),
                            SenderId = RandomIdFunc(),
                            TargetId = RandomIdFunc(),
                            Weight = rand.Next(1, 300),
                            Priority = genRandPriority(),
                            DroneId = RandomIdFunc(),
                            Scheduled = currentDate,
                            PickedUp = currentDate,
                            Delivered = currentDate,
                            Requested = currentDate

                        });
                    }
                }

               

            }
        }
    }
}


