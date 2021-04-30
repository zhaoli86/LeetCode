using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveAllAdjacentDuplicatesInString
{
    public class Solution
    {
        public string RemoveDuplicates(string s)
        {
            var duplicates = new HashSet<string>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                duplicates.Add(c.ToString()+c.ToString());
            }

            int prevLen = -1;
            while (prevLen!=s.Length)
            {
                prevLen = s.Length;
                foreach (var item in duplicates)
                {
                    s = s.Replace(item, "");
                }
            }
            return s;
        }
    }

    public class Solution1
    {
        public string RemoveDuplicates(string S)
        {
            var sb = new StringBuilder();
            foreach (var c in S.ToCharArray())
            {
                if (sb.Length!=0 && sb[sb.Length-1]==c)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }

    public class Solution3
    {
        public string RemoveDuplicates(string s)
        {
            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if (stack.Count!=0)
                {
                    if (stack.Peek()==ch)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(ch);
                    }
                }
                else
                {
                    stack.Push(ch);
                }

            }

            return new string(stack.Reverse().ToArray());
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
