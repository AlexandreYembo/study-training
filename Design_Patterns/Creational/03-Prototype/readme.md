# Prototype
## Fluent interface
#### Definition: Is all about object copying. When it is easier to copy an existing object to fully initialize a new one.

## Motivation
#### Complicated objects (e.g. cars) are not designed from scratch.
    1- They reiterate existing designs.
#### An existing (partially or fully constructed) design is a Prototype.
#### We make a copy (clone) the prototype and customize it.
    1- Requires 'deep copy' support -> Deep copy is a situation where you are copy not just the object but you are copying all of your objects references by making new objects which replicate the state of those references. And you are doing it recursevely so you need to make a complete copy of the object so that changing this object does not affect the object it just copied.
#### We make the cloning covenient (e.g. via Factory).

### Prototype -> A partially or fully initialized object that you copy (clone) and make use of.

### IClonable implementation
IClonable is an interface used to implement clone of reference object. You can create a simple or deeply clone using this interface in the parent object and also the children object references.

#### This approach is dangerous it is not convenient because you are turning object and it's really not well specified in actual fact. The interface's documentation says that you are making a shallow (not deep) copy of the array so if array is doing shallow copying on its closed why should not we do anything other than shallow copying and this kind of tells you that if you want to implement deep copying which is what is actually required for the prototype pattern then I clone the clonal is not be the interface that you should be using.
It is bad to use because it returns an object type instead something more strongly typed.

#### in that case, at least somewhat better is using copy constructor and it basically lets you to specify an object to copy all the data from.

### ExplicitDeepCopyInterface
Basically the implementation using an interface is simple, you only need is create an interface and inherite in your class:
```c#
public interface IPrototype<T>{
        T DeepCopy();
}

public class Person: IPrototype<Person>{
    ...
    public Person DeepCopy() => new Person(Names, Address.DeepCopy());
}

public class Address: IPrototype<Address>{
    ...
    public Address DeepCopy() => new Address(StreetName, HouseNumber);
}

```
So this is great but we still have this problem that if you have a deep hierarchy of objects then the approach of implementations everywhere and having the appropriate constructs so that you can actually copy things over.
That is very tedious if you have 1 different classes involved in this kind of  set up then is is far too much work.

### Copy Through Serialization
If you take serializer in your object the serialize should serialize the entire tree. In that case we will create an extension method that will provide the serializer object using MemoryStream and BinaryFormatter.
```c#
public static class ExtensionMethods{
      public static T DeepCopy<T>(this T self){
          var stream = new MemoryStream();
          var formatter = new BinaryFormatter();
          formatter.Serialize(stream, self);
          stream.Seek(0, SeekOrigin.Begin);
          object copy = formatter.Deserialize(stream);
          stream.Close();
          return (T)copy;
      }
  }
```
You dont need to implement in all class using hierarchy, but you need to set up that the object is Serializable. In that case you need to define an attribute type of serializable in all members from the hierarchy.
```c#
[Serializable]
public class Person{
    ...
}
```

You can do using another way to prevent use [Serialize] attribute, basically you need to implement XMLSerializer:
```c#
public static T DeepCopyXml<T>(this T self){
    using(var ms = new MemoryStream()){
        var s = new XmlSerializer(typeof(T));
        s.Serialize(ms, self);
        ms.Position = 0;
        return (T)s.Deserialize(ms);
    }
}
```

And you can remove the attribute for all the classes:
```c#
public class Person{
    ...
}
```
Important: When you implement XMLSerializer you need to create a constructor paramless:
```c#
public class Person{
        public Person() // is required when you use XMLSerializer.
        {
            
        }
        
```