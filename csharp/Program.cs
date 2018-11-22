using System;

namespace hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Hacker Rank Algorithms solution");
            Console.WriteLine("Type 01-Solve Me First");
            Console.WriteLine("Type 02-Diagonal Difference");

           int code = int.Parse(Console.ReadLine());
           Instance.Run((Actions) code);
        }
    }
}
