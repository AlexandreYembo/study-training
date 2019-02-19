
using System;

namespace DesignPatterns.Creational.Prototype.ExplicitDeepCopyInterface
{
    public interface IPrototype<T>{
        T DeepCopy();
    }
    public class Person: IPrototype<Person>{
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

        public override string ToString() => $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";

        public Person DeepCopy() => new Person(Names, Address.DeepCopy());
    }

    public class Address: IPrototype<Address>{
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber){
            if(streetName == null)
                throw new ArgumentNullException(paramName: nameof(streetName));

            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        /* We implement a deep clone using interface*/
        public Address DeepCopy() => new Address(StreetName, HouseNumber);

        public override string ToString() => $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }

    public static class Implement{
        public static void Run(string[] args){
            var john = new Person(new []{"John", "Smith"}, new Address("London Road", 123));
            var jane = john.DeepCopy();
            jane.Address.HouseNumber = 32100000;
            Console.WriteLine(john);
            Console.WriteLine(jane); 
        }
    }
}