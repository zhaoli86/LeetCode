using System;
using System.Collections.Generic;

namespace NumberOfSubstringsContainingAllChars
{
    public class Solution
    {
        public int NumberOfSubstrings(string s)
        {
            var counts = new Dictionary<char, int> { { 'a', 0 }, { 'b', 0 }, { 'c', 0 } };
            int total = 0, i = 0;
            foreach (var c in s)
            {
                counts[c]++;
                while (counts['a']>0&&counts['b']>0&&counts['c']>0)
                {
                    counts[s[i++]]--;
                }
                total += i;
            }
            return total;
        }
    }

    public class Solution2
    {
        public int NumberOfSubstrings(string s)
        {
            var counts = new int[3];
            int i = 0, total = 0;
            foreach (var c in s)
            {
                counts[c - 'a']++;
                while (counts[0]>0&&counts[1]>0&&counts[2]>0)
                {
                    counts[s[i++] - 'a']--;
                }
                total += i;
            }
            return total;
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
