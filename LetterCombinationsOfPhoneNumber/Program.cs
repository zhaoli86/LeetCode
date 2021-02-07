using System;
using System.Collections.Generic;
using System.Linq;

namespace LetterCombinationsOfPhoneNumber
{
    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (digits==null || digits.Length==0)
            {
                return new List<string>();
            }
            var mapping = new string[] { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            var q = new Queue<string>();
            q.Enqueue("");
            for (int i = 0; i < digits.Length; i++)
            {
                var digit = int.Parse(digits[i].ToString());
                while (q.Peek().Length==i)
                {
                    var node = q.Dequeue();
                    foreach (var ch in mapping[digit])
                    {
                        q.Enqueue(node + ch);
                    }
                }
            }
            return q.ToList();
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
