# Events and Delegates

## Events
  1- A mechanism for comunication between objects.
    When there is a change inside an object it can notify another object.
  2- Used in building Loosely Coupled Applications
    An application that its components or classes are not tightly coupled together
    A loosely coupled application is easy to extend without breaking or changing one or more of its existing capatibilities.
  3- Helps extending applications

### Example

VideoEncoder (publisher event sender) -> VideoEncoded
MailService (subscriber or an event receiver) -> subscribe to VideoEncoded

##### if in the future we need to add new class, just is necessary to implement the subscriber to VideoEncoded.
MessageService (subscriber or an event receiber) -> subscribe to VideoEncoded

##### In that case is not necessary to recompile and redeploy the VideoEncoder class again and we simply extend the application by adding a new class - so this reduces the impact on the application.

##### How does the videoEncoder notify its subscribers?
It needs to send a message to them. In c#. it means involking a method in the subscriber.

##### How does the VideoEncoder know what method to call?
We need an agreement or a contract beetween these publishers and subscribers.
This agreement is something that both the publisher and subscriber agree upon. That is a method with a specific signature.

```c#
  // typical implementation of a method in the subscriber.
  public void OnVideoEncoded(object source, EventArgs e){
  
  }

```
We often call these methods event handlers and that is the method that is called by the publisher when the event is raised.
In that case VideoEncoder never knows about MailService or MessageService, only this method OnVideoEncoded.

##### How do we tell VideoEncoder what method to call?
That is when a delegate comes in.


## Delegates
  1- Agreement / Contract between Publisher and Subscriber.
  2- Determines the signature of the event handler method in Subscriber.
  
##### How to implement?
We have 3 steps for this:

  1- Define a delegate.
    That is, the contract or the agreement between the publisher and the subscriber.
    Delegate determines the signature of the method and the subscriber that will be called when the publisher in this VideoEncoder, publishes an event.
  
  2- Define an event based on that delegate.
  
  3- Raise or publish the event.

##### 1- Define a delegate
```c#
    // this is a convention
    public delegate void VideoEncodedEventHandler(object source, EventArgs args);
```

##### 2- Define an event based on that delegate
```c#
    // this is a convention
    public event VideoEncodedEventHandler VideoEncoded;
```
##### 3- Raise or publish the event.
```c#
    // the method should be declared as protected
    // this is a convention
    protected virtual void OnVideoEncoded(){
      
    }
```
You just call the method here!
```c#
    public void Encode(Video video)
    {
      Console.WriteLine("Encoding Video...");
      Thread.Sleep(3000);
      
      OnVideoEncoded(); //call the method here!
    }
```
How to notify de subscriber?
```c#    
    protected virtual void OnVideoEncoded()
    {
        if(VideoEncoded != null)
        {
            VideoEncoded(this, EventArgs.Empty); // this my current class
        }
    }
```
Now you are going to create a couple of subscribers.
I will create a method . This is the event handler. This method should be avoid.
```c#    
    public class MailService      //Subscriber 1
    {
        //This is the event handler.
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("MailService: Sending an email...");
        }
    }
    
    public class MessageService   //Subscriber 2
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("MessageService: Sending a text message...");
        }
    }
``
Now we need to do is to subscribe this email service to the video encoded event of VideoEncoder.
```c#   
    public class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService(); //subscriber
            var messageService = new MessageService() //subscriber
            
            // this method is an event.
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; // This is a reference or a pointer to that method
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            
            videoEncoder.Encode(video);
        }
    }
```
It looks at that list.
``` c# 
videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
```
Here we look at that list, and if it is not empty, that someone subscribed to that event which means we have a pointer to an event handler method and we are going to call that like this.
``` c# 
  if(VideoEncoded != null)
  {
      VideoEncoded(this, EventArgs.Empty); // this my current class
  }
```


 ```c# Video.cs
    public class Video
    {
      public string Title {get;set;}
    }
 ```
 ```c# VideoEncoder.cs   
    public class VideoEncoder
    {
      public delegate void VideoEncodedEventHandler(object source, EventArgs args);
      public event VideoEncodedEventHandler VideoEncoded;
     
      protected virtual void OnVideoEncoded(){
           if(VideoEncoded != null)
            {
                VideoEncoded(this, EventArgs.Empty); // this my current class
            }
      }
     
      public void Encode(Video video)
      {
        Console.WriteLine("Encoding Video...");
        Thread.Sleep(3000);
        OnVideoEncoded();
      }
    }

```
