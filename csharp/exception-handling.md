# Exception Handling
To deal with an unexpected or exceptional situations that arise when a program is running.
We need to avoid that application crash when there is an exception.

#### Stack trace
A stack trace shows the sequence of methods in the reverse order that were called until the exception was thrown.

#### Handle exception
Use try catch blocks.

#### Catch
Source -> Represents DLL or the assembly that this exception happened in.
TargetSite -> Is the method where the exception happened.
InnerException -> Represents an exception that could be inside this exception.

###### To create is the most specific to more Generic in order.

### Why do we need finlally block?
In .NET we have resources that are not managed by CLR (unmanaged resources), there is no garbage collection applied to them.
##### Examples
File handles, database connections, network connections, graphic handles and in situations like that we need to manually do the cleanup.

*** Any class that uses unmanaged resources is expected to implement an interface called IDisposable.
```c#
  public class Test{
      StreamReader streamReader = null;
      try
      {
          streamReader = new StreamReader("@c:\file.zip");
          var content = streamReader.ReadToEnd();
      }
      catch (Exception ex)
      {
          Console.WriteLine("Sorry, an unexpected error occurred");
      }
      finally
      {
          if(streamReader != null)
              streamReader.Dispose();
      }
  }
```
##### There is a cleaner way to use in c#. Instead of using try block, we can use the Using statement:
```c#
    try
    {
          using(var streamReader = new StreamReader("@c:\file.zip"))
          {
              var content = streamReader.ReadToEnd();
          }
     }
     catch (Exception ex)
     {
          Console.WriteLine("Sorry, an unexpected error occurred");
     }
```
When we use the Using statement internally the compiler will create a finally block under the hood which call the Dispose method
of StreamReader
