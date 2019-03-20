# Composite
Link reference: https://refactoring.guru/design-patterns/composite

Let you compose objects into tree structures and then work with these structures as if they were individual objects.

### Problem
You decide to create an ordering system that uses Products and Boxes classes. Orders could contain simple products without any wrapping, as well as boxes stuffed with products and other boxes. How would you determine the totla price of such an order?
```
                    < Fedex >
            Box1         BigBox     Receipt

    Hammer      SmallBox1       SmallBox2

                Phone  Headphones       Charger
```

Imagine you have an order might comprise various products, packaged in boxes, which are packaged in bigger boxes and so on. The whole structure looks like an upside down tree.

### Solution
This pattern suggests that you with Products and Boxes through a common interface which declares a method for calculating the total price.

This pattern lets you run a behavior recursively over all components of an object tree.

The greatest benefit you don't need to care about the concrete classes of objects that compose the tree. You don't need to know whether an object is a simple product or a sophisticated box. You can treat them all the same by using common interface.

### Applicability
##### 1- Use this pattern when you have to implement a tree-like object structure.
  You can have a simple leaves and complex containers.
 
   A container can be composed of both leves and other containers. This lets you construct a nested recursive object structure. 
 
#####  2- Use this pattern when you want the client code to treat both simple and complex elements uniformly.
  All elements defined share a common interface. Using this interface, the client does not have to worry about the concrete class of the objects it works with.
  
### Implementation
  1- Make sure that the model can be represented as a tree structure. Break it down in simple elements and containers. Containers must be able to contain simple elements and other containers.
  
  2- Declare the component interface.
  
  3- Create a leaf class to represent simple elements. (You can have multiple different lead classes)
  
  4- Create a container class to represent complex elements. In the class provide an array for references to sub-elements. This array needs to be able to store leaves and containers. This array need to be declare as interface type.
  
  5- Define methods for adding and removal of child elements in the container.
  
```c#
  public class
  
```

### Pros


### Cons
