# Dynamic

## Programming Languages
  - Statically-typed languages: C#, Java
      - at compile-time
  - Dynamically-typed languages: Ruby, Javascript, Python.
      - at run-time

.NET 4 added the dynamic capability, to improve interoperability with:
  
  1- COM (eg writing office applications)
  
  2- Dynamic languages (IronPython)

###### ***Without dynamics, you have to use reflection.

##### What is reflection?
  Reflection is a way to inspect the metadata about the type, and access properties and methods.
  
### Benefit of Dynamic
  If I dont know an specific attribute or method, by using Dynamic without having to use reflection.


#### How is it work?
We have CLR (Common Language Runtime) that is .NET virtual Machine that gets your compile code which is in intermediate language, 
which is IL (Intermediate Language). Then, converts that or recompile that into machine code at runtime.
###### In .NET 4 they added a new component called DLR (Dynamic Language Runtime) and gives dynamic language capabilities to c#.

##### Conversions or casts
  You get implicit conversion from and to the target type.
```c#
  int i = 5;
  dynamic d = i;    // it is not necessary to cast,
```
