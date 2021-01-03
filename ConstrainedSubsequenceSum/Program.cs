using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstrainedSubsequenceSum
{
    class Program
    {
        public class Solution
        {
            public int ConstrainedSubsetSum(int[] nums, int k)
            {
                var list = new LinkedList<int>();
                int res = nums[0];
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] += list.Any() ? list.First() : 0;
                    res = Math.Max(res, nums[i]);
                    while (list.Any() && nums[i] > list.Last())
                    {
                        list.RemoveLast();
                    }
                    if (nums[i] > 0)
                    {
                        list.AddLast(nums[i]);
                    }
                    while (i >= k && list.Any() && nums[i-k] == list.First())
                    {
                        list.RemoveFirst();
                    }
                }
                return res;
            }
        }
        static void Main(string[] args)
        {
            var input = new int[] { 10, 0, 0, 5, 20 };
            var result = new Solution().ConstrainedSubsetSum(input, 2);

            Console.WriteLine("Hello World!");
        }
    }
}
