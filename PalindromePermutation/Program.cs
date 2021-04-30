using System;
using System.Collections.Generic;

namespace PalindromePermutation
{
    public class Solution
    {
        public bool CanPermutePalindrome(string s)
        {
            int count = 0;
            var frequencies = new int[26];
            foreach (var c in s)
            {
                frequencies[c - 'a']++;
            }
            foreach (var item in frequencies)
            {
                if (item%2!=0)
                {
                    count++;
                }
            }
            return count <= 1;
        }

        public bool Can2(string s)
        {
            var set = new HashSet<char>();
            foreach (var ch in s)
            {
                if (set.Contains(ch))
                {
                    set.Remove(ch);
                }
                else
                {
                    set.Add(ch);
                }
            }
            return set.Count <= 1;
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
