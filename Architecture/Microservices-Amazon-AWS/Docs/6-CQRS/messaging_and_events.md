# Messaging and Events
 ### What is an API call?
 1- API call is reaching out to another (micro) service in order to query a data or invoke an action.

 2- To make an API call, the caller must know exactly where the callee is.
 
 3- The caller must be available to receive the message.


 ### What is a message?
 1- A message is a type of notification that a microservice sends out to the outside world (in the boundary of the system).

 2- A message that is triggered when the state of the system changes, is called an ``` Event ```.

 3- Any system that subscribes the message channel will receive the message. So the sender of the message is unaware of the existence and/or location of the receivers/subscribers.

 4- There are two ways of sending messages to the receivers of the message. 
 
 One of them is that just shoot the message to a channel in any subscriber that channel would immediately get the message. But the downside of this is that the receivers have to be available. If they won't be available they have been missing out on that message. 
 
 The other way to send the message is by using Queue. You send it to a message queue and just leave it and any system who wants to listen to that message, they have to start reading from the queue and get message one by one from the queue.

 ##### The benefit of use queue rather than channel subscribe is that we decouple the send there from the receiver. Another benefit is that if the receiver become unavailable then the system won't break because, the sender doesn't wait for the receiver to receive the message. It just puts the message in the queue and receiver can be unavailable for certain amount of time. So, when the receiver comes back to life and becomes available it is to start picking up the messages from the queue.

 ##### The downside of use queue is that your receiver has to periodically read the queue check to see if there a new message there.

 ### Implementing Messaging in AWS
Use Simple Notification Servce (SNS) to send and receive messages.

There is another service called Simple Queue Service (SQS) to persist the messages (Requires Polling)

There is a pattern called ``` FanOut ``` pattern that is used to split one function in many concurrent invocations. SNS deliver messages to all of them concorrently and them in invoke many tasks concurrently and they start doing the jobs. SNS can deliver the message to multiple SQS at the sime time and put it into queues.


