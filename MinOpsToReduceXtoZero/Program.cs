using System;
using System.Linq;

namespace MinOpsToReduceXtoZero
{
    public class Solution
    {
        public int MinOperations(int[] nums, int x)
        {
            int res = int.MaxValue;
            int left = 0, cur = nums.Sum(), n = nums.Length, right = 0;
            for (right = 0; right < n; right++)
            {
                cur -= nums[right];

                while (cur < x && left <= right)
                {
                    cur += nums[left++];
                }
                if (cur == x)
                {
                    res = Math.Min(res, n - 1 - right + left);
                }
            }
            return res == int.MaxValue ? -1 : res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(1<<1>>1);
            Console.WriteLine(1^2);
            int cur = 1;
            cur ^= 1 << 1;

            
            Console.WriteLine("Hello World!");
        }
    }
}
