using System;

namespace PowX_N
{
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            return Pow(x, n);
        }

        private double Pow(double x, long n)
        {
            if (n==0)
            {
                return 1;
            }
            if (n==1)
            {
                return x;
            }
            if (n<0)
            {
                n = -n;
                x = 1 / x;
            }

            var r = Pow(x, n / 2);
            if (n%2==0)
            {
                return r * r;
            }
            else
            {
                return r * r * x;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
