using System;
using System.IO;

namespace hackerrank
{
    public class SherlockAndDivisors :ICode
    {
         public void Run(){
           using (StreamReader file = new StreamReader("Algorithms/Mathematics/sherlock-and-divisors/input/input00.txt"))
            {
                string line;
                while((line = file.ReadLine()) != null)  
                {  
                    int result = divisors(Convert.ToInt32(line));
                    System.Console.WriteLine(result.ToString());  
                }   
            }
         }

         public int divisors(int n){
            int result = 0;
            while((n%2) == 0 && n > 1){
                n = n/2;
                result++;
            }
            
            var ans = 0;
            for (var i = 1; i * i <= n; i += 2)
            if (n % i == 0)
            {
                ans++;
                if (i != n / i)
                    ans++;
            }


            return ans * result;
         }
    }
}