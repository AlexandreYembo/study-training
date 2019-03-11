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
