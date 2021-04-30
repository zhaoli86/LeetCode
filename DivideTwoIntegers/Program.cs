using System;

namespace DivideTwoIntegers
{
    public class Solution
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }
 
            int a = Math.Abs(dividend), b = Math.Abs(divisor), res = 0, x = 0;
            while (a-b>=0)
            {
                for (x = 0; a - (b << x << 1) >= 0; x++);
                res += 1 << x;
                a -= b << x;

            }
            return (dividend > 0) == (divisor > 0) ? res : -res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int a = Math.Abs(int.MinValue);
            Console.ReadKey();
        }
    }
}
