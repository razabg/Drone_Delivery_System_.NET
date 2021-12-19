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
        public void AddDrone(Drone drone_add)
        {
            if (!DataSource.DronesList.ToList().Exists(x=>x.Id==drone_add.Id))
            {
                throw new AlreadyExistsException("the drone is alreay exists");
            }

            DataSource.DronesList.Add(new Drone()
            {
                Id = drone_add.Id,
                Model = drone_add.Model,
                MaxWeight = drone_add.MaxWeight,
            }); ;
        }
        public  void findAndPrint_Drone(int key)
        {
            Drone ForPrint = DataSource.DronesList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }

        /// <summary>
        /// /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public  void show_drone_list()
        {
            foreach (Drone item in DataSource.DronesList)
            { 
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }

    }

}
