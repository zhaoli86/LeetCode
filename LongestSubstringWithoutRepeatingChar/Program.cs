using System;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingChar
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int i = 0, j = 0, res = 0;
            var set = new HashSet<char>();
            while (j<s.Length && i<s.Length)
            {
                //pwwkew
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    res = Math.Max(res, j - i);
                }
                else
                {
                    set.Remove(s[i++]);
                }
            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = "pwwkew";
            var s = new Solution();
            var res = s.LengthOfLongestSubstring(input);
            Console.WriteLine("Hello World!");
        }
    }
}
