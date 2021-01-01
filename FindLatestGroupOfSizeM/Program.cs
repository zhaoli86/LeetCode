using System;

namespace FindLatestGroupOfSizeM
{
    public class Solution
    {
        public int FindLatestStep(int[] arr, int m)
        {
            int n = arr.Length, res = -1;
            var len = new int[n + 2];
            var count = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                int a = arr[i], left = len[a - 1], right = len[a + 1];
                len[a] = len[a - left] = len[a + right] = left + right + 1;
                count[left]--;
                count[right]--;
                count[len[a]]++;
                if (count[m]>0)
                {
                    res = i + 1;
                }
            }
            return res;
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
