using System;
using System.Collections.Generic;

namespace LongestSubstringWithAtMostKDistinctChar
{
    public class Solution
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int res = 0, i = 0, j = 0, distinctCount = 0;
            var map = new Dictionary<char, int>();
            while (j < s.Length)
            {
                //abcabcabc
                if (map.ContainsKey(s[j]))
                {
                    map[s[j]]++;
                }
                else
                {
                    map[s[j]] = 1;
                }
                if (map[s[j]] == 1)
                {
                    distinctCount++;
                }
                j++;
                while (distinctCount > k)
                {
                    map[s[i]]--;
                    if (map[s[i]] == 0)
                    {
                        distinctCount--;
                    }
                    i++;
                }
                res = Math.Max(res, j - i);
            }
            return res;
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
