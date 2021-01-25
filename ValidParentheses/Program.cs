using System;
using System.Collections.Generic;

namespace ValidParentheses
{
    public class Solution
    {
        public bool IsValid(string s)
        {
            var map = new Dictionary<char, char> { { '}', '{'},
                {']', '[' }, {')', '('}};
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (map.ContainsKey(c))
                {
                    if (stack.Count!=0&&stack.Peek()==map[c])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
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
