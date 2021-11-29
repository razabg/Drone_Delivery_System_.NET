using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;

namespace DalObject
{
    /// <summary>
    /// method that add new station to stations list
    /// </summary>
    public partial class DalObject
    {
        public void AddStation()
        {
            Console.WriteLine("Please enter the station's ID:\n");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the station's name:\n");
            int NAME = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the station's longitube:\n");
            double LONGITUDE = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the station's lattitude:\n");
            double LATTITUDE = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the station's chargeSlots:\n");
            int CHARGESLOTS = int.Parse(Console.ReadLine());
            DataSource.StationsList.Add(new Station()
            {
                Id = ID,
                Name = NAME,
                Longitude = LONGITUDE,
                Lattitude = LATTITUDE,
                ChargeSlots = CHARGESLOTS
            });
        }
        public static void findAndPrint_Station(int key)
        {
            Station ForPrint = DataSource.StationsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public static void show_station_list()
        {
            foreach (Station item in DataSource.StationsList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }

        public static void show_AvailableChagingStations_list()
        {
            foreach (Station item in DataSource.StationsList)
            {
                if (item.ChargeSlots > 0)
                {
                    Console.WriteLine(item);
                    Console.WriteLine($"\n");
                }
            }

        }

    }
  
}
