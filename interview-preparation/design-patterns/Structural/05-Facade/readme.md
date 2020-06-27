# Facade
Link reference: https://refactoring.guru/design-patterns/facade
Provides a simplified interface to a library, a framework, or any complex set of classes.


### Problem
Imagine that you must make your code work with a sophisticated library or framework. You will need to initialize all of those objects, keep track of dependencies, execute methods in the correct order, and so on.

As a result, the business logic of your classes would become tightly coupled to the implementation details of 3rd-party classes, making it hard to comprehend and maintain.

### Solution
Use this pattern to provide an interface to a complex subsystem. It might provide limited functionality in comparision to work with the subsystem directly.

Using facade you can integrate your app with libraries that has dozens of features, but you just need a tiny bit of its functionality.

### Structure
```
Client -> 
        Facade  ->  Subsytem 1, Subsytem 2, Subsytem 3
        Additional Facade -> Subsytem 1, Subsytem 2, Subsytem 3
```           
##### 1- Facade:
Provides convenient access to a particular part of the subsystem's functionality.
##### 2- Additional Facade
Can be created to prevent polluting a simple facade with unrelated features that might make it yet another complex structure. Can be used by both clients and other facades.
##### 3- Complex Subsystem
Has dozens of various objects.
##### 4- Client
Uses the facade instead of calling the subsystem objects directly.

### Applicability
Use when you need to have a limited but straightfowards interface to a complex subsystem.

Use when you want to structure a subsystem into layers.

### Pros
You can isolate your code from the complexity of a subsystem.

### Cons
A facade can become a ```god object``` coupled to all classes of an app.
