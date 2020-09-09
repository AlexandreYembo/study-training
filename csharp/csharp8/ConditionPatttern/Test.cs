using System;

namespace csharp8.ConditionPatttern
{
   public class Car
    {
        public int PassengerCount { get; set; }
    }
    public class DeliveryTruck
    {
        public int Weight { get; set; }
    }
    public class Taxi
    {
        public int Fare { get; set; }
    }
    public class Bus
    {
        public int Capacity { get; set; }
        public int RidersCount { get; set; }
    }
    public class Test
    {
        public int TollFare<T>(T entity) => entity switch
        {
            Car c => 100,
            DeliveryTruck d => 200,
            Bus b => 150,
            Taxi t => 120,
            null => 0,
            { } => 0
        };

        public void CalculateFare()
        {
            var car = new Car();
            var taxi = new Taxi();
            var bus = new Bus();
            var truck = new DeliveryTruck();

            Console.WriteLine($"The toll for a car is {TollFare(car)}");
            Console.WriteLine($"The toll for a taxi is {TollFare(taxi)}");
            Console.WriteLine($"The toll for a bus is {TollFare(bus)}");
            Console.WriteLine($"The toll for a truck is {TollFare(truck)}");
        }
    }
}