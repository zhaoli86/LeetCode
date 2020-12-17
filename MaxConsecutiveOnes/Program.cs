using System;

namespace MaxConsecutiveOnes
{
    public class Solution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0, curMax = 0;
            foreach (var num in nums)
            {
                max = Math.Max(max, curMax = num == 0 ? 0 : curMax + 1);
            }
            return max;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, k;
            i = j = k = 5;
            Console.WriteLine("Hello World!");
        }
    }
}
