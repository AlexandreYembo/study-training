# Design Patterns

## Creational design patterns
Creational design patterns provide various object creation mechanisms, which increase flexibility and reuse of existing code.

    1- These design patterns are all about class instantiation.
    2- Class-creation patterns.
        (use inheritance effectively in the instantiation process)
    3- Object-creational patterns.
        (use delegation effectively to get the job done)
    
#### Sometimes creational patterns are complementary:
    1- Builder can use one of the other patterns to implement which components get built.
    2- Abstract Factory, Builder and Prototype can use Singleton in their implementations.
    3- Often, designs start out using Factory Method (less complicated, more customizable, subclasses proliferate) and evolve toward Abstract Factory, Prototype, or Builder (more flexible, more complex) as the designer discovers where more flexibility is needed.


### Abstract Factory
        1- Creates an instance of several families of classes
        2- Emphasizes a family of product objects (either simples or complex).
        3- Is concerned, the product gets returned immediately.
        4- More Flexible, but more complicated
        5- Classes are often based on set of FactoryMethods, but you can also use Prototype to compose the methods on theses classes.
        6- Can serve as an alterantive to Facade when you only want to hide the way the subsystem objects are created from the client code.
        7- You can use along with Bridge. This pairing is useful when some abstractions defined by Bridge can only work with specific implementations. In this case, Abstract Factory can encapsulate there relations and hide the complexity from the client code. 
        8- Can be implemented as Singletons.
### Builder
        1- Separates object construction from its representation
        2- Focuses on constructing a complex object step by step.
        3- Returns the product as a final step.
        4- You can use Builder when creating complex Composite trees because you can program its construction steps to work recursively.
        5- You can combine with Bridge: the director class plays the role of the abstraction, while different builders act as implementations.
        6- Can be implemented as Singletons.
### Factory Method
        1- Creates an instance of several derived classes
        2- Abstract Factory classes are often based on a set of Factory Methods, but you can also use Prototype to compose the methods on these classes.
        3- You can use along with Iterator to let collection subsclasses return different types of iterators that are compatible with the collections.
        4- Is a specialization of Template Method. At the same time, a Factory Method may servce as a step in a large Template Method.
        5- Is based on inheritance but doesn’t require an initialization step.
### Object Pool
        Avoid expensive acquisition and release of resources by recycling objects that are no longer in use
### Prototype
        1- A fully initialized instance to be copied or cloned
        2- An object that supports cloning is called a prototype.
        3- Can help when you need to save copies of (Commands another pattern) into history.
        4- Designs that make heavy use of Composite and Decorator can often benefit from using Prototype. Applying the pattern lets you clone complex structures instead of re-constructing them from scratch.
        5- Isn’t based on inheritance, so it doesn’t have its drawbacks. On the other hand, Prototype requires a complicated initialization of the cloned object.
        6- Sometimes Prototype can be a simpler alternative to (Memento another pattern). This works if the object, the state of which you want to store in the history, is fairly straightforward and doesn’t have links to external resources, or the links are easy to re-establish.
        7- Can all be implemented as Singletons.
### Singleton
        1- A class of which only a single instance can exist while providing a global access point to this instance.
        2- A Facade class can often be transformed into a Singleton since a single facade object is sufficient in most cases.
        3- Flyweight would resemble Singleton if you somehow managed to reduce all shared states of the objects to just one flyweight object. But there are two fundamental differences between these patterns:
            - There should be only one Singleton instance, whereas a Flyweight class can have multiple instances with different intrinsic states.
            - The Singleton object can be mutable. Flyweight objects are immutable.
        4- Can be implemented by using Abstract Factories, Builders and Prototypes.
