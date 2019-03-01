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
  1- 
