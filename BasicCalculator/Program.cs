using System;
using System.Collections.Generic;

namespace BasicCalculator
{
    public class Solution
    {
        public int Calculate(string s)
        {
            var stack = new Stack<int>();
            int result = 0;
            int number = 0;
            int sign = 1;
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                {
                    number = number * 10 + (c - '0');
                }
                else if (c=='+')
                {
                    result = result + sign*number;
                    sign = 1;
                    number = 0;
                }
                else if (c=='-')
                {
                    result = result + sign * number;
                    sign = -1;
                    number = 0;
                }
                else if (c=='(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if (c==')')
                {
                    result = result + sign * number;
                    result = result * stack.Pop();
                    result = result + stack.Pop();
                    number = 0;
                }
            }
            if (number!=0)
            {
                result = result + sign * number;
            }

            return result;
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
