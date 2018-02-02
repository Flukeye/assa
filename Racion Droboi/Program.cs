using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racion_Droboi
{
    class Drob
    {
        private int numerator;
        private int denominator;
        private int sign;
        Drob(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new DevideByZeroAcception("На нол делит нелза");
            }
            this.numerator = Math.Abs(numerator);
            this.denominator = Math.Abs(denominator);
            if (numerator * denominator >= 0)
            {
                this.sign = 1;
            }
            else
            {
                this.sign = -1;
            }

        }
        Drob(int numerator) : this(numerator, 1) { }
        private static int HoD(int x, int y)
        {
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }
        private static int Hok(int x, int y)
        {
            return x * y / HoD(x, y);
        }
        private static Drob LibaPlusLibaMinus(Drob x, Drob y, Func<int, int, int> Operation)
        {
            int hok = Hok(x.denominator,y.denominator);
            int firstkov = hok / x.denominator;
            int secondkov = hok / y.denominator;
            int operationresult = Operation(x.numerator * firstkov * x.sign, y.numerator * secondkov * y.sign);
            return new Drob(operationresult, x.denominator * firstkov);
        }
        public static Drob operator + (Drob x, Drob y)
        {
            return LibaPlusLibaMinus(x, y, (int a, int b) => a + b);
        }
        public static Drob operator +(Drob x, int y)
        {
            return x + new Drob(y);
        }
        public static Drob operator -(Drob x, Drob y)
        {
            return LibaPlusLibaMinus(x, y, (int a, int b) => a - b);
        }
        public static Drob operator -(Drob x, int y)
        {
            return x - new Drob(y);
        }
        public static Drob operator * (Drob x, Drob y)
        {
            return new Drob(x.numerator * x.sign * y.numerator * y.sign, x.denominator * y.denominator);
        }
        public static Drob operator *(Drob x, int y)
        {
            return x * new Drob(y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
