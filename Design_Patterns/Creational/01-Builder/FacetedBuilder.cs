/* Implementation using Faceted Builder */
namespace Design_Patterns.Creational.BuilderFacets{
    public class Person{
        //address
        public string StreeAdress, PostCode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString() => $"{nameof(StreeAdress)} : {StreeAdress}, {nameof(PostCode)} : {PostCode}, {nameof(City)} : {City}, {nameof(CompanyName)} : {CompanyName}, {nameof(Position)} : {Position}";
    }

    public class PersonBuilder // facade
    {
        //reference of the object
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
    }

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


    // static void Main(string[] args){

    // }   
}