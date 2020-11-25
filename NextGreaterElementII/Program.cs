using System;
using System.Collections;
using System.Collections.Generic;

namespace NextGreaterElementII
{
    public class Solution
    {
        public int[] NextGreaterElements(int[] nums)
        {
            var len = nums.Length;
            var result = new int[len];
            var stack = new Stack<int>();
            Array.Fill(result, -1);

            for (int i = 0; i < len * 2; i++)
            {
                while (stack.Count!=0 && nums[stack.Peek()]<nums[i%len])
                {
                    result[stack.Pop()] = nums[i%len];
                }
                if (i<len)
                {
                    stack.Push(i);
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
