# Iterator block implementation
  1- An iterator, in the context of C#, is a block of code that returns an ordered sequence of values of a collection or array. It is a member function implemented using the iterator block, which contains one or more statements containing the "yield" keyword.
  
  2- In general, an iterator is similar to a database cursor in that it provides access to data elements in a collection, but does not perform iteration. An iterator can be implemented in C# as a method, operator, or get accessor. For example, an iterator can be used to traverse a collection of strings to display the content of each string in the collection.
 More details in link: https://www.techopedia.com/definition/20184/iterator-c-sharp
   
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


