using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDAL.DO
{
    namespace DalObject
    {
        public class Functions
        {
            static void AddStation()
            {
                DataSource.StationsList.Add(new Station());
            }
        }

        internal class Config
            {
                public int RunIdParcel = 100001;
            }

        }
    }
}