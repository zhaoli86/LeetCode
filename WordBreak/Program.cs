using System;
using System.Collections.Generic;

namespace WordBreak
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> words)
        {
            var dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int len = 1; len <= s.Length; len++)
            {
                foreach (var word in words)
                {
                    if (word.Length<=len)
                    {
                        if (dp[len-word.Length]&&s.Substring(len-word.Length, word.Length)==word)
                        {
                            dp[len] = true;
                            break;
                        }
                    }
                }
            }
            return dp[s.Length];
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
