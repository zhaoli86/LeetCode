using System;
using System.Collections.Generic;

namespace ContinuousSubaraySum
{
    public class Solution
    {
        public bool CheckSubarraySum(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            map[0] = -1;
            int runningSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                runningSum += nums[i];
                runningSum %= k;
                if (map.TryGetValue(runningSum, out var idx))
                {
                    if (i-idx>1)
                    {
                        return true;
                    }
                }
                else map[runningSum] = i;
            }
            return false;
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
