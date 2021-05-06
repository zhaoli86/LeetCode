using System;
using System.Collections.Generic;

namespace FindAllAnagramsInString
{
    public class Solution
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();
            int pLen = p.Length;

            if (pLen>s.Length)
            {
                return result;
            }
            var map = new int[26];
            foreach (var c in p)
            {
                map[c - 'a']++;
            }
            for (int i = 0; i < pLen; i++)
            {
                map[s[i] - 'a']--;
            }
            if (Match(map))
            {
                result.Add(0);
            }
            for (int i = pLen; i < s.Length; i++)
            {
                map[s[i] - 'a']--;
                map[s[i - pLen] - 'a']++;
                if (Match(map))
                {
                    result.Add(i - pLen + 1);
                }
            }
            return result;
        }

        private bool Match(int[] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i]!=0)
                {
                    return false;
                }
            }
            return true;
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
