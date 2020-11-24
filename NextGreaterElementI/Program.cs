using System;
using System.Collections.Generic;

namespace NextGreaterElementI
{
    public class Solution
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var len = nums1.Length;
            var map = new Dictionary<int, int>();
            var result = new int[len];
            var stack = new Stack<int>();
            foreach (var num in nums2)
            {
                while (stack.Count!=0 && stack.Peek()<num)
                {
                    map[stack.Pop()] = num;
                }
                stack.Push(num);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                if (map.TryGetValue(nums1[i], out var n))
                {
                    result[i] = n;
                }
                else
                {
                    result[i] = -1;
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[] { 4, 1, 2 };
            var num2 = new int[] { 1, 3, 4, 2 };
            var result = new Solution().NextGreaterElement(nums1, num2);
            Console.WriteLine("Hello World!");
        }
    }
}
