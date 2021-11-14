using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;


namespace DalObject
{
    public class DalObject
    {
        public DalObject() { DataSource.Initialize(); }
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

        public void AddCustomer()
        {
            Console.WriteLine("Please enter the ID:\n");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter customer's name:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter customer's phone number:\n");
            string phoneNum = Console.ReadLine();
            Console.WriteLine("Please enter customer's longitude:\n");
            double longitude = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter customer's latitude:\n");
            double latitude = double.Parse(Console.ReadLine());

            DataSource.CustomersList.Add(new Customer
            {
                Id = Id,
                Name = name,
                Phone = phoneNum,
                Longitude = longitude,
                Latitude = latitude,
            });
        }

        //Exit, Assignment, PickedUp, Dalivary, Recharge
        public void UpdateAssignment() {; }
        public static void findAndPrint_Drone(int key)
        {
            Drone ForPrint = DataSource.DronesList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        public static void findAndPrint_Customer(int key)
        {
            Customer ForPrint = DataSource.CustomersList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        public static void findAndPrint_Parcel(int key)
        {
            Parcel ForPrint = DataSource.ParcelsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        public static void findAndPrint_Station(int key)
        {
            Station ForPrint = DataSource.StationsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }





    }
}

