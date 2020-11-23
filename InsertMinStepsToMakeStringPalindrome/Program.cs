using System;

namespace InsertMinStepsToMakeStringPalindrome
{
    public class Solution
    {
        public int MinInsertions(string s)
        {
            var len = s.Length;
            var t = new int[len, len];

            for (int l = 2; l <= len; l++)
            {
                for (int start = 0; start + l - 1 < len; start++)
                {
                    var end = start + l - 1;
                    if (s[start]==s[end])
                    {
                        t[start, end] = t[start + 1, end - 1];
                    }
                    else
                    {
                        t[start, end] = 1 + Math.Min(t[start + 1, end], t[start, end - 1]);
                    }
                }
            }
            return t[0, len - 1];


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
