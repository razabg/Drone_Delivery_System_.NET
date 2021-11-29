using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using IDAL.DO;

namespace DalObject
{
    public partial class DalObject
    {
        public void AddCustomer()
        {
            Console.WriteLine("Please enter the ID:\n");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter customer's name:\n");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter customer's phone number:\n");
            string phoneNum = Console.ReadLine();
            Console.WriteLine("Please enter customer's longitude:\n");
            double longitude = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter customer's latitude:\n");
            double latitude = double.Parse(Console.ReadLine());

            DataSource.CustomersList.Add(new Customer
            {
                Id = Id,
                Name = name,
                Phone = phoneNum,
                Longitude = longitude,
                Latitude = latitude,
            });
        }
        public  void findAndPrint_Customer(int key)
        {
            Customer ForPrint = DataSource.CustomersList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        /// <param name="key"></param>
        public  void show_customer_list()
        {

            foreach (Customer item in DataSource.CustomersList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }


    }

}


