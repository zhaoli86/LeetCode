using System;

namespace RemoveDuplicatesFromSortedArrayII
{
    class Program
    {
        public class Solution
        {
            public int RemoveDuplicates(int[] nums)
            {
                int i = 0;
                foreach (var num in nums)
                {
                    if (i<2||num!=nums[i-2])
                    {
                        nums[i++] = num;
                    }

                }
                return i;
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
