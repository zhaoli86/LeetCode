using System;

namespace RemoveDuplicatesFromSortedArray
{
    class Program
    {
        public class Solution
        {
            public int RemoveDuplicates(int[] nums)
            {
                int count = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i]==nums[i-1])
                    {
                        count++;
                    }
                    else
                    {
                        nums[i - count] = nums[i];
                    }
                }
                return nums.Length-count;
            }
        }
        static void Main(string[] args)
        {
            var s = new Solution();
            var result = s.RemoveDuplicates(null);
            Console.WriteLine("Hello World!");
        }
    }
}
