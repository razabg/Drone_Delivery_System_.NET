using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace Dalobject
{
    internal sealed partial class DALobject
    {
        public void AddCustomer(Customer CustomerToAdd)
        {
            if (!DataSource.CustomersList.ToList().Exists(x => x.Id == CustomerToAdd.Id))
            {
                throw new AlreadyExistsException("the customer is alreay exists");
            }

            DataSource.CustomersList.Add(new Customer
            {
                Id = CustomerToAdd.Id,
                Name = CustomerToAdd.Name,
                Phone = CustomerToAdd.Phone,
                Longitude = CustomerToAdd.Longitude,
                Latitude = CustomerToAdd.Latitude,
            });
        }
        public void findAndPrint_Customer(int key)
        {
            Customer ForPrint = DataSource.CustomersList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }
        /// <summary>
        /// uses foreach loop to print the list of the entity' type the user asked
        /// </summary>
        /// <param name="key"></param>
        public void show_customer_list()
        {

            foreach (Customer item in DataSource.CustomersList)
            {
                Console.WriteLine(item);
                Console.WriteLine($"\n");
            }
        }


    }

}


