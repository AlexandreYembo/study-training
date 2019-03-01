# Delegates
  1 - An object that knows how to call a method or a group of methods.
  2- A reference or a pointer to a function.

#### How do we use Delegate to make this extensible?

1- We need to define a Delegate type:
```c#
  //Define the signature for the delegate
  public delegate void PhotoFilterHandler(Photo photo);
```

2- Pass a Delegate to the method
```c#
  public void Process(string path, PhotoFilterHandler filterHandler){
    var photo = Photo.Load(path);
    filterHandler(photo);
    photo.Save();
  }
```
  1- this code does not know what filter will be applied
  2- the responsability of the client of this code.
  3- the client decidade if they will apply filter for only brightness and contrast or another one.
  4- this framework does not have to be recompiled and redeployed, which makes it extensible.
  
3- Implementation
```c#
   class Program
   {
      static void Main(string[] args)
      {
          var processor = new PhotoProcessor(); // PhotoProcessos instantiated.
          var filters = new PhotoFilters()    // instance of PhotoFilters.
          PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness; // Instance of the delegate.
          processor.Process("photo.jpg", filterHandler);
      }
    }
```

4- We can easily change this code and apply another filter
```c#
  filterHandler += filters.ApplyContrast;
```
I will have in 2 filters

5- I can create another method outside PhotoFilters
```c#
    class Program
   {
      static void Main(string[] args)
      {
        ...
        filterHandler += RemoveRedEyeFilter;
      }
      
      //use the same signature of delegate
      static void RemoveRedEyeFilter(Photo photo)
      {
        ...
      }
   }
```

##### Every delegate in .NEt that we create with the Delegate keyword is essentially a class. that derives from multicast Delegate.
##### That class multicast Delegate is derived from System.Delegate.
#### The difference between delegate and multicast Delegate is that multicast Delegate allows us to have multiple function pointers.

We could use one of the existing Delegates that come in .NET framework.
##### In .NET we have two delegates that are generic and they are Action and Func.
##### The difference between Func and Action is:
  Func -> points to a method that returns a value.
  
  Action -> point to a method that returns void.
  
```c#
  //Define the signature for the delegate
   public class PhotoProcessor
   {
       public void Process(string path, Action<Photo> filterHandler){
          var photo = Photo.Load(path);
          filterHandler(photo);
          photo.Save();  
      }
   }
   
   class Program
   {
      static void Main(string[] args)
      {
        ...
         var processor = new PhotoProcessor(); // PhotoProcessos instantiated.
          var filters = new PhotoFilters()    // instance of PhotoFilters.
          //Instead of using Custom delegate, we use Action
          Action<Photo> filterHandler = filters.ApplyBrightness; // Instance of the delegate.
          filterHandler += filters.ApplyContrast;
          filterHandler += RemoveRedEyeFilter;
          processor.Process("photo.jpg", filterHandler);
      }
      
      //use the same signature of delegate
      static void RemoveRedEyeFilter(Photo photo)
      {
        ...
      }
   }
   
```
### Why do we need delegates?
  1- For designing extensible and flexible applications (eg. frameworks)
  2- Alternative: Interfaces.
  
#### Interfaces or Delegates?
##### Use delegate when:
  1- An eventing design patterns is used.
  
  2- The caller does not need to access other properties or methods on the object implementing the method.
In the case of the example the filters photo just one basic simple method and there were no other properties or methods.
But if PhotoProcessor needed  to access pther properties or methods, obviously a Delegate would not work and we have to use an interface.
