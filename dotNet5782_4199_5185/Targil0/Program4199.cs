using System;

namespace Targil0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome4199();
            Welcome5185();
            Console.ReadKey();
        }

        static partial void Welcome5185();
        private static void Welcome4199()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0} welcome to my first console application", name);
        }
    }
}
