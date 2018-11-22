using System;
using System.Collections.Generic;
using System.IO;

namespace hackerrank {
    internal class SolveMeFirst : ICode {
        public void Run(){
            Console.WriteLine("Type 2 numbers for sum");
            int val1 = Convert.ToInt32(Console.ReadLine());
            int val2 = Convert.ToInt32(Console.ReadLine());
            int sum = solveMeFirst(val1,val2);
            Console.WriteLine("Result = " + sum);
        }
        private int solveMeFirst(int a, int b)  => a + b;
    }     
} 