using System;

namespace MinimumAsciiDeleteSumForTwoStrings
{
    public class Solution
    {
        public int MinimumDeleteSum2(string s1, string s2)
        {
            var m = s1.Length;
            var n = s2.Length;

            var t = new int[m+1, n+1];

            for (int j = 1; j <= n; j++)
            {
                t[0, j] = t[0, j - 1] + s2[j - 1];
            }

            for (int i = 1; i <= m; i++)
            {
                t[i, 0] = t[i - 1, 0] + s1[i - 1];

                for (int j = 1; j <= n; j++)
                {
                    if (s1[i-1]==s2[j-1])
                    {
                        t[i, j] = t[i - 1, j - 1];
                    }
                    else
                    {
                        t[i, j] = Math.Min(t[i - 1, j] + s1[i - 1], t[i, j - 1] + s2[j - 1]);
                    }
                }
            }
            return t[m, n];
            
        }

        public int MinimumDeleteSum(string s1, string s2)
        {
            var m = s1.Length;
            var n = s2.Length;
            var t = new int[n + 1];
            for (int j = 1; j <= n; j++)
            {
                t[j] = t[j - 1] + s2[j - 1];
            }
            for (int i = 1; i <= m; i++)
            {
                int t1 = t[0];
                t[0] = t[0] + s1[i - 1];
                for (int j = 1; j <= n; j++)
                {
                    int t2 = t[j];
                    if (s1[i-1]==s2[j-1])
                    {
                        t[j] = t1;
                    }
                    else
                    {
                        t[j] = Math.Min(t[j - 1] + s2[j - 1], t[j] + s1[i - 1]);
                    }

                    t1 = t2;
                }
            }
            return t[n];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Solution();
            string s1 = "sea";
            string s2 = "eat";
            var result = p.MinimumDeleteSum(s1, s2);
            Console.WriteLine("Hello World!");
        }
    }
}
