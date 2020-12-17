using System;

namespace FindMaxConsecutiveOnesII
{
    public class Solution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0, k = 1, zeroCount = 0;
            for (int l = 0, r = 0; r < nums.Length; r++)
            {
                if (nums[r]==0)
                {
                    zeroCount++;
                }
                while (zeroCount>k)
                {
                    if (nums[l++]==0)
                    {
                        zeroCount--;
                    }
                }
                max = Math.Max(max, r - l + 1);
            }
            return max;
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
