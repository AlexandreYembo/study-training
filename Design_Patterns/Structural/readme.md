# Design Patterns

## Structural design patterns

### [Adapter](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/01-Adapter/readme.md)
  1- Makes things work after they are designed.
  
  2- Is retrofitted to make unrelated classes work together.
  
  3- Provides a different interface to the wrapped object. Proxy provides the same interface. Decorator provides an enhanced interface.
  
  4- Adapter is meant to change the interface of an existing object. Decorator enhances another object without changing its interface. Decorator supports recursive composition, which is not possible when you use Adapter.
  
*** Remember: Adapter makes two existing interfaces work together as opposed to defining an entirely new one.

#### Bridge, State, Strategy (and to some degree Adapter) 
  1- have very similar structures. 
  
  2- Indeed, all of these are based on composition, which is delegating work to other objects.
  
  3- They solve different problems.

### [Bridge](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/02-Bridge/readme.md)
  1- Makes them work before they are.
  
  2- Is designed up-front to let the abstraction and the implementation vary independently. Adapter is commoly used with an existing app to make some otherwise-incompatigle classes work together nicely.
  
  3- Used when you want to devide and organize a monolithic class that has several variants of some functionality(eg. if the class can work with various database servers).
  
  4- Used when you need to extend a class in several orthogonal (independent) dimensions. The Bridge suggests that you extract a separate class hierarchy for each of the dimensions.
  
  5- Used if you need to be able to switch implementations at runtime. Although it is optional, the Bridge patterns lets you replace the implementation object inside the abstraction. It is as easy as assigning a new value to a field.
  
  6- You can use Abstract Factory along with Bridge. This pairing is useful when some abstractions defined by Bridge can only work with specific implementations. In this case, Abstract Factory can encapsule the relations and hide the complexity from the client code.
  
  7- You can combine Builder with Bridge: the director class plays the role of the abstraction, while different builders act as implementations.

### [Composite](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/03-Composite/readme.md)
  1- 


### Decorator
  1- Provides an enhanced interface.
  
  2- Decorator enhances another object without changing its interface.
  
  3- Is more transparent to the application than an adapter is.
  
  4- Supports recursive composition, which is not possible with pure Adapters.
  

### Facade
  1- Defines a new interface of an existing, whereas Adapter reuses an old interface. Adapter usually wraps just one object, while Facade works with an entire subsystem of objects.

### Proxy
  1- Provides the same interface. Adapter provides a different interface to its subject. Decorator provides an enhanced interface.




## Behavioral design patterns
