using System;
using System.Collections.Generic;

namespace GenerateParentheses
{
    public class Solution
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            Backtrack(result, n, 0, 0, "");
            return result;
        }

        private void Backtrack(List<string> result, int n, int open, int close, string str)
        {
            if (str.Length == n * 2)
            {
                result.Add(str);
                return;
            }
            if (open < n)
            {
                Backtrack(result, n, open + 1, close, str + "(");
            }
            if (close < open)
            {
                Backtrack(result, n, open, close + 1, str + ")");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().GenerateParenthesis(3);
            Console.WriteLine("Hello World!");
        }
    }
}
