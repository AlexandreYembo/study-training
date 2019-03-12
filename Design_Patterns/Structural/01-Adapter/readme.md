# Adapter
Links references:
https://refactoring.guru/design-patterns/adapter

https://sourcemaking.com/design_patterns/adapter

  1- Convert the interface of a class into another interface clients expect. Adapter lets classes work together that could not otherwise because of imcompatible interfaces.
  
  2- Wrap an existing class with a new interface.
  
  3- Impedance match an old component to a new system.
  
  4- It is about creating an intermediary abstraction that translate, or maps the old component to the new system.
  
  5- Can be implemented either with inheritance or with aggregation.
  
  6- Can not only convert data into various formats but can also help objects with different interfaces collaborate.
  

### Scenario
  Imagine you created an app that download stock using XML format. In future you decide to implement some features, like integration from another partners. But they only work with JSON format.

#### Problem
  You could change the code to adapt the new integration, but It will break some existing code.

### Solution
  You can create adapter to resolve.
  
   1- The adapter gets an interface, compatible with one of the existing objects.
   
   2- Using this interface, the existing object can safely call the adapter's methods.
   
   3- Upon receiving a call, the adapter passes the request to the second object, but in a format and order that the second object expects.
   
 ##### Sometimes it is even possible to create a two-way adapter that can convert the calls in both directions.
 
 ### Structure
 
#### Object Adapter
  This implementation uses the composition principle: the adapter implements the interface of one object and wraps the other one. It can be implemented in all popular programming languages.
  
  You have:
  ```c#
  Client ->   Client Interface <interface>    <- Adapter                    <->     Service
                    +method(data)              +method(data)                        +ServiceMethod(specialData)
                                               +ConvertToServiceFormat(data)
                                               +return ServiceMethod(specialData)
```
#### Class Adapter
   This implementation uses inheritance: the adapter inherits interfaces from both objects at the same time. Note that this approach can only be implemented in programming language that support multiple inheritance.
   
   The class adapter does not need to wrap any objects because it inherits behaviors from both the client and the service. The adaptation happens within the overridden methods. The resulting adapter can be used in place of an existing client class.
   
#### Pros
  1- Single Responsability Principle - You can separate the interface or data conversion code.
  2- Open/Closed Principle - You can introduce new types of adapters into the program without breaking the existing client code.

#### Cons
  1- The overall complexity of the code increases because you need to introduce a set of new interfaces and classes.
