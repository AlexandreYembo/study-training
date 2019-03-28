# Keywords
More about Keywords:
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/index

## Implicit
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/implicit

1- Is used to declare an implicit user-defined type conversion operator. Use it to enable implicit conversions between a user-defined type and another type, if the conversion is guaranteed not to cause a loss of data.

2- By eliminating unnecessary casts, implicit conversions can improve source code readability.

```c#
  class Digit
{
    public Digit(double d) { val = d; }
    public double val;
    // ...other members

    // User-defined conversion from Digit to double
    public static implicit operator double(Digit d) => d.val;
    
    //  User-defined conversion from double to Digit
    public static implicit operator Digit(double d) => new Digit(d);
    }
}

  //implementation
    Digit dig = new Digit(7);
    //this call invokes the implicit "double" operator
    double num = dig;
    //this call invokes the implicit "Digit" operator
    Digit dig2 = 12;
    Console.WriteLine("num = {0} dig2 = {1}", num, dig2.val);
```
## Operator
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/operator

Use the ```operator``` keyword to overload a built-in operator or to provide a user-defined conversion in a class or struct declaration.
```c#
class Fraction
{
    int num, den;
    public Fraction(int num, int den)
    {
        this.num = num;
        this.den = den;
    }

      // overload operator +
    public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
      // overload operator *
    public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.num * b.num, a.den * b.den);
      // user-defined conversion from Fraction to double
    public static implicit operator double(Fraction f) => (double)f.num / f.den;
}

```

### Fixed Statement
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/fixed-statement

Prevents the garbage collector from relocating a movable variable. It only permitted in an ```unsafe``` context.
```c#
  class Point
  {
    public int x, y;
  }
  
  unsafe private static void ModifyFixedStorage()
  {
      Point pt = new Point();
      
      fixed(int* p = &pt.x)
      {
          *p = 1;
      }
  }
```

```c#
  // You can initialize a pointer by using an array.
  fixed (double* p = arr) { /*...*/ }

  // You can initialize a pointer by using the address of a variable. 
  fixed (double* p = &arr[0]) { /*...*/ }

  // The following assignment initializes p by using a string.
  fixed (char* p = str) { /*...*/ }
```

## Lock statement
  1- Acquires
