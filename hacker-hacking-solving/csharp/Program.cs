using System;

namespace hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Hacker Rank Algorithms solution");
            Console.WriteLine("WarmUp");
            Console.WriteLine("Type 1-Solve Me First");
            Console.WriteLine("Type 2-Diagonal Difference");
            Console.WriteLine("Type 3-Plus Minus");

           int code = int.Parse(Console.ReadLine());
           Instance.Run((Actions) code);
        }
    }
}
