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

#### Factory
*** I cannot simply make the constructor private, because the point factory is trying to access a private member which is not allowed. How can I mitigate the situation now if you are writing a library intended to be consumed by other users in there on the assembly. Then the solution is very simple you simply make the constructor internal and it wil solve the problems because it allows the use on the constructor within the current assembly.

But if you need to use the contructor consuming that assembly from the outside it does not allow the use of the constructor.
Now if you want to have a particular constraint right inside your own assembly then it is a bit of a problem, because in this case you have to do something completely different.

```c#
   public class Point{
       ...
       private Point(double x, double y){
            this.x = x;
            this.y = y;
       }
       ...
       // You have class Factory inside Point class
       public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y) => new Point(x, y);
            public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
   }
```

and the basic implementation is:
```c#
    var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
```


Using properties and field for Factory.
```c#
    // Arrow makes it a property.
    public static Point Origin => new Point(0, 0); 
    
    /* singleton field. Field gets initialized once. This one is better because you just initialize a static field once 
    and that field is available to be used everywhere that you want but if you do need  to instantiate a new object anytime
    somebody  asked for something then a property is a good alternative to a factory method.*/
    public static Point Origin2 = new Point(0, 0);
```

#### Abstract Factory