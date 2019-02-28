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
        Creates an instance of several families of classes
        1- Emphasizes a family of product objects (either simples or complex).
        2- Is concerned, the product gets returned immediately.
### Builder
        Separates object construction from its representation
        1- Focuses on constructing a complex object step by step.
        2- Returns the product as a final step.
### Factory Method
        Creates an instance of several derived classes
### Object Pool
        Avoid expensive acquisition and release of resources by recycling objects that are no longer in use
### Prototype
        A fully initialized instance to be copied or cloned
### Singleton
        A class of which only a single instance can exist

## Structural design patterns


## Behavioral design patterns