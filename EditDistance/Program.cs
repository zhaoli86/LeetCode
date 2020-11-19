using System;

namespace EditDistance
{
    public class Solution
    {
        public int MinDistance2(string word1, string word2)
        {
            var m = word1.Length;
            var n = word2.Length;
            var t = new int[m + 1, n + 1];
            //word1: i, word2: j
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        t[i, j] = 0;
                    }
                    else if (i == 0)
                    {
                        t[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        t[i, j] = i;
                    }
                    else
                    {
                        if (word1[i - 1] == word2[j - 1])
                        {
                            t[i, j] = t[i - 1, j - 1];
                        }
                        else
                        {
                            t[i, j] = 1 + Math.Min(Math.Min(t[i - 1, j - 1], t[i - 1, j]), t[i, j - 1]);
                        }
                    }
                }
            }
            return t[m, n];
        }


        public int MinDistance(string word1, string word2)
        {

            var m = word1.Length;
            var n = word2.Length;
            var pre = new int[n + 1];
            var cur = new int[n + 1];
            for (int j = 1; j <= n; j++)
            {
                pre[j] = j;
            }

            for (int i = 1; i <= m; i++)
            {
                cur[0] = i;
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        cur[j] = pre[j - 1];
                    }
                    else
                    {
                        cur[j] = 1 + Math.Min(Math.Min(pre[j - 1], pre[j]), cur[j - 1]);
                    }
                }

                Array.Clear(pre, 0, pre.Length);
                var temp = pre;
                pre = cur;
                cur = temp;
            }

            return pre[n];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pre = new int[2] { 1, 2 };
            var cur = new int[2] { 3, 4 };
            var temp = pre;
            pre = cur;
            cur = temp;
            Console.WriteLine("Hello World!");
        }
    }
}
