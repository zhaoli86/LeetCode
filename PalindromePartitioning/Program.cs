using System;
using System.Collections.Generic;

namespace PalindromePartitioning
{
    public class Solution
    {
        private List<IList<string>> result = new List<IList<string>>();
        private List<string> tempList = new List<string>();

        public IList<IList<string>> Partition(string s)
        {
            Backtrack(s, 0);
            return result;
        }

        private void Backtrack(string s, int pos)
        {
            if (tempList.Count > 0 && pos >= s.Length)
            {
                result.Add(new List<string>(tempList));
            }
            else
            {
                for (int i = pos; i < s.Length; i++)
                {
                    if (IsPalindrome(s, pos, i))
                    {
                        tempList.Add(s.Substring(pos, i - pos + 1));

                        Backtrack(s, i + 1);

                        tempList.RemoveAt(tempList.Count - 1);
                    }
                }
            }
        }
        private bool IsPalindrome(string s, int l, int r)
        {
            if (l==r)
            {
                return true;
            }
            while (l<r)
            {
                if (s[l]!=s[r])
                {
                    return false;
                }
                l++;
                r--; 
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = "aab";
            var result = new Solution().Partition(input);
            Console.WriteLine("Hello World!");
        }
    }
}
