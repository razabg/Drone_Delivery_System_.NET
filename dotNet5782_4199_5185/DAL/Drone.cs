using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct Drone
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string MaxWeight { get; set; }
            public string Status { get; set; } 
            public double Battary { get; set; }

            public override string ToString()
            {
                return base.ToString();
            }
        }
        
    }
}
