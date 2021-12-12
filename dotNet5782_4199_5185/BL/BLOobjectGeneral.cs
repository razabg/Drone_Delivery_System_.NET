using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBL;

namespace IBL.BO
{
    public partial class BLObject
    {
      public IDAL.DO.Customer GetCustomerDetails(int id)
        {
            List<IDAL.DO.Customer> CustomerListDal = AccessToDataMethods.ReturnCustomerList().ToList();
            int index = CustomerListDal.FindIndex(x => x.Id == id);
            return CustomerListDal[index];
        }

       public IDAL.DO.Station ClosetStation( double longi,double lati,IEnumerable<IDAL.DO.Station> station)
        {

            return;
        }

    }
}
