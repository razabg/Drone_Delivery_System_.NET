using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;



namespace DalObject
{
    public partial class DalObject : IDal
    {
        public DalObject() { DataSource.Initialize(); } //ctor initialize the class and also run the initialize method. 

        //Exit, Assignment, PickedUp, Dalivary, Recharge
        public void UpdateAssignment() {; }
    }
}




