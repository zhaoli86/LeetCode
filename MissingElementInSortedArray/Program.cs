using System;
using System.Linq;

namespace MissingElementInSortedArray
{
    public class Solution
    {
        public int MissingElement(int[] nums, int k)
        {
            int lo = 0, hi = nums.Length;
            int totalMissing = Missing(nums, 0, nums.Length - 1);
            if (k > totalMissing)
            {
                return nums.Last() + k - totalMissing;
            }
            while (lo<=hi)
            {
                int mid = lo + (hi - lo) / 2;
                int missing = Missing(nums, lo, mid);

                if (k>missing)
                {
                    lo = mid + 1;
                    k -= missing;
                }
                else
                {
                    hi = mid;
                }
            }
            return nums[lo] + k;
        }
        private int Missing(int[] nums, int start, int end)
        {
            return nums[end] - nums[start] - 1 - (end - start - 1);
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
