using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        struct Parcel
        {
            public int Id { get; set; }
            public int SenderId { get; set; }
            public int TargetId { get; set; }
            public float Weight { get; set; }
            public int Priority { get; set; }
            public int DroneId { get; set; }
            public DateTime? Scheduled { get; set; }//drone pair
            public DateTime? PickedUp { get; set; }//time of collection
            public DateTime? Delivered { get; set; }//time of getting the parcel
            public DateTime Requested { get; set; }//time of creation


            public override string ToString()
            {
                string printParcelInfo = "";
                printParcelInfo += $" the Id is {Id},\n";
                printParcelInfo += $"the SenderId is{SenderId},\n";
                printParcelInfo += $"the TargetId is{TargetId},\n";
                printParcelInfo += $"the Weight is {Weight},\n";
                printParcelInfo += $"Priority {Priority},\n";
                printParcelInfo += $"the DroneId is {DroneId},\n";
                printParcelInfo += $"Connection time between the drone and the parcel{Scheduled },\n";
                printParcelInfo += $" Picked up time{PickedUp},\n";
                printParcelInfo += $"Delivery time {Delivered},\n";
                printParcelInfo += $"Request time {Requested},\n";
                return printParcelInfo;
            }




        }


    }
}
