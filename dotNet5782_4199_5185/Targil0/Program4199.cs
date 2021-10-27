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
            int[] arr = new int[4] { 1, 2, 3, 4 };
            arr[5] = 2;
            Console.WriteLine($"{arr[5]}");
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
