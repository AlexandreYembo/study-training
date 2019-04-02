# Implementation in C#

```c#
  public class Facade
  {
      protected Subsystem1 _subsystem1;
      protected Subsystem2 _subsystem2;

      public Facade(Subsystem1 subSystem1, Subsystem2 subSystem1)
      {
          this._subsystem1 = subSystem1;
          this._subsystem2 = subSystem2;
      }
      
      public void Operation()
      {
        this._subsystem1.Operation1();
        this._subsystem2.Operation1();
        
        this._subsystem1.OperationN();
        this._subsystem2.OperationZ();
      }
  }
```

### 3rd party library
```c#
    public class Subsystem1
    {
      public void Operation1()
      {
          ...
      }
      
      public void OperationN()
      {
          ...
      }
    }
    
     public class Subsystem2
    {
      public void Operation1()
      {
          ...
      }
      
      public void OperationZ()
      {
          ...
      }
    }
```

### Client class
```c#
    public class Client
    {
        public static void ClientCode(Facade facade) => facade.Operation();
    }
```

### Program class
```c#
    public class Program
    {
        static void Main(stringp[] args){
          SubSystem1 subSystem1 = new SubSystem1();
          SubSystem2 subSystem2 = new SubSystem2();
          
          Facade facade = new Facade(subSystem1, subSystem2);
          Client.ClientCode(facade);
        }
    }
```
