using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveAllAdjacentDuplicatesInStringII
{
    public class Solution1
    {
        public string RemoveDuplicates(string s, int k)
        {
            var stack = new Stack<int>();
            var sb = new StringBuilder(s);

            for (int i = 0; i < sb.Length; i++)
            {
                if (i==0 || sb[i]!=sb[i-1])
                {
                    stack.Push(1);
                }
                else
                {
                    var count = stack.Pop();
                    count++;
                    if (count==k)
                    {
                        sb.Remove(i - k + 1, k);
                        i = i - k;
                    }
                    else
                    {
                        stack.Push(count);
                    }
                }
            }
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                i = 2;
            }
            Console.WriteLine("Hello World!");
        }
    }
}
