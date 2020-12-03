using System;
using System.Collections.Generic;

namespace ValidateStackSequence
{
    public class Solution
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            var stack = new Stack<int>();
            int i = 0;
            foreach (var num in pushed)
            {
                stack.Push(num);
                while (stack.Count!=0 && stack.Peek()==popped[i])
                {
                    stack.Pop();
                    i++;

                }
            }
            return stack.Count == 0;
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
