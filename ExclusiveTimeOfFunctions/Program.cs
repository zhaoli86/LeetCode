using System;
using System.Collections.Generic;

namespace ExclusiveTimeOfFunctions
{
    public class Solution
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var stack = new Stack<int>();
            int prevStart = 0;

            var result = new int[n];
            foreach (var log in logs)
            {
                var logData = log.Split(':');
                if (stack.Count!=0)
                {
                    var start = int.Parse(logData[2]);
                    result[stack.Peek()] += start - prevStart;
                    prevStart = start;
                }
                if (logData[1]=="start")
                {
                    stack.Push(int.Parse(logData[0]));
                }
                else
                {
                    result[stack.Pop()]++;
                    prevStart++;
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
