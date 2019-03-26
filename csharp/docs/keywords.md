# Keywords
More about Keywords:
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/index

## Implicit
Is used to declare an implicit user-defined type conversion operator. Use it to enable implicit conversions between a user-defined type and another type, if the conversion is guaranteed not to cause a loss of datat.
```c#
  //User-defined conversion from Digit to double
  public static implicit operator double(Digit d) => d.val;
  
  //User-defined conversion from double to Digit
  public static implicit operator Digit(double d) => new Digit(d);

  //implementation
    Digit dig = new Digit(7);
    //this call invokes the implicit "double" operator
    double num = dig;
    //this call invokes the implicit "Digit" operator
    Digit dig2 = 12;
    Console.WriteLine("num = {0} dig2 = {1}", num, dig2.val);
```
