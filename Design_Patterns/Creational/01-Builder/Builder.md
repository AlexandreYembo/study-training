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
```c#
public class PersonInfoBuilder<T>
    : PersonBuilder
    where T : PersonInfoBuilder<T>
```


### Faceted Builder
#### Facade is another pattern
#### We use when single builder is not enough. For example in FluentBuilder example we habe a single builder. But depends on the project it will be necessary to implement several builders wich are responsible for building up several different aspects of a particular object and also want some sort of facade.

### Problems:
#### When we are building up on that same reference we have a single reference for a specific object (e.g. Person) being passed through all these sub builders and that's fine.
### But if you have a `value type` you could be in trouble.

#### More about Value type and Reference type: https://www.tutorialsteacher.com/csharp/csharp-value-type-and-reference-type

### Important
#### During the implementation you use this kind of call for a builder. e . g

```c#
var pb = new PersonBuilder();
var person = pb
    .Lives
        .At("23 newcomen court")
        .In("Dublin")
        .WithPostCode("D03X11")
    .Works
        .At("Microsoft")
        .AsA("Software Developer")
        .Earning(1000);
```
#### You define person from Personbuilder using var. If you want to define a specific object type of Person, you need to implement implict operator:

```c#
public class PersonBuilder{
    ...
    public static implicit operator Person(PersonBuilder pb) => pb.person; 
}

//Implementation
var pb = new PersonBuilder();
Person person = pb
    .Lives
        .At("23 newcomen court")
        .In("Dublin")
        .WithPostCode("D03X11")
    .Works
        .At("Microsoft")
        .AsA("Software Developer")
        .Earning(1000);
```

#### Another solution you can use instead of implict operator, you can create a method. e.g

```c#
public class PersonBuilder{
    ...
    public Person Build() => person; 
}

//Implementation
var pb = new PersonBuilder();
Person person = pb
    .Lives
        .At("23 newcomen court")
        .In("Dublin")
        .WithPostCode("D03X11")
    .Works
        .At("Microsoft")
        .AsA("Software Developer")
        .Earning(1000)
        .Build();
```
#### In that case, you need to call the method Build() in the last of chain of methods call.