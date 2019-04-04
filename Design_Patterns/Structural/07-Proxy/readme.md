# Proxy
Lets you provide a substitute or placeholder for another object.

### Problem
You have a massive object that consumes a vast amount of system resources. You need it from time to time, but not always. You could implement lazy initialization and all of object's clients would need to execute some deferred initialization code. This would probably cause a lot of ```code duplication```.

### Solution
This pattern suggests you create a new proxy class with the same interface as an original service object. Upon receiving a request from a client, the proxy creates a real service object and delegates all the work to it.

```
  Client 1    --
  Client 2    --    Proxy   --- DataBase
  Client 3    --
The proxy disguises itself as a database object. It can handle lazy initialization and rsult caching wuthout the client or the real database object even knowing.
```

### Benefit
If you need to execute something either before or after the primary logic of the class, the proxy lets you do this without changing that class. Since the proxy implements the same interface as the original class, it can be passed to any client that expects a real service object.

### Structure
