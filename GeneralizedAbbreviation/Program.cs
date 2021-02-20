using System;
using System.Collections.Generic;

namespace GeneralizedAbbreviation
{
    public class Solution
    {
        public IList<string> GenerateAbbreviations(string word)
        {
            var result = new List<string>();
            Backtrack(result, word, "", 0, 0);
            return result;
        }

        private void Backtrack(List<string> result, string word, string cur, int count, int pos)
        {
            if (pos == word.Length)
            {
                if (count > 0)
                {
                    cur = cur + count;
                }
                result.Add(cur);
            }
            else
            {
                Backtrack(result, word, cur, count + 1, pos + 1);
                Backtrack(result, word, cur + (count > 0 ? count.ToString() : "") + word[pos], 0, pos + 1);
            }
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
