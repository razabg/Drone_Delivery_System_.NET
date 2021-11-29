using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct Parcel
        {
            public int Id { get; set; }
            public int SenderId { get; set; }
            public int TargetId { get; set; }
            public float Weight { get; set; }
            public int Priority { get; set; }
            public int DroneId { get; set; }
            public DateTime? ParingTime { get; set; }//drone pair
            public DateTime? PickedUp { get; set; }//time of collection
            public DateTime? ArrivedTime { get; set; }//time of getting the parcel
            public DateTime? CreationTime { get; set; }//time of creation


            public override string ToString()
            {
                string printParcelInfo = "";
                printParcelInfo += $" the Id is {Id},\n";
                printParcelInfo += $"the SenderId is{SenderId},\n";
                printParcelInfo += $"the TargetId is{TargetId},\n";
                printParcelInfo += $"the Weight is {Weight},\n";
                printParcelInfo += $"Priority {Priority},\n";
                printParcelInfo += $"the DroneId is {DroneId},\n";
                printParcelInfo += $"Connection time between the drone and the parcel{ParingTime },\n";
                printParcelInfo += $" Picked up time{PickedUp},\n";
                printParcelInfo += $"UpdateArrived time {ArrivedTime},\n";
                printParcelInfo += $"Request time {CreationTime},\n";
                return printParcelInfo;
            }




        }


    }
}
