using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;



namespace DalObject

{
    [Serializable]
    public class AlreadyExistException : Exception
    {
        public int ID;
        public AlreadyExistException() : base() { }
        public AlreadyExistException(string msg) { Console.WriteLine(msg); }
        //public NotExistException(int id, string message, Exception innerException) : base(message, innerException) => ID = ((IDAL.DO.NotExistException)innerException).ID;
        public override string ToString() => base.ToString() + $",The id does not exist";

    }
}
