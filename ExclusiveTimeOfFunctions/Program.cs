using System;
using System.Collections.Generic;

namespace ExclusiveTimeOfFunctions
{
    public class Solution
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var result = new int[n];
            int previousStart = 0;
            var stack = new Stack<int>();
            foreach (var log in logs)
            {
                var elements = log.Split(':');
                string evt = elements[1];
                int functionId = int.Parse(elements[0]);
                var time = int.Parse(elements[2]);

                if (evt=="start")
                {
                    if (stack.Count != 0)
                    {
                        result[stack.Peek()] += time - previousStart;
                    }
                    stack.Push(functionId);
                    previousStart = time;
                }
                else
                {
                    result[stack.Pop()] += time - previousStart + 1;
                    previousStart = time + 1;
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
