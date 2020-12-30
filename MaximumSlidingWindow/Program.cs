using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumSlidingWindow
{
    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return new int[0];
            }
            var result = new int[nums.Length + 1 - k];

            var q = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //1, 3, -1, -3, 5, 3, 6, 7
                if (q.FirstOrDefault() == i - k)
                {
                    q.RemoveAt(0);
                }
                while (q.Any() && nums[q.Last()] < nums[i])
                {
                    q.RemoveAt(q.Count - 1);
                }
                q.Add(i);
                if (i + 1 >= k)
                {
                    result[i + 1 - k] = nums[q.First()];
                }
            }

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            var res = new Solution().MaxSlidingWindow(input, 3);
            Console.WriteLine("Hello World!");
        }
    }
}
