using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LongestContinuousSubarrayWithAbsoluteDiffK
{
    public class Solution
    {
        public int LongestSubarray(int[] nums, int limit)
        {
            int i = 0, j;
            var map = new SortedDictionary<int, int>();
            for (j = 0; j < nums.Length; j++)
            {
                map[nums[j]] = map.ContainsKey(nums[j]) ? map[nums[j]] + 1 : 1;
                if (map.Last().Key - map.First().Key > limit)
                {
                    map[nums[i]]--;
                    if (map[nums[i]] == 0)
                    {
                        map.Remove(nums[i]);
                    }
                    i++;
                }
            }
            return j - i; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 10, 1, 2, 4, 7, 2 };
            int limit = 5;

            var result = new Solution().LongestSubarray(input, limit);

            Console.WriteLine("Hello World!");
        }
    }
}
