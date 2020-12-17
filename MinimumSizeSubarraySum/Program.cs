using System;

namespace MinimumSizeSubarraySum
{
    public class Solution
    {
        //[2,3,1,2,4,3]

        public int MinSubArrayLen(int s, int[] nums)
        {
            if (nums==null || nums.Length==0)
            {
                return 0;
            }

            int i = 0, j = 0, sum = 0, min = int.MaxValue;
            while (j<nums.Length)
            {
                sum += nums[j++];
                while (sum>=s)
                {
                    min = Math.Min(j - i, min);
                    sum -= nums[i++];
                }
            }
            return min == int.MaxValue ? 0 : min;

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
