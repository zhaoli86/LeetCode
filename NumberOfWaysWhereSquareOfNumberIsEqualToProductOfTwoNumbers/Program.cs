using System;
using System.Collections.Generic;

namespace NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbers
{
    public class Solution
    {
        public int NumTriplets(int[] nums1, int[] nums2)
        {
            long result = 0;
            foreach (long num in nums1)
            {
                result += TwoProduct(num * num, nums2);
            }
            foreach (long num in nums2)
            {
                result += TwoProduct(num * num, nums1);
            }
            return (int)result;
        }
        private long TwoProduct(long n, int[] nums)
        {
            var map = new Dictionary<long, long>();
            long count = 0;
            foreach (var num in nums)
            {
                if (n % num == 0)
                {
                    if (map.TryGetValue(n / num, out var result))
                    {
                        count += result;
                    }
                }
                map[num] = map.ContainsKey(num) ? ++map[num] : 1;
            }
            return count;
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
