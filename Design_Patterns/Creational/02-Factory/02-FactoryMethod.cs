using System;

namespace Design_Patterns.Creational.FactoryMethod{
    public class Point{

        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Point NewCartesianPoint(double x, double y) => new Point(x, y);
        
        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="rho"></param>
        /// <param name="theta"></param>
        /// <returns></returns>
        public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));

        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y; 
        }

        public override string ToString() => $"{nameof(x)}: {x}, {nameof(y)}: {y}";
    }

    public class Implement{
        public static void Run(string[] args){
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}