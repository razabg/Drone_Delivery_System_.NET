using System;
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
                int ID = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the station's name:\n");
                int NAME= int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the station's longitube:\n");
                double LONGITUDE =double.Parse( Console.ReadLine());
                Console.WriteLine("Please enter the station's lattitude:\n");
                double LATTITUDE = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the station's chargeSlots:\n");
                int CHARGESLOTS = int.Parse(Console.ReadLine());
                DataSource.StationsList.Add(new Station(){
                    Id=ID,
                    Name= NAME,
                    Longitude= LONGITUDE,
                    Lattitude= LATTITUDE,
                    ChargeSlots=CHARGESLOTS 
                });
            }
            public void AddDrone()
            {
                DataSource.DronesList.Add(new Drone()
                {
                    Console.WriteLine("Please enter the drone's ID:\n");
                object ID = Console.ReadLine();
                Console.WriteLine("Please enter the drone's model:\n");
                object MODEL = Console.ReadLine();
                Console.WriteLine("Please enter the drone's maxWeight:\n");
                object MAXWEIGHT = Console.ReadLine();
                Console.WriteLine("Please enter the drone's status:\n");
                object STATUS = Console.ReadLine();
                Console.WriteLine("Please enter the drone's battary:\n");
                object BATTARY = Console.ReadLine();
                DataSource.DronesList.Add(new Drone()
                {
                    Id = (int)ID,
             Model = (string)MODEL,
             MaxWeight=(string)MAXWEIGHT, 
             Status= (string)STATUS,
             Battary= (double)BATTARY 
        });
            }
        }

       
        }
    }
}