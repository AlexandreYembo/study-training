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
  1- Is used for creating and manipipulating

#### Task
