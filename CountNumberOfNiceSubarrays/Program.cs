using System;
using System.Collections.Generic;

namespace CountNumberOfNiceSubarrays
{
    public class Solution
    {
        public int NumberOfSubarrays(int[] nums, int k)
        {
            return AtMost(nums, k) - AtMost(nums, k - 1);
        }

        private int AtMost(int[] nums, int k)
        {
            int res = 0, i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                k = k - nums[j] % 2;
                while (k<0)
                {
                    k = k + nums[i] % 2;
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
            Console.WriteLine("Hello World!");
        }
    }
}
