using System;
using System.Collections.Generic;

namespace CourseScheduleIV
{
    public class Solution
    {
        public IList<bool> CheckIfPrerequisite(int n, int[][] prerequisites, int[][] queries)
        {
            var result = new List<bool>();
            var connected = new bool[n, n];
            foreach (var prerequisite in prerequisites)
            {
                connected[prerequisite[0], prerequisite[1]] = true;
            }

            for (int k = 0; k < n; k++) 
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        connected[i, j] = connected[i, j] || connected[i, k] && connected[k, j];
                    }
                }
            }

            foreach (var query in queries)
            {
                result.Add(connected[query[0], query[1]]);
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[][] { new int[] {1,2  }, new int[] { 0, 1 } };
            var query = new int[][] { new int[] { 0, 2 }, new int[] { 2, 1 } };
            var result = new Solution().CheckIfPrerequisite(3, input, query);
            Console.WriteLine("Hello World!");
            

        }
    }
}
