
using System;

namespace DesignPatterns.Creational.Prototype.CopyConstructors
{
    public class Person{
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address){
            if(names == null)
                throw new ArgumentNullException(paramName: nameof(names));
            
            if(address == null)
                throw new ArgumentNullException(paramName: nameof(address));

            Names = names;
            Address = address;
        }

        /*Special constructor 
            You pass the same object.
            The idea is that when you are in person what you do is you make a copy of either by copying 
            its internals into yourself.
        */
        public Person(Person other){
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public override string ToString() => $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
    }

    public class Address{
        public string StreetName;
        public int HouseNumber;
        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public Address(string streetName, int houseNumber){
            if(streetName == null)
                throw new ArgumentNullException(paramName: nameof(streetName));

            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        /* We implement a deep clone */
    

        public override string ToString() => $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }

    public static class Implement{
        public static void Run(string[] args){
            var john = new Person(new []{"John", "Smith"}, new Address("London Road", 123));
            var jane = new Person(john);
            jane.Address.HouseNumber = 321;
            Console.WriteLine(john);
            Console.WriteLine(jane); 
        }
    }
}