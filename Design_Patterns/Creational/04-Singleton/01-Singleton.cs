using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Design_Patterns.Creational.Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private SingletonDatabase(){
            Console.WriteLine("Initializing database");
            capitals = File.ReadAllLines( Path.Combine( new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"))
                            .ToDictionary(
                                            list => Convert.ToString(list.ElementAt(0)),
                                            list => Convert.ToInt32(list.ElementAt(1)));
                       
        }
        public int GetPopulation(string name) => capitals[name];

        /*Singleton implementation */
        //private static SingletonDatabase instance = new SingletonDatabase();
       
       /*So this way instead of returning instance you turn instance the value and this construct allows you to only create the sync of the database when somebody accesses the instance because that's when you get the value. */
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
    }

    public static class Implementation{
       public static void Run(string[] args){
           var db = SingletonDatabase.Instance;
            string city = "Tokyo";
            Console.WriteLine($"{city} has population {db.GetPopulation(city)}");


       }
   }
}