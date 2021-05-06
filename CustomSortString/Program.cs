using System;
using System.Text;

namespace CustomSortString
{
    public class Solution
    {
        public string CustomSortString(string s, string t)
        {
            var sb = new StringBuilder();
            var map = new int[26];
            foreach (var c in t)
            {
                map[c - 'a']++;
            }
            foreach (var c in s)
            {
                while (map[c-'a']-->0)
                {
                    sb.Append(c);
                }
            }
            for (int i = 0; i < 26; i++)
            {
                while (map[i]-->0)
                {
                    sb.Append((char)('a' + i));
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
