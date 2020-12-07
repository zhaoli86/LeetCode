using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveAllAdjacentDuplicatesInString
{
    public class Solution
    {
        public string RemoveDuplicates(string S)
        {
            var duplicates = new HashSet<string>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                duplicates.Add(string.Join("", new[] { c, c }));
            }

            int prevLen = -1;
            while (prevLen!=S.Length)
            {
                prevLen = S.Length;
                foreach (var item in duplicates)
                {
                    S = S.Replace(item, "");
                }
            }
            return S;
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
