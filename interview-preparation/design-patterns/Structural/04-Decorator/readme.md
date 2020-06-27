# Decorator
Link reference: https://refactoring.guru/design-patterns/decorator
Lets you attach new behaviors to objects by placing theses objects inside special wrapper objects that contain the behaviors.

### Problem
Imagine you have a notification library based on the Notifier class that have only few fields, a constructor and a single ```send``` method that send the message to a list of emails. At some point, users on the library expect more than just an email notifications. Many of them would like to receive an SMS about critical issues. Other would like to be notified on Facebook, Slack, etc.

### Solution
Extending a class in the first thing.

  1- Inheritance is static -> You cannot alter the behavior of an existing object at runtime. You can only replace the whole object with another one that is created from a different subclass.

  2- Subclasses can have just one parent class. In most language, inheritance does not let a class inherit behaviors of multiple classes at the same time.
  
#### One of the ways to overcome these caveats is by using ```Composition``` instead of ```Inheritance```.

#### With composition one object has a reference to another and delegates it some work, whereas with inheritance, the object itself is able to do that work, inheriting the behavior from its superclass.

#### Composition is the key principle behind many design patterns, including the Decorator.

#### ```Wrapper``` is the alternative nickname for the Decorator.


### Structure
  1- Component(common interface for both wrappers and wrapped objects).
  
  2- Concrete Component - class of objects being wrapped. Basic behavior.
  
  3- Base Decorator - has a field for referencing a wrapped object. By using the component interface it can contain both concrete components and decorators.
  
  4- Concrete Decorators - Define extra behaviors that can be added to components dynamically. It overrides methods of the base decorator or after calling the parent method.
  
  5- Client - Can wrap components in multiple layers of decorators via the component interface.
  
### Why to apply?
  1- Used when you need to be able to assign extra behaviors to objects at runtime without breaking the code that uses the objects.
  
  2- When it's awkward or not possible to extend an object's behavior using inheritance.


### Pros
  1- You can extend an object's behavior without making a new subclass.
  
  2- You can add or remove responsibilities from an object at runtime.
  
  3- You can combine several behaviors by wrapping an object into multiple decorators.
  
  4- ```Single Resposibility Principle```. You can divide a monolithic class that implements many possible variants of behavior into several smaller classes.

### Cons
  1- It's hard to remove a specific wrapper from the wrappers stack.
  
  2- It's hard to implement a decorator in such a way that its behavior does not depend on the order in the decorators stack.
  
  3- The initial configuration code of layers might look pretty ugly.
