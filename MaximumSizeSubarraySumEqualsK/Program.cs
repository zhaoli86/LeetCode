using System;
using System.Collections.Generic;

namespace MaximumSizeSubarraySumEqualsK
{
    public class Solution
    {
        public int MaxSubArrayLen(int[] nums, int k)
        {
            int len = nums.Length;
            var presum = new int[len];
            presum[0] = nums[0];
            for (int i = 1; i < len; i++)
            {
                presum[i] = presum[i - 1] + nums[i];
            }

            var map = new Dictionary<int, int>();
            map[0] = -1;
            for (int i = 0; i < len; i++)
            {
                if (!map.ContainsKey(presum[i]))
                {
                    map[presum[i]] = i;
                }
            }
            int result = 0;
            for (int i = len-1; i >=0; i--)
            {
                if(map.ContainsKey(presum[i]-k))
                {
                    result = Math.Max(result, i - map[presum[i]-k]);
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, -1, 5, -2, 3 };
            var r = new Solution().MaxSubArrayLen(input, 3);

            Console.WriteLine("Hello World!");
        }
    }
}
