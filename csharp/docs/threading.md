# Threading
  1- It is a process.
  
  2- Each thread defines a unique flow of control.
  
  3- It is used for complicated and time consuming operations (set different execution paths or threads, witch each thread performing a particular job).
  
```c#
        // Creating instance for  
        // mythread() method 
        MyThread obj = new MyThread(); 
```  
  
### Life Cycle
Starts when an object of the System.Threading.Thread class is created and ends when the thread is terminated or completes execution.

  ``` Unstarted state ``` -> It is situation when the instance of the thread is created but the Start method is not called.
  ```c#
        // Creating and initializing  
        // threads Unstarted state 
        Thread thr1 = new Thread(new ThreadStart(obj.thread)); 
  ```
  
  ``` Runnable State ``` -> It that is ready to run is moved to runnable state. In that state, a thread might actually be running or it might be ready to run at any instant of time.
  
  ``` Running State ``` -> A thread that is running. The thread gets the processor.
  ```c#
       // Running state 
       thr1.Start(); 
       // thr1 is resume to running state 
        thr1.Resume(); 
  ```
  
  ``` Not Runnable State``` -> A thread that is not executable:
    
    -> sleep() method is called.
    
    -> Wait() method is called.
    
    -> Due to I/O request.
    
    -> Suspend() method is called.
```c#
      // thr1 is in suspended state 
      thr1.Suspend(); 
```
    
  
  ``` Dead State ``` -> When the thread completes its task, then thread enters into dead, terminates, abort state.
