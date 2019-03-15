# Bridge
Links references:
https://refactoring.guru/design-patterns/bridge

https://sourcemaking.com/design_patterns/bridge

Let you split a large class or a set of closely related classes into two separate hierarchies:
##### Abstraction and Implementation - Can be developed independently of each other.

### Problem
Imagine you have a Shape class and subclasses: Circle and Square and you need to extend implementing color classes (Red and Blue). In that case you need to create many combinations such as: BlueCircle, Red Square. The further we go, the worse it becomes because along we need to create new classes, it will increase in a desorganized way.

### Solution
To solve this problem it is necessary switch from inheritance to composition. It means that you extract one of the dimensions into a separate class hierachy.
Following this approach,  we can extract the color-related code into it own class with two subclasses: Red and Blue. The shape class then gets a reference field pointing to one of the color objects. That reference will act as a bridge between the Shape and Color classes. During the implementation, adding new classes colors will not require changing the shape hierarchy and vice versa.

### Abstraction and Implementation
  Called interface is a high-level control layer for some entity. This layer is not supposed to do any real work on its own. It should delegate the work to the implementation layer (also called platform).
  eg.: Abstraction: the interface of the APP. Implementation: OS (Windows, Linux, Mac)
  
  
### Example implementation
01 - Define the implementation (interface)
IImplementation.cs --> The implementation defined the interface for all implementation class. It does not have to match the Abstraction's interface.
Tipically the implementation interface provides only primitive operations, while the Abstraction defines higher-level operations based on those primitives.
```c#
  public interface IImplementation
  {
    string OperationImplementation();
  }
``

02- Define the concrete Implementation



Abstraction.cs --> The abstraction defined the interface for the "control" part of the two class hierarchies. It maintains a reference to an object of the Implementation hierarchy and delegates all of the real work to this object.
```c#
  public class Abstraction
  {
      protected IImplementation _implementation;

      public Abstraction(IImplementation implementation)
      {
          this._implementation = implementation;
      }
      
      public virtual string Operation() => "Abstract: Base operation with:\n" + _implementation.OperationImplementation();
  }
```

ExtendedAbstraction.cs --> You can extend the Abstraction without changing the Implementation classes.
```c#
  public class ExtendedAbstraction : Abstraction
  {
      public ExtendedAbstraction(IImplementation implementation) : base(implementation)
      {}
      
      public override string Operation() => "ExtendedAbstract:ion Extended operation with:\n" + _implementation.OperationImplementation();
  }
```
