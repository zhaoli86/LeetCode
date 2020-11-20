using System;

namespace DeleteOperationForTwoStrings
{
    class Program
    {
        public class Solution
        {
            public int MinDistance(string word1, string word2)
            {
                var commonLength = LongestCommonSubsequence(word1, word2);
                return word1.Length - commonLength + word2.Length - commonLength;
            }

            private int LongestCommonSubsequence(string text1, string text2)
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
                        if (text1[i - 1] == text2[j - 1])
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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
