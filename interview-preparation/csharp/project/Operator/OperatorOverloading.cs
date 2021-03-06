using System;

namespace project.Operator
{
    public class OperatorOverloading
    {
         public void Test()
         {
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine(a + b);  // output: 14 / 8

            var result = a + b;
            var resultString = result.ToString();
            double r = result;
            // Console.WriteLine(a - b);  // output: 6 / 8
            // Console.WriteLine(a * b);  // output: 5 / 8
            // Console.WriteLine(a / b);  // output: 10 / 4
         }
    }

    public readonly struct Fraction
    {
        private readonly int num;
        private readonly int den;

        public Fraction(int numerator, int denominator)
        {
            if(denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));

            num = numerator;
            den = denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

        public static Fraction operator +(Fraction a, Fraction b) =>
            new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

        public static implicit operator double(Fraction f) => (double)f.num/f.den;

        public override string ToString() => $"{num} / {den}";
    }
}