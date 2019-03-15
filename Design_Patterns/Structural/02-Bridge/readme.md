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
##### 01 - Define the implementation (interface)
IImplementation.cs --> The implementation defined the interface for all implementation class. It does not have to match the Abstraction's interface.
Tipically the implementation interface provides only primitive operations, while the Abstraction defines higher-level operations based on those primitives.
```c#
  public interface IImplementation
  {
    string OperationImplementation();
  }
```

##### 02- Define the concretes Implementation
Each Concrete Implementation corresponds to a specific platform and implements the Implementation interface using that platform's API.

ConcreteImplementationA.cs
```c#
  public class ConcreteImplementationA : IImplementation
  {
    public string OperationImplementation() => "ConcreteImplementationA: The result in platform A. \n";
  }

```

ConcreteImplementationB.cs
```c#
  public class ConcreteImplementationB : IImplementation
  {
    public string OperationImplementation() => "ConcreteImplementationB: The result in platform B. \n";
  }

```
##### 03- Define the abstraction class
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

##### 04- If necessary, define the extended Abstraction
ExtendedAbstraction.cs --> You can extend the Abstraction without changing the Implementation classes.
```c#
  public class ExtendedAbstraction : Abstraction
  {
      public ExtendedAbstraction(IImplementation implementation) : base(implementation)
      {}
      
      public override string Operation() => "ExtendedAbstract:ion Extended operation with:\n" + _implementation.OperationImplementation();
  }
```

##### 05- Define the client
The client code should only depend on the Abstraction class. This way the client mode can support ant abstraction-implementation combination.

Client.cs
```c#
    public class Client
    {
        public void ClientCode(Abstraction abstraction) => Console.Write(abstraction.Operation);
    }
```

Program.cs
```c#
    public class Program
    {
        static void Main(string[] args)
        {
          Client client = new Client();
          Abstraction abstraction;
          //The client code should be able to work with any pre-configured
          //abstraction-implementation combination.
          
          //Implement ConcreteImplementationA on Abstraction class.
          abstraction = new Abstraction(new ConcreteImplementationA());
          client.ClientCode(abstraction);
          
          //Implement ConcreteImplementationB on ExtendedAbstraction class.
          abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
          client.ClientCode(abstraction);
        }
    }
```
### Pros
  1- you can create platform-independent classes and apps.
  
  2- The client code works with high-level abstractions. It is not exposed to the platform (implementation) details.
  
  3- Open/Close Principle. You can introduce new abstractions and implementations independently from each other.
  
  4- Single Responsability Principle. You can focus on hig-level logic in the abstraction and on platform details in the implementation.
  
### Cons
  1- You might make the code more complicated by applying the pattern to a highly cohesive class.
