# Unsafe Codes
#### Available on C# 6.0

  c# allows using pointer variable in a function of code block when it is marked by the ```unsafe``` modifier in the declaration of a type or member, or by employing an ```unsafe_statement```.
  
   1-  A declaration of class, struct, interface or delegate may ```include``` an unsafe modifier. In which case the entire textual extent of that type declaration (including the body of the class, struct or interface). is considered an unsafe context.
  
   2- A declaration of a field, method, property, event, indexer, operator, instance constructor, destructor or static constructor may include an ```unsafe``` modifier. In which case the entire textual extent of that member declaration is considered an unsafe.
   
   3- In some cases, unsafe code may increase an application's performance by removing array bound checks.
   
   4- An ```unsafe_statement``` enables the use of an unsafe context within a block.
   
   5- Unsafe code is required when you call native functions that require pointers.
    
   6- Using unsafe code introduces security and stability risks.
    
   7- In order for C# to compile unsafe code, the application must be compiled  with /unsafe (compiler option).
   
 By declaring unsafe on struct
  ```c#
          public unsafe struct Node
          {
              public int Value;
              public Node* Left;
              public Node* Right;
          }
  ```

By declaring unsafe in the field.
   ```c#
          public struct Node
          {
              public int Value;
              public unsafe Node* Left;
              public unsafe Node* Right;
          }
  ```
  
 ### Note
  1- In CLR unsafe code is referred to as unverifiable code. It is not necessarily dangerous, it is just code whose safety cannnot be verified by the CLR.
 
  2- The CLR will therefore only execute unsafe code if it is in a fully trusted assembly.
  
  3- It is your responsability to ensure that your code does not introduce security risk or pointer errors.
  
```To set this compiler option in the Visual Studio development environment
  1- Open the project's Properties page.
  2- Click the Build property page.
  3- Select the Allow Unsafe Code check box.```
