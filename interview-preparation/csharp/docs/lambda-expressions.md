# Lambda Expressions

### What is?
An anonymous method
  1- No access modifier
  2- No name
  3- No return statement
  
 ### Wy do we use them?
 For convenience. We can write less code and achieve the same thing, plus our code would be more readable.
 ```c#
  class Program {
    //args => expression
    // number => number * number;
    Func<int, int> square = number => number * number;
    Console.WriteLine(square(5));
    
    //() => ... // if you dont need any arguments
    // x => ...  //if you have one argument
    // (x, y, z) => ...  //if you have multiple arguments
    
  }
 ```
