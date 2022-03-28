using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BlApi
{
    /// <summary>
    ///  the class implement the simple factory design pattern 
    /// </summary>
    public class BlFactory 
    {
        public static IBL GetBl()
        {
            return BLObject.Instance;
        }
    }
}