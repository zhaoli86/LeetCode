using System;
using System.Collections.Generic;

namespace ContiguousArray
{
    public class Solution
    {
        public int FindMaxLength(int[] nums)
        {
            var map = new Dictionary<int, int>();
            int sum = 0, maxLen = 0;
            //if a subarray that starts from 0 has a sum of 0, we need an index that's located before the 0th
            //index for our logic to work
            map[0] = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                sum+= nums[i] == 1 ? 1 : -1;
                if (map.ContainsKey(sum))
                {
                    maxLen = Math.Max(maxLen, i - map[sum]);
                }
                else
                {
                    map[sum] = i;
                }
            }
            return maxLen;
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
