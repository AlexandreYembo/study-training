# Design Patterns

## Structural design patterns

### [Adapter](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/01-Adapter/readme.md)
  1- Makes things work after they are designed.
  
  2- Is retrofitted to make unrelated classes work together.
  
  3- Provides a different interface to the wrapped object. ```Proxy``` provides the same interface. ```Decorator``` provides an enhanced interface.
  
  4- Adapter is meant to change the interface of an existing object. ```Decorator``` enhances another object without changing its interface. ```Decorator``` supports recursive composition, which is not possible when you use Adapter.
  
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
  1- You can use Builder when creating complex Composite trees because you can program its construction steps to work recursively.
  
  2- Chain of responsability is often used in conjunction with Composite. In this case, when a leaf component gets a request, it may pass it through the chain of all of the parent components down to the root of the object tree.
  
  3- You can use Iterators to traverse Composite trees.
  
  4- You can use Visitor to execute an operation over an entire Composite tree.
  
  5- You can implement shared leaf nodes of the Composite tree as Flyweights to save some RAM.
  
  6- Has a similar structure diagrams of ```Decorator```, since both rely on recursive composition to organize an open-ended number of objects.
  
  7- Decorator can cooperate extending the behavior of a specific object in the composite tree.
  
  8- Designs that make heavy use of ```Composite``` and ```Decorator``` can often benefit from using Prototype. Applying the pattern lets you clone complex structures instead of re-constructing them from scratch.
 
### [Decorator](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/04-Decorator/readme.md)
  1- Provides an enhanced interface.
  
  2- Decorator enhances another object without changing its interface.
  
  3- Is more transparent to the application than an adapter is.
  
  4- Supports recursive composition, which is not possible with pure Adapters. Has a similar structure diagrams of Composite.
  
  5- Is like a Composite but has only one child component.
  
  6- Adds additional responsabilities to the wrapped object. Composite just "sums up" its children's result.
  
  7- ```Chain of Responsibility``` and Decorator have similar class structures. Both rely on recursive composition to pass the execution through a series of objects. However, there are several crucial differences:
  
   CoR -> can execute arbitrary operations independently of each other. They can also stop passing the request further at any point
    
   Decorator -> Are not allowed to break the flow of the request.
   
   8- Is like ```Composite``` but only has one child component and another difference is Decorator adds additional responsebilities to the wrapped object while ```Composite``` just 'Sums up' it children's result.
   
   9- Designs that make heavy use of ```Composite``` and ```Decorator``` can often benefit from using Prototype. Applying the pattern lets you clone complex structures instead of re-constructing them from scratch.
   
   10- Let you change the skin of an object, while ```strategy``` lets you change the guts.
   
   11- Have the similar structure with ```Proxy```. Both are built on the composition principle. But ```Proxy``` usually manages the life cycle of its service object on its own, whereas the composition of ```Decorators``` is always controlled by the client.
  
### [Facade](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/05-Facade/readme.md)
  1- Defines a new interface of an existing, whereas Adapter reuses an old interface. Adapter usually wraps just one object, while Facade works with an entire subsystem of objects.
  
  2- ```Abstract Factory``` can serve as an alternative when you only want to hide the way the subsystem objects are created from the client code.
  
  3- ```Flyweight``` shows how to make lots of little objects, whereas ```Facade``` shows how to make a single object that represents an entire subsystem.
  
  4- ```Mediator``` have similar jobs:
    
   - Facade defines a simplified interface, but it does not introduce any new functionality. The subsystem itself is unaware of the facade.
   
   - Mediator: centralizes communication between components of the system, The components only know about the mediator object and don't communicate directly.
   
 5- Can often be transformed into a ```Singleton``` since a single facade object is sufficient in most cases.
 
 6- Similar to ```Proxy``` in that both buffer a complex entity and initialize it on its own. Unlike ```Facade```, ```Proxy``` has the same interface as its servicee object, which makes them interchangeable.

#### [Implementation](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/05-Facade/implementation.md)

### [Proxy](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/07-Proxy/readme.md)
  1- Provides the same interface. Adapter provides a different interface to its subject. Decorator provides an enhanced interface.

#### [Implementation](https://github.com/AlexandreYembo/study-training/blob/master/Design_Patterns/Structural/07-Proxy/implementation.md)



## Behavioral design patterns
