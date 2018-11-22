
using System;

namespace hackerrank {
    internal class DiagonalDifference : ICode {
        public void Run(){
            
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] arr = new int[n][];

            for (int i = 0; i < n; i++) {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = diagonalDifference(arr);

            Console.WriteLine(result);
        }
        private int diagonalDifference(int[][] arr) {
            int a = 0;
            int b = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                a += arr[i][i];
                b += arr[i][(arr.Length - 1) - i];
            }

            return Math.Abs(a - b);
        }
    }     
} 