using System;
using System.Collections;

namespace project.iterators
{
    public class YieldReturn
    {
        public void Start(){
            WithoutYield();
            WithYield();
        }

       /// <summary>
       /// Normal funciton without Yield return
       /// </summary>
        private void WithoutYield(){
            int[] a = new int[10];
            a = funcNotYield(2, 10);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        private int[] funcNotYield(int start, int number){
            int[] arrNumber = new int[number];
            for (int i = 0; i < number; i++)
            {
                arrNumber[i] = start + 2 * i;
            }
            return arrNumber;
        }


    /// <summary>
    /// Function that implements yieldReturn
    /// </summary>
        private void WithYield(){
            foreach (var item in funcWithYield(2, 10))
            {
                Console.WriteLine(item);
            }
        }

        private IEnumerable funcWithYield(int start, int number){
            for (int i = 0; i < number; i++)
            {
                yield return start + 2 * i;
            }
        }
    }
}