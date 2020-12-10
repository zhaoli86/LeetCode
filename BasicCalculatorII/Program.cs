using System;
using System.Collections.Generic;

namespace BasicCalculatorII
{
    public class Solution
    {
        public int Calculate(string s)
        {
            int result = 0;
            var stack = new Stack<int>();
            int number = 0;
            char sign = '+';
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsDigit(c))
                {
                    number = number * 10 + (c - '0');
                }
                if ((!char.IsDigit(c) && c!=' ') || i==s.Length-1)
                {
                    if (sign=='+')
                    {
                        stack.Push(number);
                    }
                    else if (sign=='-')
                    {
                        stack.Push(-number);
                    }
                    else if (sign=='*')
                    {
                        stack.Push(stack.Pop() * number);
                    }
                    else if (sign=='/')
                    {
                        stack.Push(stack.Pop() / number);
                    }

                    number = 0;
                    sign = c;
                }
            }

            foreach (var item in stack)
            {
                result = result + item;
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
