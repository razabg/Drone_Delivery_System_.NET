using System;

    namespace IDAL
    {
        namespace DO
        {
            public struct Customer
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Phone { get; set; }
                public double Longitude { get; set; }
                public double Latitude { get; set; }
                public override string ToString()
                {
                    string printCustomerInfo = "";
                    printCustomerInfo += $" the Id is {Id},\n";
                    printCustomerInfo += $"the name is{Name},\n";
                    printCustomerInfo += $"the phone number is {Phone},\n";
                    printCustomerInfo += $"Longitude {Longitude},\n";
                    printCustomerInfo += $"latitude {Latitude},\n";
                    return printCustomerInfo;
                }
            }
        }
    }
