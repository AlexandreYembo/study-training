using System;

namespace project.LamdaExpressions
{
    public class LambdaExpressions
    {
        Func<int> one = () => 5;
        Func<int, int> two = x => x * 2;
        
        Func<int, int, int, int> three = (x, y, z) => x * y * z;
    }
}