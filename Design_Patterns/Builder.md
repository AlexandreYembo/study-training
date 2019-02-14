# Builder
## Fluent interface
### Definition: An interface wich allows you to change several calls by returning a reference to the object you are working with.
### Example:
####    1- Implementation: public People GetName() => new People();
####    2- Uses: new People().GetName().GetName().GetName(), etc....

### Problems:
#### When you are working with inheritance is that the problem with inheritance of fluent interfaces is you are not allowed to use the containing type (class type) as the return type. To resolve this problem you need to implement generic in both classes and you need to create an abstract class that contains your object in common. This abstract class will be inheritance for the both class are using fluent interfaces.

### Inherit:
#### So in this case the self argument the self Generica argument actually refers to the class that's actually doing the inheritance so if you have food then you need to specify food as the argument to self and that's precisely why we have this constraint where self inherits from person info.
`public class PersonInfoBuilder<T><br>
    : PersonBuilder <br>
    where T : PersonInfoBuilder<T>`
