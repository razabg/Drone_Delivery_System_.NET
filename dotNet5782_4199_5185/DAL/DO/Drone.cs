﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DO
{
    public struct Drone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string MaxWeight { get; set; }


        public override string ToString()
        {
            string printDroneInfo = "";
            printDroneInfo += $" the Id is : {Id},\n";
            printDroneInfo += $"the model is: {Model},\n";
            printDroneInfo += $"the MaxWeight is: {MaxWeight},\n";

            return printDroneInfo;
        }
    }

}

