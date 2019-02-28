# Iterator block implementation
#### The difference between using iterator blocks for methods returning IEnumerator and those returning IEnumerable.

### Generic vs nongeneric interfaces

```c#
  //Generic
   static IEnumerator GetCounter()
    {
        for (int count = 0; count < 10; count++)
        {
            yield return count;
        }
    }
    //Compiled code
    private sealed class <GetCounter>d__0 : IEnumerator<object>, IEnumerator, IDisposable
    
  //Non Generic
  static IEnumerator<int> GetCounter()
    {
        for (int count = 0; count < 10; count++)
        {
            yield return count;
        }
    }
    
   //Compiled code
   private sealed class <GetCounter>d__0 : IEnumerator<int>, IEnumerator, IDisposable
```
Likewise the iterator implements IEnumerator<int> when you uses Non Generic instead of IEnumerator<object> that uses generic type.
##### The type involved here is called the yield type of the iterator.
##### Every yield return statement has to return something which can be implicitly converted to the yield type


