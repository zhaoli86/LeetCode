using System;

namespace FindLongestSubstringContainingEvenVowels
{
    public class Solution
    {
        private int[] c = new int[] { 1, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 16, 0, 0, 0, 0, 0 };

        public int FindTheLongestSubstring(string s)
        {
            int res = 0, mask = 0;
            var m = new int[32];
            Array.Fill(m, -1);
            for (int i = 0; i < s.Length; i++)
            {
                //eleetminicoworoep
                mask ^= c[s[i] - 'a'];
                if (mask != 0 && m[mask] == -1)
                {
                    m[mask] = i;
                }
                res = Math.Max(res, i - m[mask]);
            }




            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var input = "eleetminicoworoep";
            var res = s.FindTheLongestSubstring(input);
            Console.WriteLine("Hello World!");
        }
    }
}
