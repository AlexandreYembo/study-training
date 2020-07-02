# DESIGN PATTERN FOR INTERVIEW
## Creational Patterns
### Factory Method
##### 1- What is Factory Method?
Is a ```creational design pattern``` that provides an interface for creating objects in a superclass, but allows subsclasses to alter type of objects that will be created.

##### 2- Why do you implement Factory Method?
To provide an interface that can help you integrate a new service (class). You can implement factory in services that integrates with third part library, for example.

##### 3- how does it work?
This pattern suggests that you replace direct object construction calls (using the new operator) with calls to a special factory method.

##### 4- Concept of this pattern
1- Subclasses may implement the same interface, but each class implements this method differently.

Example: Logistic App

###### interface (Transport) -> Truck (input -> deliver by land)

###### interface (Transport) -> Ships (input -> delivery by sea).

There are 2 methods in Factory Method: 
###### 1- RoadLogistic (returns -> truck objects).
###### 2- SeaLogistic (returns -> Ships object).

Also the client treats all products as abstract Transport. The clients knows that all transport objects have the ```deliver``` method, but does not know how it works.

##### 5- How to implement this pattern?
###### Steps
1- Declare the interface Product ```(common to all objects, Creator and subclasses)```.

2- Concrete products are ```different implementations``` of the product ```interface```.

3- ```Creator``` class declares the ```factory method``` that returns ```new product objects```. Returns should match ```same type```. Usually ```creator class``` has some core business logic related to products. ```Factory method``` helps to decouple this logic from the ```concrete product classes```.

4- ```Concrete Creators``` override the base factory method so it returns a ```different type of product```.

###### Implementation in c#
###### IButton.cs
```c#
// The product interface declares the operations that all
// concrete products must implement.
public interface IButton {
    void Render();
    void OnClick(object obj);
}
```
###### Windows and HTML button classes
```c#
// Concrete creators override the factory method to change the
// resulting product's type.
public class WindowsButton : IButton{
    public void Render(){
        //DO something
    }

    public void OnClick(object obj){
        //DO something
    }
}

public class HtmlButton : IButton{
    public void Render(){
        //DO something
    }

    public void OnClick(object obj){
        //DO something
    }
}
```
###### DialogFactory.cs
```c#
// The creator class declares the factory method that must
// return an object of a product class. The creator's subclasses
// usually provide the implementation of this method.
    public abstract class DialogFactory{
        // The creator may also provide some default implementation
        // of the factory method.1
        public abstract IButton CreateButton();

        public void Render(){
            IButton okButton = createButton();
            okButton.OnClick(closeDialog);
            okButton.Render();
        }
    }
```
###### Windows and web dialoag classes
```c#
// Concrete creators override the factory method to change the
// resulting product's type.
    public class WindowsDialog : DialogFactory {
        public override IButton CreateButton(){
            return new WindowsButton();
        }
    }

    public class WebDialog : DialogFactory {
        public override IButton CreateButton(){
            return new HtmlButton();
        }
    }
```

###### Client class
```c#
public class Client {
    public void Main(){
        if(env == "Windows"){
            DialogFactory windowsDialog = new WindowsDialog();
            windowsDialog.Render();
        }
        else if(env == "Web"){
            DialogFactory webDialog = new WebDialog();
            webDialog.Render();
        }
        else{
            //TODO : implement any check or exception on this block.
        }
        
    }
}
```

###### Important: You can add more dialog class, however you will get closer to the ```Abstract Factory```

##### 6- Where to apply?
1- Use when you ```don't know``` the exact types and dependencies of the objects.

2- Use when you want to provide users of your library or framework with ```a way to extend``` its internal components.

3- Use when you want to ```save system resource``` by reusing existing objects instead of rebuild them each time (database connection, file systems and network resources).

##### 7- Pros and Cons?
###### Pros:
1- Avoid coupling between the creator and the concrete classes.

2- ```SRP``` -> Single Responsibility Priciple by moving the product creation code into one place in the program, make it easier to support.

3- ```OCP``` -> Open/Closed Principle by introducing news types of products without breaking existing client code.

###### Cons:
1- It may become more complicated since you need to introduce a lot of new subclasses. The best scenario is when you are introducing the pattern into an ```existing hierarchy of creator classes```.

##### 8- Relations with other patterns?
1- Starts by using ```Factory Method``` (less complicated and more customizable via subclasses) and evolve toward ```Abstract Factory```, ```Prototype``` or ```Builder``` (more flexiblem but more complicated).

2- ```Abstract Factory``` -> Classes are often based on set of ```Factory Methods```. You can use ```Prototype``` to compose methods on theses classes.

3- Use along with ```Iterator``` to let collection subclasses return different types of iterators that are compatible with the collections.

4- ```Prototype``` is not based on ```inheritance``` it does not have its drawbacks. In other hand, ```Prototype``` requires a complicated initialization of the cloned object. ```Factory Method``` is based on ```inheritance``` but does not require an initialization step.