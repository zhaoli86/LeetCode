using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicCalculatorIII
{

    //Input: s = "2*(5+5*2)/3+(6/2+8)"
    //Output: 21
    public class Solution
    {
        private int i;
        public int Calculate(string s)
        {
            var stack = new Stack<int>();
            int num = 0;
            char op = '+';
            while (i<s.Length)
            {
                char ch = s[i++];
                if (char.IsDigit(ch)) num = num * 10 + (ch - '0');
                if (ch=='(') num = Calculate(s);
                if (i==s.Length || ch=='+' || ch=='-' || ch=='*' || ch=='/' || ch==')')
                {
                    if (op=='+') stack.Push(num);
                    else if (op == '-') stack.Push(-num);
                    else if (op == '*') stack.Push(stack.Pop() * num);
                    else if (op == '/') stack.Push(stack.Pop() / num);
                    op = ch;
                    num = 0;
                }
                if (ch==')') break;
            }
            return stack.Sum();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var result = s.Calculate("1+1");
            Console.WriteLine("Hello World!");
        }
    }
}
