# Decorator
Link reference: https://refactoring.guru/design-patterns/decorator
Lets you attach new behaviors to objects by placing theses objects inside special wrapper objects that contain the behaviors.

### Problem
Imagine you have a notification library based on the Notifier class that have only few fields, a constructor and a single ```send``` method that send the message to a list of emails. At some point, users on the library expect more than just an email notifications. Many of them would like to receive an SMS about critical issues. Other would like to be notified on Facebook, Slack, etc.

### Solution
Extending a class in the first thing.

  1- Inheritance is static -> You cannot alter the behavior of an existing object at runtime. You can only replace the whole object with another one that is created from a different subclass.
