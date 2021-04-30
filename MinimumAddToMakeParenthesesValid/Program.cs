using System;
using System.Collections.Generic;

namespace MinimumAddToMakeParenthesesValid
{
    public class Solution
    {
        public int MinAddToMakeValid(string s)
        {
            int result = 0;
            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if (ch=='(')
                {
                    stack.Push(ch);
                }
                else
                {
                    if (stack.Count!=0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result++;
                    }
                }
            }
            result += stack.Count;
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
