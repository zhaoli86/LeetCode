using System;

namespace SquaresOfSortedArray
{
    public class Solution
    {
        public int[] SortedSquares(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            var result = new int[nums.Length];
            for (int i = nums.Length-1; i >=0; i--)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    result[i] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[i] = nums[right] * nums[right];
                    right--;
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
