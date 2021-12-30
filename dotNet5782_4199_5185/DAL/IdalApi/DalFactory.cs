using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DalApi
{
    public class DalFactory
    {
        public static IDal GetDal(string wayOfImplement)
        {

            switch (wayOfImplement)
            {
                case "blobject":
                    return DALobject.instance.Value; //class DALobject lazy init
                case "B":
                // xml TBD
                default:
                    throw new Exception("the factory class didnt work well");

            }


        }
    }
}
