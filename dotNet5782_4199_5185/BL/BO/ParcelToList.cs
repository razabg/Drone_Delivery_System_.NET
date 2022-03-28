using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// bl entity to show the parcels list
    /// </summary>
    public class ParcelToList
    {
        public int Id { set; get; }
        public string SenderName { set; get; }
        public string ReceiverName { set; get; }
        public string Weight { set; get; }
        public string Priority { set; get; }
        public string Status { set; get; }



        public override string ToString()
        {
            string printInfo = "";
            printInfo += $"ID:{Id}\n";
            printInfo += $"weight:{Weight},\n";
            printInfo += $"Priority:{Priority},\n";
            printInfo += $"Status:{Status},\n";
            printInfo += $"Receiver:{ReceiverName},\n";
            printInfo += $"Sender name:{SenderName},\n";

            return printInfo;
        }
    }
}
