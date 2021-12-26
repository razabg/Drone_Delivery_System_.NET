using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;



namespace IDAL.DO

{
    [Serializable]
    public class AlreadyExistsException : Exception
    {
        public int ID;
        public AlreadyExistsException() : base() { }
        public AlreadyExistsException(string msg) { Console.WriteLine(msg); }
       
        public override string ToString() => base.ToString() + $",The id does not exist";

    }



    [Serializable]
    public class NotExistsException : Exception
    {
        public int ID;
        public NotExistsException() : base() { }
        public NotExistsException(string msg) { Console.WriteLine(msg); }
        public override string ToString() => base.ToString() + $",The id does not exist";

    }
}
