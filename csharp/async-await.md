# Asynchronous Programming with Async / Await
##### Synchronous Program Execution
  1- Program is executed line by line, one at a time.
  2- When a function is called, program execution has to wait until the function returns.

##### Asynchronous Program Execution
  1- When a function is called, program execution continues to the next line, without waiting for the function to complete.

##### Difference
  1- Asynchronous programming improves responsiveness of your application.

##### When to use asynchronous?
  1- Accessing the Web
  2- Working with files and databases
  3- Working with images
  
##### How?
  1- Traditional approaches:
    - Multi-theading
    - Callbacks
  2- New approach since NET 4.5
    - Async / Await (called Task-based Asynchronous Model)
  
 ##### What is a Task?
A Task is an object that encapsulates the state of an asynchronous operation. It is not the end result.
Two forms. Generic and non-generic. If your method return a string you specify dddddddddthe return. 
```c#
  public async Task<string> DownloadHtml()
```
If your method is void, you need to use the non-generic version of Task.
```c#
  public async Task DownloadHtml()
```
 
 ### Async / Await
We decorate the method async and Task.
We use convension in the name:
```c#
  public async Task DownloadHtmlAsync()
```
When we call an specific method, database, or to get some information from Web, when we use asynchronous async decoration, we need to set a mark to the compiler called await.
```c#
    var webClient = new WebClient();
    var html = await webClient.DownloadStringTaskAsync(url);
```
##### await is just a marker for the compiler. When the compiler sees that, it knows that this operation os going to be costly and it may take a bit of time.
In that case, instead of blocking this thread, it is going to return the control immediately to the caller DownloadHtmlAsync().
You use await when the rest of that method cannot be executed until the result is ready.

##### For Web application
  Typically in a web application, when a request comes to the server, a thread is allocated to handle that request. During execution of that request, if there is a blocking operation that thread is going to be busy and the machine has a limited number of threads. In that case, if we have a lot of concurrent connections and all threads are busy waiting for a blocking operation, that server becomes unresponsive. The only way is add more server which is scalling out.
  We can improve this by using an asynchronous model. When you execute a blocking operation, the control immediatelly returns to the thread, and that thread can be used to handle another request.
### This model we can Scale up instead of scalling out. 
