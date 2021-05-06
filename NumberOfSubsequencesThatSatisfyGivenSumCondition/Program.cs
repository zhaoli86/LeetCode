using System;

namespace NumberOfSubsequencesThatSatisfyGivenSumCondition
{
    public class Solution
    {
        public int NumSubseq(int[] nums, int target)
        {
            Array.Sort(nums);
            int result = 0, n = nums.Length;
            int divisor = (int)1e9 + 7;
            var pow = new int[n];
            pow[0] = 1;
            for (int i = 1; i < n; i++)
            {
                pow[i] = (pow[i - 1] * 2) % divisor;
            }
            int l = 0, r = n - 1;
            while (l<=r)
            {
                if (nums[l]+nums[r]>target)
                {
                    r--;
                }
                else
                {
                    result = (result + pow[r-l]) % divisor;
                    l++;
                }
            }
            return result;

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
