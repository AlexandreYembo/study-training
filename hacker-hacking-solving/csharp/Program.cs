using System;

namespace hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Hacker Rank Algorithms solution");
            Console.WriteLine("WarmUp");
            Console.WriteLine("Type 'SolveMeFirst' for Solve Me First");
            Console.WriteLine("Type  'DiagonalDifference' for Diagonal Difference");
            Console.WriteLine("Type 'PlusMinus' for Plus Minus");
            
            Console.WriteLine("############# Mathematics ##############");
            Console.WriteLine("Type 'SherlockAndDivisors' for Plus Minus");

           string code = Console.ReadLine();
           Instance.Run(code);
        }
    }
}
