using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public class ParcelToList
    {
        public int Id { set; get;}
        public string SenderName { set; get;}
        public string ReceiverName { set; get;}
        public string Weight { set; get;}
        public string Priority { set; get;}
        public string status { set; get;}



                public override string ToString()
        {
            string printInfo = "";
            printInfo += $" the ID is :{Id}\n";
            printInfo += $"the weight is:{Weight},\n";
              printInfo += $"the priority is:{Priority},\n";
              printInfo += $"the status is:{status},\n";
              printInfo += $"the receiver name is:{ReceiverName},\n";
              printInfo += $"the sender name is:{SenderName},\n";
         
            return printInfo;
        }
    }
}
