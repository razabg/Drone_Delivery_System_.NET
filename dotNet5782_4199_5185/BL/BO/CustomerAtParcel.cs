using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// the class represent information about the customers that send or get parcel
    /// </summary>
    public class CustomerAtParcel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CustomerAtParcel() { }

       public CustomerAtParcel(int id ,string name)
        {
            Id = id;
            Name = name;
        }


        public override string ToString()
        {
            return $"{Name} #{Id}";
        }
    }
}
