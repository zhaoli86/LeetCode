using System;

namespace FindFirstAndLastPositionOfElementInSortedArray
{
    public class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int lo = 0, hi = nums.Length-1, first = -1, second = -1;
            while (lo<=hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid]>target)
                {
                    hi = mid - 1;
                }
                else if (nums[mid]<target)
                {
                    lo = mid + 1;
                }
                else
                {
                    first = mid;
                    hi = mid-1;
                }
            }
            if (first==-1)
            {
                return new int[] { -1, -1 };
            }
            lo = 0;
            hi = nums.Length - 1;
            while (lo<=hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] > target)
                {
                    hi = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    lo = mid + 1;
                }
                else
                {
                    second = mid;
                    lo = mid+1;
                }
            }

            return new int[] { first, second };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 5, 7, 7, 8, 8, 10 };
            var result = new Solution().SearchRange(input, 8);
            Console.WriteLine("Hello World!");
        }
    }
}
