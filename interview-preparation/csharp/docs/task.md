# Task
  1- Is an object that represents some work that should be done.
  
  2- A task represents some asynchronous operation and is part of the Task Parallel Library.
  
  3- The task is an object that represents some work that should be done.
  
  4- The task can tell you if the work is completed and if the operation returns a result, the task gives you the result.

### Why we need?
It can be used whenever you want to execute something in parallel. Asynchronous implementation is easy in a task, using ```async``` and ```await``` keywords.

### How to implement
```C#
  Task<string> task = Task.Run(() => return "Hello!");
  Console.WriteLine(task.result);

```

### Differences Between Task and Thread
#### Thread
  1- Is used for creating and manipipulating a thread in Windows.
  
  2- There is no direct mechanism to return the result.
  
  3- Does not support cancellation.
  
  4- Can only have one task running at a time.
  
  5- A new Thread() is not dealing with Thread pool thread.

#### Task
  1- Represents some asynchronous operation and is part of t he Task Parallel Library, a set of APIs for running tasks asynchronously and in parallel.
  
  2- Can return a result.
  
  3- Supports cancellation through the use of cancellation tokens.
  
  4- Can have multiple processes happening at the same time.
  
  5- We can easily implement Asynchronous using ```async``` and ```await``` keywords.
  
  6- Use thread pool thread.
  
  7- Is a higher level concept than Thread.
