using System;
using System.Linq;

namespace Max_Dot_Product_of_Two_Subsequences
{
    public class Solution
    {
        public int MaxDotProduct(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;

            var t = new long[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i==0||j==0)
                    {
                        t[i, j] = int.MinValue;
                    }
                    else
                    {
                        t[i, j] = new long[] {t[i-1, j-1]+nums1[i-1]*nums2[j-1], nums1[i-1]*nums2[j-1],
                        t[i, j-1], t[i-1, j] }.Max();
                    }
                }
            }
            return (int)t[m, n];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var p = new Solution();
            var s1 = new int[] { 2, 1, -2, 5 };
            var s2 = new int[] { 3, 0, -6 };
            var result = p.MaxDotProduct(s1, s2);
            Console.WriteLine("Hello World!");
        }
    }
}
