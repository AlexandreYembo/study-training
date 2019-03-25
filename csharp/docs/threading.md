# Threading
  1- It is a process.
  
  2- Each thread defines a unique flow of control.
  
  3- It is used for complicated and time consuming operations (set different execution paths or threads, witch each thread performing a particular job).
  
### Life Cycle
Starts when an object of the System.Threading.Thread class is created and ends when the thread is terminated or completes execution.

  1- ``` Unstarted state ``` --> It is situation when the instance of the thread is created but the Start method is not called.
  
  2- ``` Runnable State ``` --> It that is ready to run is moved to runnable state. In that state, a thread might actually be running or it might be ready to run at any instant of time.
  
  3- ```
  
  3- The Not Runnable State
