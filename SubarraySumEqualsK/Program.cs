using System;
using System.Collections.Generic;

namespace SubarraySumEqualsK
{
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            int len = nums.Length;
            var cumulativeSum = new int[len];
            var map = new Dictionary<int, int>();
            map[0] = 1;
            cumulativeSum[0] = nums[0];
            for (int i = 1; i < len; i++)
            {
                cumulativeSum[i] = cumulativeSum[i - 1] + nums[i];
            }

            int result = 0;
            foreach (var sum in cumulativeSum)
            {
                if (map.ContainsKey(sum-k))
                {
                    result += map[sum-k];
                }

                if (map.ContainsKey(sum))
                {
                    map[sum]++;
                }
                else
                {
                    map[sum] = 1;
                }
            }

            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 2, 3 };
            var result = new Solution().SubarraySum(input, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
