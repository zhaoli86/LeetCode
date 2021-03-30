using System;

namespace GrumpyBookstoreOwner
{
    public class Solution
    {
        public int MaxSatisfied(int[] customers, int[] grumpy, int x)
        {
            int totalHappy = 0, makeHappy = 0, windowMakeHappy = 0;
            for (int i = 0; i < customers.Length; i++)
            {
                if (grumpy[i] == 0)
                {
                    totalHappy += customers[i];
                }
                else
                {
                    windowMakeHappy += customers[i];
                }
                if (i >= x)
                {
                    windowMakeHappy -= grumpy[i - x] * customers[i - x];
                }
                makeHappy = Math.Max(makeHappy, windowMakeHappy);
            }
            return totalHappy + makeHappy;
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
