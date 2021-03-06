﻿using System;

namespace FibonacciNumber
{
    public class Solution
    {
        public int Fib(int n)
        {
            if (n==0)
            {
                return 0;
            }
            if (n==1)
            {
                return 1;
            }
            int first = 0, second = 1, sum = 0;
            for (int i = 2; i <= n; i++)
            {
                sum = first + second;
                first = second;
                second = sum;
            }
            return sum;
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
