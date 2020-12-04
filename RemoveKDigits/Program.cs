using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveKDigits
{
    public class Solution
    {
        public string RemoveKdigits(string num, int k)
        {
            if (k==num.Length)
            {
                return "0";
            }
            var stack = new Stack<char>();
            for (int i = 0; i < num.Length; i++)
            {
                while (k>0 && stack.Count!=0 && stack.Peek()>num[i])
                {
                    stack.Pop();
                    k--;
                }
                stack.Push(num[i]);
            }
            while (k>0)
            {
                stack.Pop();
                k--;
            }

            var sb = new StringBuilder();
            while (stack.Count!=0)
            {
                sb.Insert(0, stack.Pop());
            }

            while (sb.Length>1 && sb[0]=='0')
            {
                sb.Remove(0, 1);
            }
            return sb.ToString();
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
