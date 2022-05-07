# Big O Notation
References: https://www.bigocheatsheet.com/

Big O notation is the language we use for talking about how long an algorithm takes to run.

- We can measure in terms of efficiency what is good or bad code.

- We can measure what is code that can scale that as the number of Arrays or inputs increases.


### Linear measure
#### - 1 - BigO Name: O(n) --> Linear Time

Performance: ```Fair```. In the Big-O complexity chart it is considered ```Yellow``` colour.

- Descrition: BigO(n)

Explanation: It takes linear time to find a nemo. 

- The O(n) where BigO depends on n (number of items in the array).

```
                5               x
                4           x
Number of       3       x
Operations      2
                1   2   3   4   5
                    Elements
```



##### Implementation:
```c#
    public void Linear(string[] arr){
        for(var i = 0; i < arr.Length; i++){
            if(arr[i] == "NEMO"){
                System.Console.WriteLine("Found NEMO!");
            }
        }
    }
```
##### Examples:
```c#
 var arr = ["nemo"];
````
Result: ```O(1)```

```c#
 var arr = new string()[1000];
```
Result: ```O(1000)```

#### - 2 - BigO Name: O(1) --> Constant Time
No matter how many times the array increse, we are always just grabbing the first item in the array. It's a flat line in terms of scalability.

Performance: ```Excellent```. In the Big-O complexity chart it is considered ```Green``` colour.

###### With 1 operation
```
                4               
                3           
Number of       2       
Operations      1   x   x   x
                0   1   2   3   4
                    Elements
```

```c#
function compressFirstBos(boxes){
    console.log(boxes[0]); //0(1)
}
```

###### With 2 operations
```
                4               
                3           
Number of       2   x   x   x   
Operations      1   
                0   1   2   3   4
                    Elements
```

```c#
function compressFirstBos(boxes){
    console.log(boxes[0]);  //0(1)
    console.log(boxes[1]);  //0(1)
}
```
