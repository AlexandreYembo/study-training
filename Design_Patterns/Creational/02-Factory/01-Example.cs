using System;

namespace Design_Patterns.Creational.Factory1{
public enum CoordinateSystem{
    Cartesian,
    Polar
}
    public class Point{
        private double x, y;

      /// <summary>
      /// Initializeds a point from EITHER cartesian or polar
      /// </summary>
      /// <param name="a">x if cartesian, rho if polar</param>
      /// <param name="b"></param>
      /// <param name="system"></param>
        public Point(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian){
            switch(system){
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;

                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }

        /* public Point(double x, double y){
            this.x = x;
            this.y = y;
         }*/

        //public Point(double rho, double theta){ } // **** We have the same signature, that is why we have problem to create the object using both parameters.
    }


}