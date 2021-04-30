using System;
using System.Collections.Generic;

namespace WordBreak
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> words)
        {
            int len = s.Length;
            var dp = new bool[len + 1];
            dp[0] = true;
            for (int i = 1; i <= len; i++)
            {
                foreach (var word in words)
                {
                    if (i>=word.Length&& dp[i-word.Length]&&s.Substring(i-word.Length, word.Length)==word)
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[len];
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
