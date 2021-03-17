using System;
using System.Collections.Generic;

namespace RemoveInterval
{
    public class Solution
    {
        public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
        {
            var result = new List<IList<int>>();
            foreach (var interval in intervals)
            {
                if (interval[1] < toBeRemoved[0] || interval[0] > toBeRemoved[1])
                {
                    result.Add(interval);
                }
                else
                {
                    if (interval[0] < toBeRemoved[0])
                    {
                        result.Add(new int[] { interval[0], toBeRemoved[0] });
                    }

                    if (interval[1] > toBeRemoved[1])
                    {
                        result.Add(new int[] { toBeRemoved[1], interval[1] });
                    }
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
