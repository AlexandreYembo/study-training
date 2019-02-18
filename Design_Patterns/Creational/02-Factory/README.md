# Factory

Links to help: https://www.geeksforgeeks.org/design-patterns-set-2-factory-method/


### Motivation
#### Object creation logic becomes too convoluted
    The constructor is not really a great way to describe how to construct an object.  
#### Constructor is not descriptive
    1- Name mandated by name of containing type:
         There are a lots of limitations like one of them station for example is the name of constructor has to match the name of the containing type.
    2- Cannot overload with same sets of arguments with different names:
        You cannot have a constructor taking X and Y and anothjer constructor taking row and date og the same time.
    3- Can turn into 'optional parameter hell'
#### Object creation (non-piecewise, unlike Builder) can be outsourced to
    1- A separate function (Factory Method).
    2- That may exist in a separate class (Factory).
    3- Can create hierarchy of factories with Abstract Factory.

### - Factory: A component reponsible solety for the wholesale (not piecewise) creation of objects.
#### One of the reasons why factories exist is because constructors are actually not that good.

### We have two Factory Design Patterns:
#### Factory Method
The advantage of a factory method is twofold:
    1- You get to have an overload with the same sets of arguments so we have two double here.
    2- The names of the factory methods are also unique in the sense that here right in the name when making a suggestion as to what kind of point you're creating so once again this an API improvement.

You can create a static class and create your static methods inside. These methods will access the constructor of another class. You can do and you can already see the refactored code here is you can make a point br calling other components so instead of calling on point you say point factory default new polar point.
```c#
//Factory class calling point, passing arguments nice and clear.
 public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y) => new Point(x, y);
        public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }

  public class Point{
        private double x, y;
        public Point(double x, double y){
            this.x = x;
            this.y = y;
        }
    }

```
Now the only consequence of what we did is that we have not really hidden  the constructor and as a result people can still do things like. New points and then they can provide the x and y arguments but once again we're keeping the arguments nice and clear.
```c#
var p = new Point(x, y);
```
#### Abstract Factory