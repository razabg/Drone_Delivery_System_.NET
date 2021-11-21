using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;

namespace DalObject
{
    public partial class DalObject
    {
        public void AddParcel()
        {

            Console.WriteLine("Please enter the sender's ID:\n");
            int SenderId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the target ID:\n");
            int TargetId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the parcel's weight:\n");
            float Weight = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the parcel's priority:\n");
            int Priority = int.Parse(Console.ReadLine());
            DataSource.ParcelsList.Add(new Parcel
            {
                Id = DataSource.Config.RunIdParcel++,
                SenderId = SenderId,
                TargetId = TargetId,
                Weight = Weight,
                Priority = Priority,
                Requested = DateTime.Now,
                Scheduled = null,
                PickedUp = null,
                Delivered = null,
            });

        }
        public static void findAndPrint_Parcel(int key)
        {
            Parcel ForPrint = DataSource.ParcelsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public static void show_parcel_list()
        {
            foreach (Parcel item in DataSource.ParcelsList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }
        /// <summary>
        /// run on the items of ParcelsList - checks the drone-id - and print every parcel that her droneid' isn't equal to one from the drones
        /// </summary>
        public static void show_AssignmentParcel_list()
        {
            foreach (Parcel parcel in DataSource.ParcelsList)
            {
                foreach (drone in DataSource.DronesList)
                    if (parcel.DroneId.Equals(drone.Id))
                    {
                        continue;
                    }

                Console.WriteLine(parcel);
                Console.WriteLine($"\n");
            }

        }
    }
}
