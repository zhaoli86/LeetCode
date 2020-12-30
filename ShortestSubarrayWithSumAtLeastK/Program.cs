using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestSubarrayWithSumAtLeastK
{
    public class Solution
    {
        public int ShortestSubarray(int[] a, int k)
        {
            int n = a.Length;
            int res = n + 1;
            var list = new List<int>();
            var prefixSum = new long[n + 1];
            for (int i = 0; i < n; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + a[i];
            }
            for (int i = 0; i < prefixSum.Length; i++)
            {
                while (list.Any() && prefixSum[i] <= prefixSum[list.Last()])
                {
                    list.RemoveAt(list.Count - 1);
                }

                while (list.Any() && prefixSum[i] >= prefixSum[list.First()] + k)
                {
                    res = Math.Min(res, i - list.First());

                    list.RemoveAt(0);
                }

                list.Add(i);
            }
            return res == n + 1 ? -1 : res;
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
