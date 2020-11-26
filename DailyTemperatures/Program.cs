using System;
using System.Collections;
using System.Collections.Generic;

namespace DailyTemperatures
{
    public class Solution
    {
        public int[] DailyTemperatures(int[] T)
        {
            var stack = new Stack<int>();
            var result = new int[T.Length];
            for (int i = 0; i < T.Length; i++)
            {
                while (stack.Count!=0 &&  T[stack.Peek()] < T[i])
                {
                    var idx = stack.Pop();
                    result[idx] = i - idx;
                }
                stack.Push(i);
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
