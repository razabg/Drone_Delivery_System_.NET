﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DalApi
{
    /// <summary>
    /// Dalfactory class implement the "simple factory" design pattern
    /// </summary>
    public class DalFactory
    {
        public static IDal GetDal(string wayOfImplement)
        {

            switch (wayOfImplement)
            {
                case "1":
                    return DALobject.instance.Value; //class DALobject lazy init
                case "2":
                   return DalXml.Instance;
                default:
                    throw new Exception("the factory class didnt work well");

            }


        }
    }
}
