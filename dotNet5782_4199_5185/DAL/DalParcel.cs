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
        public void AddParcel(Parcel parcel)
        {
            if (DataSource.ParcelsList.ToList().Exists(x => x.Id == parcel.Id))
            {
                throw new AlreadyExistsException("the parcel is alreay exists");
            }
            DataSource.ParcelsList.Add(new Parcel
            {
                Id = DataSource.Config.RunIdParcel++,//CHECK RUN ID PARCEL
                SenderId = parcel.SenderId,
                TargetId = parcel.TargetId,
                Weight = parcel.Weight,
                Priority = parcel.Priority,
                DroneId = null,
                CreationTime = DateTime.Now,
                ParingTime = null,
                PickedUp = null,
                ArrivedTime = null,
            });
             
        }
        public void findAndPrint_Parcel(int key)
        {
            Parcel ForPrint = DataSource.ParcelsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        public  void show_parcel_list()
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
        public void show_UnassignmentParcel_list()
        {
            foreach (Parcel parcel in DataSource.ParcelsList)
            {
                if (parcel.DroneId == 0)
                {
                    Console.WriteLine(parcel);
                    Console.WriteLine($"\n");
                }
            }
        }
    }
}
