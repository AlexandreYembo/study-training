# Design Patterns

## Structural design patterns

### [Adapter](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/01-Adapter/readme.md)
  1- Makes things work after they are designed.
  
  2- Is retrofitted to make unrelated classes work together.
  
  3- Provides a different interface to its subject. Proxy provides the same interface. Decorator provides an enhanced interface.
  
  4- Adapter is meant to change the interface of an existing object. Decorator enhances another object without changing its interface.

*** Remember: Adapter makes two existing interfaces work together as opposed to defining an entirely new one.

### Bridge
  1- Makes them work before they are.
  
  2- Is designed up-front to let the abstraction and the implementation vary independently.

### Decorator
  1- Provides an enhanced interface.
  
  2- Decorator enhances another object without changing its interface.
  
  3- Is more transparent to the application than an adapter is.
  
  4- Supports recursive composition, which is not possible with pure Adapters.
  

### Facade
  1- Defines a new interface of an existing, whereas Adapter reuses an old interface.

### Proxy
  1- Provides the same interface. Adapter provides a different interface to its subject. Decorator provides an enhanced interface.


## Behavioral design patterns
