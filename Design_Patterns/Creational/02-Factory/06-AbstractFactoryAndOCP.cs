/* Implementing Open Closed principle in Abstract Factory */

using System;
using System.Collections.Generic;

namespace Design_Patterns.Creational.AbstractFactoryAndOCP
{
  public interface IHotDrink
  {
      void Consume();
  }

    internal class Tea : IHotDrink
    {
        public void Consume() => Console.WriteLine("This tea is nice but i'd prefer it with milk.");
    }

    internal class Coffee : IHotDrink
    {
        public void Consume() => Console.WriteLine("This coffee is sensational!");
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine{
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if(typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface){
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                    ));
                }
            }
        }

        public IHotDrink MakeDrink() {
            Console.WriteLine("Available drinks:");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                Console.WriteLine($"{i}: {tuple.Item1}");
            }

            while(true){
                string s;
                if((s = Console.ReadLine()) != null && int.TryParse(s, out int i) && i >= 0 && i < factories.Count){
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine();

                    if(s != null && int.TryParse(s, out int amount) && amount > 0){
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again!");
             }
        }
    }

    public class Implementation{
      public static void Run(string[] args){
          var machine = new HotDrinkMachine();
         var drink = machine.MakeDrink();
         drink.Consume();
      }
  }
}