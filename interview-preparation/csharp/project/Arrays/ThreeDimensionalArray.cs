namespace project.Arrays
{
    public class ThreeDimensionalArray
    {
        public void Create()
        {
            // // Three-dimensional array.
            // int[, ,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
            //                      { { 7, 8, 9 }, { 10, 11, 12 } } };
            // // The same array with dimensions specified.
            // int[, ,] array3Da = new int[2, 2, 3] { { { 1, 2, 3 }, { 4, 5, 6 } },
            //                            { { 7, 8, 9 }, { 10, 11, 12 } } };

            string[, ,] array3D = new string[,,] { { { "AA", "BB", "CC" }, { "ZZ", "HH", "MM" } },
                                  { { "JJ", "8R", "9A" }, { "10X", "11S", "12L" } } };
        }
    }
}