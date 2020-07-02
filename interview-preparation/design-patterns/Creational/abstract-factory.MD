# DESIGN PATTERN FOR INTERVIEW
## Creational Patterns
### Factory Method
##### 1- What is Abstract Factory?
Is a creational design pattern that lets you ```produce families of related objects without specifying their concrete classes```.

##### 1- What is Abstract Factory used for?
For example when you have many products or families of products. You would not want to change the core code each time. An example when we are talking about UI. We can implement UI that renders when user is using Windows, but also render the same client wheither the user is using mac or linux. By using abstract factory it allows us to add in the future implementation of Abstract factory class to Mobile concrete Factory for example, without breaking the current client code.


##### 3- how does it work?

- Abstraction Factory
```c#
    //The abstract factory interface declares a set of methods that returns different abstract products.
public interface IGuiFactory {
    IButton CreateButton();
    ICheckBox CreateCheckBox();
}
```
- Abstraction interfaces
```c#
    //Each distinct product of a product family should have a base interface. All variants of this product must implement this interface.
public interface IButton {
    void Paint();
}

    //Each distinct product of a product family should have a base interface. All variants of this product must implement this interface.
public interface ICheckBox {
    void Paint();
}
```
- Concrete products classes
```c#
// Create by corresponding concrete
public class WinButton : IButton {
    public void Paint(){
        //do something
    }
}
// Create by corresponding concrete
public class MacButton : IButton {
    public void Paint(){
        //do something
    }
}

public class WinCheckBox: ICheckBox {
    public void Paint(){
        //do something
    }
}

public class MacCheckBox: ICheckBox {
    public void Paint(){
        //do something
    }
}
```
- Concrete factories
```c#
//Concrete factories produce a family of products that belong to a single variant.
public class WinFactory : IGuiFactory {
    public IButton CreateButton(){
        return new WinButton(); //Single Variant
    }

    public ICheckBox CreateCheckBox(){
        return new WinCheckBox(); //Single Variant
    }
}

public class MacFactory: IGuiFactory {
    public IButton CreateButton(){
        return new MacButton(); //Single Variant
    }

    public IButton CreateCheckBox(){
        return new MacCheckBox(); //Single Variant
    }
}
```
-- Main Aplication and Application Configurator class
```c#
public class Application {
    private readonly IGuiFactory _factory;
    private IButton _button;
    private ICheckBox _checkbox;

    public Application(IGuiFactory factory){
        _factory = factory;
    }

    public void CreateUI(){
        this._button = factory.CreateButton();
        this._checkbox = factory.CreateCheckBox();
    }
}
public class ApplicationConfigurator {
    public void Main(){
        IGuiFactory factory;
        if(config.OS == "Windows){
            factory = new WinFactory();
        }
        else if(config.OS == "Mac"){
            factory = new MacFactory();
        }
        else{
            //extend implementation to other UI or throw any exception
        }
    }
}
```

##### 3- When should use this pattern?
- When your code needs to work with various families of related products, but you don't want it to depend on the ```concrete classes``` of those products. Allow for future ```extensibility```

##### 4- How to implement?
1- Map out a matrix of distinct products ```types``` versus ```veriants```.

2- Declare ```abstract product factory interfaces``` for all product types. Then make all ```concrete``` product classes ```implement these interfaces```.

3- Declare the ```abstract factory interface``` with a set of creation methods for all abstract products.

4- ```Implement``` a set of ```concrete factory classes```, one for each product variant.

5- Create ```factory initialization``` code somewhere in the app. It should ```instantiate``` one of the ```concrete factory classes```, depending on the application configuration or the current environment.

6- Scan through the code and find all direct calls to product constructors. ```Replace``` them with calls to the appropriate ```creation method on the factory object```.

##### Pros
1- You can be sure that the products you're getting from a factory are compatible with each other.


2- You avoid tight coupling between concrete products and client code.

3- ```SRP``` Single Responsability Principle.

4- ```OPR```Open/Closed Principle. You can extend for new products types without breaking the existing client code.

##### Cons
1- The code may become more complicated than it should be, since a lot of new interfaces and classes are introduced along with the pattern.