﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDAL.DO
{
    namespace DalObject
    {
        public class Functions
        {
            public void AddStation()
            {
                Console.WriteLine("Please enter the station's ID:\n");
                object ID = Console.ReadLine();
                Console.WriteLine("Please enter the station's name:\n");
                object NAME = Console.ReadLine();
                Console.WriteLine("Please enter the station's longitube:\n");
                object LONGITUDE = Console.ReadLine();
                Console.WriteLine("Please enter the station's lattitude:\n");
                object LATTITUDE = Console.ReadLine();
                Console.WriteLine("Please enter the station's chargeSlots:\n");
                object CHARGESLOTS = Console.ReadLine();
                DataSource.StationsList.Add(new Station()
                {
                    Id = (int)ID,
                    Name = (int)NAME,
                    Longitude = (double)LONGITUDE,
                    Lattitude = (double)LATTITUDE,
                    ChargeSlots = (int)CHARGESLOTS
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
        }
    }
}