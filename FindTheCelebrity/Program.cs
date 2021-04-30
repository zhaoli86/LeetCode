using System;

namespace FindTheCelebrity
{
    public class Solution
    {
        private bool Knows(int a, int b)
        {
            return false;
        }
        public int FindCelebrity(int n)
        {
            int candidate = 0;
            for (int i = 1; i < n; i++)
            {
                if (Knows(candidate, i))
                {
                    candidate = i;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i==candidate)
                {
                    continue;
                }
                if (Knows(candidate, i) || !Knows(i, candidate))
                {
                    return -1;
                }
            }
            return candidate;
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
