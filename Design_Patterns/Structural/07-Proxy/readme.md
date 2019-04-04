# Proxy
Lets you provide a substitute or placeholder for another object.

### Problem
You have a massive object that consumes a vast amount of system resources. You need it from time to time, but not always. You could implement lazy initialization and all of object's clients would need to execute some deferred initialization code. This would probably cause a lot of ```code duplication```.

### Solution
