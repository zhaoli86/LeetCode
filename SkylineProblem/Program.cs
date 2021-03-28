using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Utility;

namespace SkylineProblem
{
    //going from left to right of the building's starting and ending points, whenever we see a start 
    //push it to a priorityQueue, if the max of PQ changes, it means that this building at this starting
    //point must be taller than all the other buildings that are overlapping at the point, so the point needs
    //to be part of the final answer. 
    //whenever we encounter the end of a building, we need to remove that building from the PQ. If in doing so
    //the max of the PQ changes, it means that that point needs to be part of final answer. 

    public class Solution
    {
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            var result = new List<IList<int>>();
            var height = new List<int[]>();
            foreach (var building in buildings)
            {
                height.Add(new int[] { building[0], -building[2] });
                height.Add(new int[] { building[1], building[2] });
            }
            height = height.OrderBy(a => a[0]).ThenBy(b => b[1]).ToList();

            var pq = new PriorityQueue<int>((a, b) => (b - a), buildings.Length+1);


            pq.Insert(0);
            int prevMax = 0;
            foreach (var h in height)
            {
                if (h[1]<0)
                {
                    pq.Insert(-h[1]);
                }
                else
                {
                    pq.Remove(h[1]);
                }
                int curMax = pq.Top();
                if (prevMax!=curMax)
                {
                    result.Add(new List<int> { h[0], curMax });
                    prevMax = curMax;
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
