/* Implementation using Faceted Builder */
namespace Design_Patterns.Creational.BuilderFacets{
    public class Person{
        //address
        public string StreetAddress, PostCode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString() => $"{nameof(StreetAddress)} : {StreetAddress}, {nameof(PostCode)} : {PostCode}, {nameof(City)} : {City}, {nameof(CompanyName)} : {CompanyName}, {nameof(Position)} : {Position}";
    }

    public class PersonBuilder // facade
    {
        //reference of the object
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

/* I defined this operator to use type instead of var in the implementation
    e.g. var pb = new PersonBuilder();
    using this operator: Person pb = new PersonBuilder(); 
*/
        public static implicit operator Person(PersonBuilder pb) => pb.person; 
              

/* you can use this method instead of an implicit operator to return a type person instead of using var.
    But using this method, you need to defined this kind of implementation:
    Person pb = new PersonBuilder().Build();

    You can remove this method if you prefer to use implicit operator Person.
 */
        public Person Build() => person;
    }


    #region Person Job
        public class PersonJobBuilder : PersonBuilder{
        public PersonJobBuilder(Person person){
            this.person = person;
        }

        public PersonJobBuilder At(string companyName){
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position){
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount){
            person.AnnualIncome = amount;
            return this;
        }
    }
    
    #endregion

    #region Person Address

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person){
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress){
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode){
            person.PostCode = postCode;
            return this;
        }

        public PersonAddressBuilder In(string city){
            person.City = city;
            return this;
        }

    }

    #endregion

    internal class Implement{
        public static void Main(string[] args){
            var pb = new PersonBuilder();
            Person person = pb
                    .Lives
                        .At("23 newcomen court")
                        .In("Dublin")
                        .WithPostCode("D03X11")
                    .Works
                        .At("Microsoft")
                        .AsA("Software Developer")
                        .Earning(1000);
                   // .Build(); -- You need to implement a method on PersonBuilder Class: public Person Build() => person; 

            System.Console.WriteLine(person);
        }   
    }
} 