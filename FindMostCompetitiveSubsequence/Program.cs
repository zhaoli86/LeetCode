using System;
using System.Collections.Generic;

namespace FindMostCompetitiveSubsequence
{
    public class Solution
    {
        public int[] MostCompetitive(int[] nums, int k)
        {
            var result = new int[k];
            var stack = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count!=0 && nums[i] < nums[stack.Peek()] && nums.Length - i + stack.Count > k)
                {
                    stack.Pop();
                }
                if (stack.Count < k)
                {
                    stack.Push(i);
                }
            }

            for (int i = k - 1; i >= 0; i--)
            {
                result[i] = nums[stack.Pop()];
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
