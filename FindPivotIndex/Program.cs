using System;

namespace FindPivotIndex
{
    public class Solution
    {
        public int PivotIndex(int[] nums)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }
            int curSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum==curSum+curSum+nums[i])
                {
                    return i;
                }
                else
                {
                    curSum += nums[i];
                }
            }
            return -1;
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
