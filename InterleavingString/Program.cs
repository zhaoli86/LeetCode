using System;

namespace InterleavingString
{
    public class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            var l1 = s1.Length;
            var l2 = s2.Length;
            if (l1+l2!=s3.Length)
            {
                return false;
            }
            var t = new bool[l1 + 1, l2 + 1];

            for (int i = 0; i < l1+1; i++)
            {
                for (int j = 0; j < l2+1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        t[i, j] = true;
                    }
                    else if (i == 0)
                    {
                        t[i, j] = t[i, j - 1] && s2[j - 1] == s3[i + j - 1];
                    }
                    else if (j == 0)
                    {
                        t[i, j] = t[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                    }
                    else
                    {
                        t[i, j] = t[i, j - 1] && s2[j - 1] == s3[i + j - 1] || t[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                    }
                }
            }

            return t[l1, l2];
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
