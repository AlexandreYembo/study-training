# Collections
- List

#### System Collections Generics
- ```Dictionary<TKey, TValue>``` -> Represents a collection of key/value pairs.

- ```List<T>``` -> Represents list of object, can be accessed by index. 

- ```Queue<T>``` -> Represents a first in/first out (FIFO) collection of objects.

1- ```Enqueue``` -> Add item to the queue.

2- ```Dequeue``` -> Remove item from the queue.

- ```SortedList<TKey, TValue>``` -> Represents a collection of key/value pairs that are sorted by key based on he associated IComparer<T> implementation.

- ```Stack<T>``` -> Represents a last in, first out (LIFO) collection of objects.

1- ```Push``` -> Add the item to the first element each time it is called. The existing elements goes to the next index.

2- ```Peek``` -> Always call the first element from the stack but don't remove it.

3- ```Pop``` -> Always call the first element from the stack but remove the item.

#### System Collections
- ```ArrayList``` -> Represents an array of objects whose size is dinamically increased as required.

- ```Hashtable``` -> Represents a collection of key/value pairs that are organised based on the hash code of the key.

- ```Queue``` -> Represents the first in / first out collection of objects.

- ```Stack``` -> Represents the last in / first out collection of objects.


#### System Collections Concurrent
Provides several thread-safe collections classes that should be used in place of the corresponding types in the ```system.collections``` and ```system.collections.generics```