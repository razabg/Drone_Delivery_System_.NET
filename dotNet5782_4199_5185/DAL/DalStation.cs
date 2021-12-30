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
        public void AddStation(Station tolist)
        {
           
            if (DataSource.StationsList.ToList().Exists(x=>x.Id==tolist.Id))
            {
                throw new AlreadyExistsException("the station is already exists");
            }

            DataSource.StationsList.Add(new Station()
            {
                Id = tolist.Id,
                Name = tolist.Name,
                Longitude = tolist.Longitude,
                Latitude = tolist.Latitude,
                ChargeSlots = tolist.ChargeSlots
            });
        }
        public void findAndPrint_Station(int key)
        {
            Station ForPrint = DataSource.StationsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public void show_station_list()
        {
            foreach (Station item in DataSource.StationsList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }

        public void show_AvailableChargingStations_list()
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
