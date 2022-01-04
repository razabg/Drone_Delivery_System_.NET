using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{

    public struct Parcel
    {

        public int Id { get; set; }
        public int SenderId { get; set; }
        public int TargetId { get; set; }
        public string Weight { get; set; }
        public string Priority { get; set; }
        public int? DroneId { get; set; }
        public DateTime? ParingTime { get; set; }//drone pair
        public DateTime? PickedUp { get; set; }//time of collection
        public DateTime? ArrivedTime { get; set; }//time of getting the parcel
        public DateTime? CreationTime { get; set; }//time of creation


        public override string ToString()
        {
            string printParcelInfo = "";
            printParcelInfo += $"Id:{Id},\n";
            printParcelInfo += $"SenderId:{SenderId},\n";
            printParcelInfo += $"TargetId:{TargetId},\n";
            printParcelInfo += $"Weight:{Weight},\n";
            printParcelInfo += $"Priority:{Priority},\n";
            printParcelInfo += $"DroneId:{DroneId},\n";
            printParcelInfo += $"Pair time:{ParingTime },\n";
            printParcelInfo += $"Picked up time:{PickedUp},\n";
            printParcelInfo += $"Arrived time:{ArrivedTime},\n";
            printParcelInfo += $"Creation time:{CreationTime},\n";
            return printParcelInfo;
        }




    }


}

