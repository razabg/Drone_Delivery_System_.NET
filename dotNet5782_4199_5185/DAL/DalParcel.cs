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
        public void AddParcel()
        {

            Console.WriteLine("Please enter the sender's ID:\n");
            int SenderId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the target ID:\n");
            int TargetId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the parcel's weight:\n");
            float Weight = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the parcel's priority:\n");
            int Priority = int.Parse(Console.ReadLine());
            DataSource.ParcelsList.Add(new Parcel
            {
                Id = DataSource.Config.RunIdParcel++,
                SenderId = SenderId,
                TargetId = TargetId,
                Weight = Weight,
                Priority = Priority,
                Requested = DateTime.Now,
                Scheduled = null,
                PickedUp = null,
                Delivered = null,
            });

        }
        public static void findAndPrint_Parcel(int key)
        {
            Parcel ForPrint = DataSource.ParcelsList.Find(x => x.Id == key);
            Console.WriteLine(ForPrint);
        }

        
    }
}
