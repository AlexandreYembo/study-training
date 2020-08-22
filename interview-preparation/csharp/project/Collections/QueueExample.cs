using System;
using System.Collections;

namespace project.Collections
{
    public class QueueExample
    {
        public void ProcessQueue()
        {
            // Define a type but has reference with Generics 
            var numbers = new System.Collections.Generic.Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");

            foreach( string number in numbers )
            {
                Console.WriteLine(number);
            }

            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers.Dequeue());
            Console.WriteLine(numbers.Dequeue());


            //accept any type but there is no reference with Generics
            var q = new Queue();
            q.Enqueue("Alexandre");
            q.Enqueue(1);
            q.Enqueue(true);

            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
        }
    }
}