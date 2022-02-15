using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DO

{
    /// <summary>
    /// the class take care of all the xml exception
    /// </summary>
    [Serializable]
    public class XMLFileLoadOrCreateException : Exception
    {
        private string xmlFilePath;
        public XMLFileLoadOrCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadOrCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadOrCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }



    /// <summary>
    /// the class dealing with duplicate entities exception
    /// </summary>
    [Serializable]
    public class AlreadyExistsException : Exception
    {
        public int ID;
        public AlreadyExistsException() : base() { }
        public AlreadyExistsException(string msg) { Console.WriteLine(msg); }

        public override string ToString() => base.ToString() + $",The id already exist";

    }


    /// <summary>
    /// the class dealing with entity that is not exists exception
    /// </summary>
    [Serializable]
    public class NotExistsException : Exception
    {
        public int ID;
        public NotExistsException() : base() { }
        public NotExistsException(string msg) { Console.WriteLine(msg); }
        public override string ToString() => base.ToString() + $",The id does not exist";

    }
}
