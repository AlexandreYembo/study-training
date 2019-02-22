# Singleton
### Motivation
#### For some components it only makes sense to have one in the system
    1- Database repository (object access database)
    2- Object factory (e.g You have a separate factory component which actually just creates some components do you really want more than one instance of it. Well not really because a factory is not supposed to have any state. )
#### E.g., the constructor call is expensive
    1- We only do it once
    2- We provide everyone with the same instance
#### Want to prevent anyone creating additional copies
#### Need to take care of lazy instantiation and thread safety

### Implementation
```c#
      public class SingletonDatabase : IDatabase
      {
          //define constructor private
          private SingletonDatabase(){
            ...
          }
        /*Singleton implementation */
        private static SingletonDatabase instance = new SingletonDatabase();
        public static SingletonDatabase Instance => instance;

        /* Lazy implementation*/
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
      }
```
So this is how you can both initialize and expose a single instance.
Now nobody can make more than one instance because there is no way of actually calling the constructor, because the constructor is private so there's no way of constructing a single database.

#### Implementing Lazy 
So this way instead of returning instance you turn instance the value and this construct allows you to only create the sync of the database when somebody accesses the instance because that's when you get the value.
Lazy it's thread safe it's you know everything that you want it to be.

#### Why singleton is bad
