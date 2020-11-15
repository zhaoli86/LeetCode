using System;

namespace RemoveElement
{
    class Program
    {
        public class Solution
        {
            public int RemoveElement(int[] nums, int val)
            {
                int j = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i]!=val)
                    {
                        nums[j++] = nums[i];
                    }
                }
                return j;
            }
        }
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.RemoveElement(null, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
