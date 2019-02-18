using System;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creational.FluentBuilder");
            Design_Patterns.Creational.FluentBuilder.Implement.Run(args);

            Console.WriteLine("Creational.BuilderFacets");
            Design_Patterns.Creational.BuilderFacets.Implement.Run(args);

            Console.WriteLine("Creational.FactoryMethod");
            Design_Patterns.Creational.FactoryMethod.Implement.Run(args);
        }
    }
}
