# Unsafe Codes
  c# allows using pointer variable in a function of code block when it is marked by the ```unsafe``` modifier.
  
   1- Methods, types and code blocks can be defined as unsafe.
    
   2- In some cases, unsafe code may increase an application's performance by removing array bound checks.
    
   3- Unsafe code is required when you call native functions that require pointers.
    
   4- Using unsafe code introduces security and stability risks.
    
   5- In order for C# to compile unsafe code, the application must be compiled  with /unsafe (compiler option).
  ```c#
      static unsafe void Main(string[] args) {
             int var = 20;
             int* p = &var;

             Console.WriteLine("Data is: {0} ",  var);
             Console.WriteLine("Address is: {0}",  (int)p);
             Console.ReadKey();
          }
  ```
  
 ### Note
  1- In CLR unsafe code is referred to as unverifiable code. It is not necessarily dangerous, it is just code whose safety cannnot be verified by the CLR.
 
  2- The CLR will therefore only execute unsafe code if it is in a fully trusted assembly.
  
  3- It is your responsability to ensure that your code does not introduce security risk or pointer errors.
  
