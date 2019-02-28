#C# Fundamentals



#Architecture

### IL - Intermediate Language
#### CLR - Common Language Runtime - Compile langue
    1- Translate from IL code to machine Code. This process is called JIT (Just in time Compilation)
    2- When you compile an application, C# compiler compiles your code to IL (Intermediate Language) code. IL code is platform agnostics, which makes it possible to a take a C# program on a different computer with different hardware architecture and operating system and run it. For this to happen, we need CLR. When you run a C# application, CLR compiles the IL code into the native machine code for the computer on which it is running. This process is called Just-in-time Compilation (JIT).

#### Assembly
A single unit of deployment of .NET applications.
This is a more accurate description of an assembly. It's a file, in the form of a executable or a DLL, that contains one ore more namespaces and classes.

#### Architecture of .NET Applications
    1- An application written with C# consists of building blocks called classes.
    2- A class is a container for data (attributes) and methods (functions).
    3- Attributes represent the state of the application

#### Primitive Types
    byte, short, int, long, float, double, decimal, char and bool
Reference: https://docs.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2008/cs7y5x0x(v=vs.90)




# Advanced topics in c#
Quiz:
#### 1- Consider the following generic class: public class Nullable<T>
We need to apply a constraint such that T is only a value type. What should we type after the name of the class?
##### Answer: 
```c#
    where T : struct
```

#### 2- What is a delegate?
##### Answer: It is a reference to a group of method. A delegate is an instance of a type that derives from MulticastDelegate. This class provides the ability to call one or more methods.

#### 3- What is the output of this piece of code?
```c#
Func<int, int> square = n => n * n;
```
Console.WriteLine(square(5));
##### Answer: 25

#### 4- We need a reference to the following method. Which delegate should we use to store the reference?
```c#
    private static float CalculateDiscount(float price){
        return 0;
    }
```
##### Answer: Func
Func is a delegate that represents a method that returns a value. ```c# Func<float, float> ``` can be used to store a reference to a method that gets an argument of type float, and returns a float.

#### 5- We would like to call the Shorten method below on an instance of a string object. What should we change in the method declaration below?
```c#
    public static class StringExtensions{
        public static void Shorten(int numberOfWords){
            
        }
    }
```
##### Answer: Add "this string str" as the first argument of the method.

#### 6- What is the result of the following piece of code?
```c#
    var numbers = new List<int>{4, 5, 1, 2, 3};
    var number = numbers.Single(n => n == 10);
    Console.WriteLine(number);
```
##### Answer: An exception will be thrown at runtime.
The single() method throws an exception if no object matching the condition is found in the collection.

#### 7- 
```c#
    int? n = null;
    int m = n;
```
The following piece of code does not compile. Why?
##### Answer: n is a nullable and cannot be assigned to an int. We need to call the GetValueOrDefault() method.

#### 8- What is the difference between var and dynamic in the code below?
```c#
    dynamic n = 5;
    var m = n;
```
##### Answer: The resoulution of types, properties and methods for the variables defined with var is checked at compile-time. We use dynamic to postpone the type resolution at runtime.


### Tips
#### Understanding Yield Return in C#
Link reference: https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
