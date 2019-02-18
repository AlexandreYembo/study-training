using System;
using System.Threading.Tasks;

namespace Design_Patterns.Creational.InnerFactory
{
    public class Point{
        private double x, y;

        private Point(double x, double y){
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        public static Point Origin = new Point(0, 0);  // Better than public static Point Origin => new Point(0, 0);
       
        public static class Factory
        {
             public static Point NewCartesianPoint(double x, double y) => new Point(x, y);
            public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

     public class Implement{
        public static void Run(string[] args){
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);

            var origin = Point.Origin;
        }
    }
}