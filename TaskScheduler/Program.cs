using System;

namespace TaskScheduler
{
    public class Solution
    {
        public int LeastInterval(char[] tasks, int n)
        {
            var frequencies = new int[26];
            foreach (var task in tasks)
            {
                frequencies[task - 'A']++;
            }
            Array.Sort(frequencies);

            int maxFreq = frequencies[25];
            int taskLen = tasks.Length;
            int idle = (maxFreq - 1) * n;
            for (int i = frequencies.Length-2; i >=0; i--)
            {
                idle -= Math.Min(maxFreq - 1, frequencies[i]);
            }
            return Math.Max(0, idle) + taskLen;
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
