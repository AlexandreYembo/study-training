# Generics
Generics were added to version 2.0.
Introduce to .NET framework the concept of type parameters, that is possible design classes and methods that defer the specification of one or more types, until the classes or methods is declared and instantiated by client code.

  1- Use generic types to maximize code reuse, type safety, and performance.
  2- The most common use of generics is to create collection classes.
  3- The .NET Framework class library contains several new generic collection classes in the System.Collections.Generic namespace. 
   ##### These should be used whenever possible instead of classes such as ArrayList in the System.Collections namespace.
  4- You can create your own generic interfaces, classes, methods, events and delegates.
  5- Generic classes may be constrained to enable access to methods on particular data types.
  6- Information on the types that are used in a generic data type may be obtained at run-time by using reflection.

### Contraint


where T : IComparable --> As in applying a constraint to an interface
where T : Product --> We can apply a constraint to a class.
where T : struct --> Should be a value type
where T : class --> Should be a reference type
where T : new() --> T is an object that has a default constructor.

#### constraint to an interface
```c#
  public class Utilities<T> where T : IComparable
  {
    public int Max(int a, int b) => a > b ? a : b;
    
    public T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
  }
```

#### constraint to a class.
```c#
  public class Product
  {
    public string Title {get;set;}
    public float Price {get;set;}
  }
  
  public class Book : Product
  {
     public string Isbn {get;set;}
  }
  
  public class DiscountCalculator<TProduct> where TProduct : Product
  {
      public float CalculateDiscount(TProduct product) => product.Price
  }
```

#### constraint to value type
```c#
  // In this class I am going to store it as an object because I want it to be nullable
  public class Nullable<T> where T : struct
  {
      public object _value;
      
      public Nullable(){}
      public Nullable(T value)
      {
          _value = value;
      }
      
      public bool HasValue => value != null;
      
      public T GetValueOrDefault() => HasValue ? (T) _value : default(T);
  }
  
   public class Program
   {
      //Implementation
      var number = new Nullable<int>(5);
      Console.WriteLine("Has Value ?" + number.HasValue);
      Console.WriteLine("Value: " + number.GetValueOrDefault());
   }
```
##### In c# value types cannot be null

#### constraint to class and default constructor: new()
```c#
  //new() --> used to instance new T()
  public class Utilities<T> where T : IComparable, new()
  {
    public int Max(int a, int b) => a > b ? a : b;
    
    public T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
    
    public void DoSomething(T value){
        // if you need to instantiate "T" here you need a default constructor.
        // in this case you need to instance new() in the class
        var obj = new T();
    }
  }
```
