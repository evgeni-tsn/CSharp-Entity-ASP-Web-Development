using System;
using System.Globalization;

namespace _02.FractionCalculator
{
    public struct Fraction
    {
        private long denominator;

        public Fraction(long numerator, long denominator)
        {
            this.denominator = denominator;
            this.Numerator = numerator;
        }

        public long Numerator { get; set; }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArithmeticException("Denominator cannot be 0");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            var newNumerator = (a.Numerator * b.Denominator) + (a.Denominator * b.Numerator);
            var newDenominator = (a.Denominator * b.Denominator);
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            var newNumerator = (a.Numerator*b.Denominator) - (a.Denominator*b.Numerator);
            var newDenominator = (a.Denominator * b.Denominator);
            return new Fraction(newNumerator, newDenominator);
        }

        public override string ToString()
        {
            return ((decimal)this.Numerator / this.Denominator).ToString(CultureInfo.InvariantCulture);
        }
    }
}