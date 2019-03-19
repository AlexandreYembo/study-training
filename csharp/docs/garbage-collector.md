# Garbage Collector
Link reference: https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals

In CLR the garbage collector is used as an automatic memory manager.

### Benefits
  1- Enables you to develop your application without having to free memory.
  
  2- Allocates objects on the managed heap efficiently.
  
  3- Reclaims objects that are no longer being used, clears their memory, and keeps the memory available for future allocations.
#### Managed objects automatically get clean content to start with, so their constructors do no have to initialize every data field.

  4- Provides memory safety by making sure that an object cannot use the content of another object.


#### Fundamentals of memory
- Virtual Memory can be in three states:

  1- Free: The block of memory has no references to it and is available for allocation.
  
  2- Reserved: The block of memory is available for use and cannot be used for any other allocation request. However, you cannot store data to this memory block until it is committed.
  
  3- Committed: The block of memory is assigned to physical storage.
  
  After the Garbage Collector is initialized by the CLR, it allocates a segment of memory to store and manage objects. This memory is called the Managed Heap

#### When Garbage collection occurs

#### The Managed heap
  After the garbage collector is initialized by the CLR, it allocates a segment of memory to store and manage objects. This memory is called the managed heap, as opposed to a native heap in the operating system.
  
  1- For each managed process, there is a managed heap. All threads in the process allocate memory for objects on the same heap.
  
  2- When a garbage collection is triggered, the garbage collector reclaims the memory that is occupied by dead objects. The reclaiming process compacts live objects so that they are moved together, and the dead space is removed, thereby making the heap smaller.
   
   *** This ensures that objects that are allocated together stay together on the managed heap, to preserve their locality.
  
#### Generations
  1- The heap is organized into generations so it can handle long-lived and short-lived
  
  2- There are 3 generations of object on the heap:
   
   Generation 0 -> Youngest and contains short-lived objects. (eg. temporary variable) -> Most objects are reclaimed and not survive to the next generation.
        Garbage collection occurs most frequently in this generation.
  
  Generation 1 -> Contains short-lived object and serves as a buffer between short-lived and long-lived objects.
  
  Generation 2 -> Contains long-lived objects. (eg. object in a server application that contains static data that is live for the duration of the process)
  
##### A generation 2, garbage collection is also known as a full garbage collection, because it reclaims all object in all generations (that is, all objects in the managed heap).

##### Survival and promotions -> Objects that are not reclaimed in a garbage collection are known as Survivor and are promoted to the next generation.
##### Object that survive a generation 0 are promoted to generation 1 and so on. Objects that survive a generation 2 remain in generation 2.
##### When is detected that the survival rate is high in a generation, it increases the threshold of allocations for that generation.

##### CLR continually balances 2 priorities: not letting an application's working set get too big and not letting the Garbage Collection take too much time.

##### Large object heap is not compacted. because copying large objects imposes a performance penalty. However, after the .NET Framework 4.5.1 you can use the GC.Settings.LargeObjectHeapCompactionMode property to compact the large object heap on demand.
```c#
  [set: System.Security.SecurityCritical]
  public static System.Runtime.GCLargeObjectHeapCompactionMode LargeObjectHeapCompactionMode { get; set; }
```
```c#
  GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
  GC.Collect(); 
```
#### Innformation used by Garbage Collector to determine whether object are live
Stack root -> Stack variables provided by just-in-time(JIT) compiler and stack walker.

Garbage collection handles -> Handle that point to managed objects and that can be allocated by user code or by the CLR.

Static data -> Static objects in application domains that could be referencing other objects.

##### Before a garbage collection starts, all managed threads are suspended except fo the thread that triggered the garbage collection.

#### Manipulating unmanaged resources
If your managed objects reference unmanaged objects by using their native file handles, you have to explicitly free the unmanaged objects, because Garbage collector tracks memory only on the managed heap.
To perform the cleanup, you can make your managed object finalizable. It consists of cleanup actions that you execute when the object is no longer in use.
