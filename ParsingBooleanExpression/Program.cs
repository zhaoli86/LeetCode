using System;
using System.Collections.Generic;

namespace ParsingBooleanExpression
{
    //"|(&(t,f,t),!(t))"
    public class Solution
    {
        public bool ParseBoolExpr(string expression)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                var ch = expression[i];
                if (ch==')')
                {
                    var seen = new HashSet<char>();
                    while (stack.Peek()!='(')
                    {
                        seen.Add(stack.Pop());
                    }

                    stack.Pop();
                    var op = stack.Pop();
                    if (op=='&')
                    {
                        stack.Push(seen.Contains('f') ? 'f' : 't');
                    }
                    else if (op=='|')
                    {
                        stack.Push(seen.Contains('t') ? 't' : 'f');
                    }
                    else
                    {
                        stack.Push(seen.Contains('t') ? 'f' : 't');
                    }
                }
                else if (ch!=',')
                {
                    stack.Push(ch);
                }
            }
            return stack.Pop() == 't';
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
