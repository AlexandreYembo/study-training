/* Implementation using Fluent Interface */

using System;

namespace Design_Patterns.Creational.FluentBuilder{
    public class Person{
        public string Name;
        public string Position;

        //Example: If a person wants to expose its own builder, we would make a class here called just builder. I could inherit from person job builder or builder.
        public class Builder : PersonJobBuilder<Builder>{

        }

        public static Builder New => new Builder(); 

        public override string ToString() => $"{nameof(Name)}: {Name}, {nameof(Position)} : {Position}";
    }
    

    public abstract class PersonBuilder{
        protected Person person = new Person();
        
        public Person Build() => person;
    }

    public class PersonInfoBuilder<T>
    : PersonBuilder                             //inherit from Abstract class
    where T : PersonInfoBuilder<T>              //We need to restrict yourself because otherwise somebody is going to stick something inappropriate.
                                                //It is restrict itself to the inheritors of person info builder of self.
    {
        public T Called(string name){
            person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<T>
    : PersonInfoBuilder<PersonJobBuilder<T>>
    where T : PersonJobBuilder<T>
    {
        public T WorkAsA(string position){
            person.Position = position;
            return (T)this;
        }
    }

    internal class Implement{
        public static void Main(string[] args){
            var me = Person.New
                        .Called("Alexandre")
                        .WorkAsA("Software Developer")
                        .Build();
            
            Console.WriteLine(me);
        }
    }

}