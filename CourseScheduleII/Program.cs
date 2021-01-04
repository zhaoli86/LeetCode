using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseScheduleII
{
    public class Solution
    {
        enum State
        {
            Unvisited,
            Visited,
            Finished
        }
        private Stack<int> result = new Stack<int>();
        private Dictionary<int, List<int>> neighbors = new Dictionary<int, List<int>>();
        private Dictionary<int, State> states = new Dictionary<int, State>();

        private bool isCyclic = false;

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            foreach (var prerequisite in prerequisites)
            {
                int src = prerequisite[1];
                int des = prerequisite[0];
                if (neighbors.ContainsKey(src))
                {
                    neighbors[src].Add(des);
                }
                else
                {
                    neighbors[src] = new List<int> { des };
                }
            }
            for (int i = 0; i < numCourses; i++)
            {
                states[i] = State.Unvisited;
            }
            for (int i = 0; i < numCourses; i++)
            {
                if (states[i]==State.Unvisited)
                {
                    Dfs(i);
                }
            }

            if (isCyclic)
            {
                return new int[0]; 
            }
            return result.ToArray();
        }

        private void Dfs(int node)
        {
            if (isCyclic)
            {
                return;
            }
            states[node] = State.Visited;
            if (neighbors.ContainsKey(node))
            {
                foreach (var child in neighbors[node])
                {
                    if (states[child] == State.Visited)
                    {
                        isCyclic = true;
                        return;
                    }
                    else if (states[child] == State.Unvisited)
                    {
                        Dfs(child);
                    }
                }
            }

            states[node] = State.Finished;
            result.Push(node);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[][] { new int[] { 0, 1 } };
            var result = new Solution().FindOrder(2, input);
            
        }
    }
}
