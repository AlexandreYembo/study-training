# Garbage Collector
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
