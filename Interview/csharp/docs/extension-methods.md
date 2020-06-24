# Extension Methods
##### Allow us to add methods to an existing class without:
  1- changing its source code, or
  2- creating a new class that inherits from it.

```c#
  public static class StringExtensions
  {
      public static string Shorten(this String str, int numberOfWords)
      {
          if(numberOfWords < 0)
            throw new ArgumentOutOfRangeException("numberOfWords should be greater than or equal to 0.");
          
          if(numberOfWords == 0)
            return string.Empty;
            
          var words = str.Split('  ');
          
          if(words.Length <= numberOfWords)
            return str;
           
          return string.Join(" ", words.Take(numberOfWords));
      }
  }
  
  public class Program
  {
      public static void Main(string[] args){
        string test1 = "test 123";
        test1.Shorten(5);
      }
  }
```

#### When we are talking about extensions, these static methods can be troublesome at times.
The problem is if there are new implementation that uses the same name of your method.
#### *** Basically the instance methods get priority over a static methods. So your code will never be executed.
Microsoft suggest you to use extension methods only when you really have to.
