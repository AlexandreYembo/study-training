namespace BigO
{
    public class BigOAndScalability
    {
        /// <summary>
        /// BigO Name: O(n) --> Linear Time
        /// Descrition: BigO(n)
        /// Explanation: It takes linear time to find a nemo. The O(n) where BigO depends on n (number of items in the array)
        /// </summary>
        /// <param name="arr"></param>
        public void Linear(string[] arr){
            for(var i = 0; i < arr.Length; i++){
                if(arr[i] == "NEMO"){
                    System.Console.WriteLine("Found NEMO!");
                }
            }
        }
    }
}