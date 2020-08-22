using System;
using System.Collections.Generic;

namespace project.Collections
{
    public class StackExample
    {
         public void ProcessStack()
        {
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");

            foreach( string number in numbers )
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(numbers.Peek()); // Return always the first element and do not remove it
            Console.WriteLine(numbers.Pop()); // Return always the first element and remove it
            Console.WriteLine(numbers.Pop());
            Console.WriteLine(numbers.Pop());
            Console.WriteLine(numbers.Pop());
        }
    }
}