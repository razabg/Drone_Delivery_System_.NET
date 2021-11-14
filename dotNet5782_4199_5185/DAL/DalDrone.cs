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
        /// <summary>
        /// method that add new drone to drones list
        /// </summary>
        public void AddDrone()
        {
            Console.WriteLine("Please enter the drone's ID:\n");
            object ID = Console.ReadLine();
            Console.WriteLine("Please enter the drone's model:\n");
            object MODEL = Console.ReadLine();
            Console.WriteLine("Please enter the drone's maxWeight:\n");
            object MAXWEIGHT = Console.ReadLine();
            Console.WriteLine("Please enter the drone's status:\n");

            DataSource.DronesList.Add(new Drone()
            {
                Id = (int)ID,
                Model = (string)MODEL,
                MaxWeight = (string)MAXWEIGHT,
            });
        }
        public static void findAndPrint_Drone(int key)
        {
            Drone ForPrint = DataSource.DronesList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }


    }

}
