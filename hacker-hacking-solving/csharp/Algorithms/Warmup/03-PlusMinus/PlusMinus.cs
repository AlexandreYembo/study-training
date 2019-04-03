using System;
using System.Linq;

namespace hackerrank
{
    internal class PlusMinus : ICode {
        public void Run(){
            Console.WriteLine("You choose PlusMinus");
            
            double n = Double.Parse(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            plusMinus(arr, n);
        }
        private void plusMinus(int[] arr, double n) {
            double zero = arr.Count( c=> c == 0) / n;
            double negative = arr.Count( c=> c < 0) / n;
            double positive = arr.Count( c=> c > 0) / n;
            
            Console.WriteLine(positive);
            Console.WriteLine(negative);
            Console.WriteLine(zero);
        }
    }
}