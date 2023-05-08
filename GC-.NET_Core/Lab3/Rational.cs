using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Rational
    {
        public int Numarator { get; set; }
        public int Numitor { get; set; }

        public Rational(int numarator = 0, int numitor = 1)
        {
            if (numitor < 0)
            {
                Numarator = -numarator;
            }
            else
            {
                Numarator = numarator;
            }
            if (numitor == 0)
            {
                Numitor = 1;
            }
            Ireductibila();
        }

        public static Rational operator +(Rational a, Rational b)
        {
            return new(a.Numarator * b.Numitor + b.Numarator * a.Numitor, a.Numitor * b.Numitor);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            return new(a.Numarator * b.Numitor - b.Numarator * a.Numitor, a.Numitor * b.Numitor);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new(a.Numarator * b.Numarator, a.Numitor * b.Numitor);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new(a.Numarator + b.Numitor, b.Numarator * a.Numitor);
        }

        public static Rational operator ^(Rational a, int pow)
        {
            Rational res = new(1);
            for (int i = 0; i < pow; i++)
            {
                res *= a;
            }
            return res;
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a.Numarator * b.Numitor == a.Numitor * b.Numarator;
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return a.Numarator * b.Numitor != a.Numitor * b.Numarator;
        }

        public static bool operator <(Rational a, Rational b)
        {
            return a.Numarator * b.Numitor < a.Numitor * b.Numarator;
        }

        public static bool operator >(Rational a, Rational b)
        {
            return a.Numarator * b.Numitor > a.Numitor * b.Numarator;
        }

        public static bool operator <=(Rational a, Rational b)
        {
            return a.Numarator * b.Numitor <= a.Numitor * b.Numarator;
        }

        public static bool operator >=(Rational a, Rational b)
        {
            return a.Numarator * b.Numitor >= a.Numitor * b.Numarator;
        }

        void Ireductibila()
        {
            int cmmdc = CMMDC(Numarator, Numitor);
            Numarator /= cmmdc;
            Numitor /= cmmdc;
        }
        private int CMMDC(int a, int b)
        {
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
    }
}
