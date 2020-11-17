using System;

namespace LongestCommonSubsequence
{
    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var m = text1.Length;
            var n = text2.Length;
            if (m<n)
            {
                return LongestCommonSubsequence(text2, text1);
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
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
