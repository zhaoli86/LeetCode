using System;
using System.Collections.Generic;

namespace WordBreakII
{
    public class Solution
    {
        private Dictionary<string, List<string>> cache = new Dictionary<string, List<string>>();
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return Backtrack(s, wordDict);
        }

        private IList<string> Backtrack(string s, IList<string> wordDict)
        {
            if (cache.ContainsKey(s))
            {
                return cache[s];
            }

            var result = new List<string>();

            foreach (var word in wordDict)
            {
                if (!s.StartsWith(word))
                {
                    continue;
                }
                var next = s.Substring(word.Length);

                if (string.IsNullOrEmpty(next))
                {
                    result.Add(word);
                    continue;
                }
                var remains = Backtrack(next, wordDict);
                foreach (var sub in remains)
                {
                    var combined = word + " " + sub;
                    result.Add(combined);
                }

            }
            cache[s] = result;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = "pineapplepenapple";

            var words = new List<string> { "apple", "pen", "applepen", "pine", "pineapple" };

            var result = new Solution().WordBreak(s, words);

            Console.WriteLine("Hello World!");
        }
    }
}
