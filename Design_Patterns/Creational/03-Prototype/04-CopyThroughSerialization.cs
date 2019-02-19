
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPatterns.Creational.Prototype.CopyThroughSerialization
{
  public static class ExtensionMethods{
      public static T DeepCopy<T>(this T self){
          var stream = new MemoryStream();
          var formatter = new BinaryFormatter();
          formatter.Serialize(stream, self);
          stream.Seek(0, SeekOrigin.Begin);
          object copy = formatter.Deserialize(stream);
          stream.Close();
          return (T)copy;
      }

      public static T DeepCopyXml<T>(this T self){
          using(var ms = new MemoryStream()){
              var s = new XmlSerializer(typeof(T));
              s.Serialize(ms, self);
              ms.Position = 0;
              return (T)s.Deserialize(ms);
          }
      }
  }
   
  // [Serializable] --> implement if you will use DeepCopy using BinaryFormatter
    public class Person{
        public string[] Names;
        public Address Address;

        public Person()
        {
            
        }
        public Person(string[] names, Address address){
            if(names == null)
                throw new ArgumentNullException(paramName: nameof(names));
            
            if(address == null)
                throw new ArgumentNullException(paramName: nameof(address));

            Names = names;
            Address = address;
        }

        public override string ToString() => $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";

    }

    // [Serializable] --> implement if you will use DeepCopy using BinaryFormatter
    public class Address{
        public string StreetName;
        public int HouseNumber;

        public Address()
        {
            
        }

        public Address(string streetName, int houseNumber){
            if(streetName == null)
                throw new ArgumentNullException(paramName: nameof(streetName));

            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        /* We implement a deep clone using interface*/

        public override string ToString() => $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }

    public static class Implement{
        public static void Run(string[] args){
            var john = new Person(new []{"John", "Smith"}, new Address("London Road", 123));
            var jane = john.DeepCopyXml(); // you dont need to specify [SerializeAttribute]
            //var jane = john.DeepCopy(); you need to specify [SerializeAttribute]
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 32100000;
            Console.WriteLine(john);
            Console.WriteLine(jane); 
        }
    }
}