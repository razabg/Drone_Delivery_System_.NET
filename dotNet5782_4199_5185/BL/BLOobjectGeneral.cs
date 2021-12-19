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
            if (index == -1)
            {
                throw new NotExistsException();
            }
            return CustomerListDal[index];
        }

        public double CalcDistanceBetweenTwoCoordinates(double longi1, double lati1, double longi2, double lati2)
        {
            double distance = Math.Sqrt(Math.Pow(longi1 - longi2, 2) + Math.Pow(lati1 - lati2, 2));
            return distance;


        }

        public IDAL.DO.Station NearestStation(double longi, double lati, IEnumerable<IDAL.DO.Station> station)
        {
            double MinDist = CalcDistanceBetweenTwoCoordinates(longi, lati, station.First().Longitude, station.First().Lattitude);
            IDAL.DO.Station StationToreturn = station.First();
            foreach (var item in station)
            {
                double temp = CalcDistanceBetweenTwoCoordinates(longi, lati, item.Longitude, item.Lattitude);
                if (MinDist > temp)
                {
                    MinDist = temp;
                    StationToreturn = item;
                }
            }
            return StationToreturn;

        }
    }
}
