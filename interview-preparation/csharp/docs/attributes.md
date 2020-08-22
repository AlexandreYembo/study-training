# Attributes
- Provide powerful method of associating metadata.

- Can queried at runtime by using reflection.

- Add metadata to your program. Metadata is information about the types defined. All .NET assemblies contain sets of metatdata.

- You can customize set of metadata by creating custom attributes.

- Can accept arguments in the same way as methods and properties.

#### Acessing attribute values by using reflection

```c#
public class AuthorAttribute: System.Attribute
{
    string name;
    public double version;
    public AuthorAttribute(string name)
    {
        this.name = name;
        version = 1.0;
    }

    public string GetName()
    {
        return this.name;
    }
}

[Author("Alex", version = 1.2)]
public class ClassA
{

}

[Author("Ana")]
[Author("John" version = 2.0)]
public class ClassB
{
    
}
```
Class to get attribute value by using Reflection.
```c#
public class TestAuthorAttribute
{
    public TestAuthorAttribute()
    {
        GetAuthorName(typeof(ClassA));
        GetAuthorName(typeof(ClassB));
    }

    public void GetAuthorName(Type type)
    {
        //Use reflection
        System.Attributes[] attributes = System.Attribute.GetCustomAttributes(type);

        foreach (System.Attribute attr in attributes)  
        {  
            if (attr is AuthorAttribute)  
            {  
                AuthorAttribute a = (AuthorAttribute)attr;  
                System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);  
            }  
        }  
    }
}
```
