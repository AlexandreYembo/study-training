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