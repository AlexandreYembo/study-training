// <summary>

using System;
/// Instead of having a bunch of factory methods right inside point how about we make a point factory and just have the methods there.
/// </summary>/
namespace Design_Patterns.Creational.Factory
{
    public static class PointFactory
    {
        public static Point NewCartesianPoint(double x, double y) => new Point(x, y);
        public static Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }

    public class Point{
        private double x, y;
        public Point(double x, double y){
            this.x = x;
            this.y = y;
        }

        public override string ToString() => $"{nameof(x)}: {x}, {nameof(y)}: {y}";
    }

    public class Implement{
        public static void Run(string[] args){
            var point = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}