using System;
using System.Collections.Generic;

namespace _132Pattern
{
    public class Solution
    {
        public bool Find132pattern(int[] nums)
        {
            int s3 = int.MinValue;
            var stack = new Stack<int>();
            for (int i = nums.Length-1; i >=0; i--)
            {
                if (nums[i]<s3)
                {
                    return true;
                }

                while (stack.Count!=0 && nums[i]>stack.Peek())
                {
                    s3 = stack.Peek();
                    stack.Pop();
                }

                stack.Push(nums[i]);
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
