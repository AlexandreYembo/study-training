# Implementation

##### ISuject.cs
Declares common operations for both RealSubject and the Proxy.
```c#
  public interface ISubject
  {
      void Request();
  }
```

##### RealSubject.cs
Contains some core business logic. Usually, RealSubjects are capable of doing some useful work which may also be very slow or sensitive.
```c#
   public class RealSubject : ISubject
   {
      public void Request() => Console.WriteLine("Real Subject");
   }
```

##### Proxy.cs
Has an interface identical to the RealSubject
```c#
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;
        
        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }
        
        public void Request()
        {
        //The most common application of the Proxy Pattern are lazy loading, caching, controlling access, logging, etc.
            if(this.CheckAccess())
            {
              this._realSubject = new RealSubject();
              this._realSubject.Request();
              
              this.LogAccess();
            }
        }
        
        // Some real check should go here.
        public bool CheckAccess() =>true;
        
        public void LogAccess() => // To Do log access control.
    }
```


##### Client.cs
Is supposed to work with all objects (both subjects and proxies) via interface in order to support both.
```c#
    public class Client
    {
        public void ClientCode(ISubject subject){
            subject.Request();
        }
    }
```

##### Program.cs
```c#
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);
            
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy)
        }
    }
```
