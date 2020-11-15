using System;
using System.Collections.Generic;
using System.Linq;

namespace DistributeRepeatingIntegers
{

    public class Solution
    {
        public bool CanDistribute(int[] nums, int[] quantity)
        {
            var map = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                map[item] = map.ContainsKey(item) ? map[item] + 1 : 1;
            }

            quantity = quantity.OrderByDescending(c => c).ToArray();

            var arr = map.Values.ToArray().OrderBy(a => a).ToArray();

            return Solve(arr, quantity, 0);
        }

        private bool Solve(int[] nums, int[] quantity, int idx)
        {
            if (idx>=quantity.Length)
            {
                return true;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]>=quantity[idx])
                {
                    nums[i] -= quantity[idx];

                    if (Solve(nums, quantity, idx+1))
                    {
                        return true;
                    }
                    nums[i] += quantity[idx];
                }

            }

            return false;
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
