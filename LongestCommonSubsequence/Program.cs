using System;

namespace LongestCommonSubsequence
{
    public class Solution
    {
        public int LongestCommonSubsequence2(string text1, string text2)
        {
            var m = text1.Length;
            var n = text2.Length;
            if (m<n)
            {
                return LongestCommonSubsequence2(text2, text1);
            }

            var t = new int[m+1, n+1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (text1[i]==text2[j])
                    {
                        t[i + 1, j + 1] = t[i, j] + 1;
                    }
                    else
                    {
                        t[i + 1, j + 1] = Math.Max(t[i, j + 1], t[i + 1, j]);
                    }

                }
            }

            return t[m, n];
        }

        public int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length;
            int n = text2.Length;
            var t = new int[n + 1];
            int pre, cur;
            for (int i = 1; i <= m; i++)
            {
                pre = 0;
                for (int j = 1; j <= n; j++)
                {
                    cur = t[j];
                    if (text1[i-1]==text2[j-1])
                    {
                        t[j] = 1 + pre;
                    }
                    else
                    {
                        t[j] = Math.Max(t[j - 1], cur);
                    }
                    pre = cur;
                }
            }
            return t[n];
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
