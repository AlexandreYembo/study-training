
using System;

namespace DesignPatterns.Creational.Prototype.CloneableIsBad
{
    public class Person : ICloneable{ // Use this instance to clone the object.
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

        public object Clone() => new Person( Names, (Address)Address.Clone() /* We implement a deep clone */);

        public override string ToString() => $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
    }

    public class Address : ICloneable{
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber){
            if(streetName == null)
                throw new ArgumentNullException(paramName: nameof(streetName));

            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        /* We implement a deep clone */
        public object Clone() => new Address(StreetName, HouseNumber);

        public override string ToString() => $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }

    public static class Implement{
        public static void Run(string[] args){
            var john = new Person(new []{"John", "Smith"}, new Address("London Road", 123));

            /* Now this is doomed to failure for obvious reason because all you have done is
                                    // you have copied the reference.
                                    // So we modify that the same reference and you are getting change in both of these locations.
            var jane = john;
            jane.Names[0] = "Jane";

            */
            var jane = (Person)john.Clone();
            jane.Address.HouseNumber = 321;
            Console.WriteLine(john);
            Console.WriteLine(jane); 
        }
    }
}