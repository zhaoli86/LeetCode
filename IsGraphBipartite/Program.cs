using System;
using System.Collections.Generic;
using System.Linq;

namespace IsGraphBipartite
{
    public class Solution
    {
        public bool IsBipartite(int[][] graph)
        {
            var n = graph.Length;

            var color = new int[n];
            Array.Fill(color, -1);

            for (int i = 0; i < n; i++)
            {
                if (color[i]==-1)
                {
                    var stack = new Stack<int>();
                    stack.Push(i);
                    color[i] = 0;
                    while (stack.Any())
                    {
                        var node = stack.Pop();
                        foreach (var item in graph[node])
                        {
                            if (color[item]==-1)
                            {
                                color[item] = color[node] ^ 1;
                                stack.Push(item);
                            }
                            else if (color[item]==color[node])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
