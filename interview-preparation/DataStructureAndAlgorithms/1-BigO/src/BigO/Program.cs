using System;
using System.Linq;

namespace BigO
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[10000];
            arr = Enumerable.Repeat("NEMO", 10000).ToArray();

           // new BigOAndScalability().RunArray(arr);
        }
    }
}
