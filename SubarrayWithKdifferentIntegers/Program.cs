using System;
using System.Collections.Generic;

namespace SubarrayWithKdifferentIntegers
{
    public class Solution
    {
        public int SubarraysWithKDistinct(int[] A, int K)
        {
            return AtMost(A, K) - AtMost(A, K - 1);
        }

        private int AtMost(int[] a, int k)
        {
            int i = 0, res = 0;
            var count = new Dictionary<int, int>();

            for (int j = 0; j < a.Length; j++)
            {
                var c = count.ContainsKey(a[j]) ? count[a[j]] : 0;

                if (c==0)
                {
                    k--;
                }
                count[a[j]] = c + 1;

                while (k<0)
                {
                    count[a[i]] = count[a[i]] - 1;
                    if (count[a[i]]==0)
                    {
                        k++;
                    }
                    i++;
                }
                res += j - i + 1;
            }
            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 1, 1 };
            var k = 2;
            var res = new Solution().SubarraysWithKDistinct(input, k);
            Console.WriteLine("Hello World!");
        }
    }
}
