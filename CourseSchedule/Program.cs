using System;
using System.Collections.Generic;

namespace CourseSchedule
{
    public class Solution
    {
        class Node
        {
            public int InDegree { get; set; }
            public List<int> ChildrenNodes { get; set; } = new List<int>();
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var nodes = new Dictionary<int, Node>();
            foreach (var item in prerequisites)
            {
                var prev = GetOrCreateNode(item[1], nodes);
                var next = GetOrCreateNode(item[0], nodes);
                prev.ChildrenNodes.Add(item[0]);
                next.InDegree++;
            }
            var originNodes = new Queue<int>();
            foreach (var item in nodes)
            {
                if (item.Value.InDegree==0)
                {
                    originNodes.Enqueue(item.Key);
                }
            }

            int edges = 0;
            while (originNodes.Count > 0)
            {
                var node = originNodes.Dequeue();
                foreach (var childNum in nodes[node].ChildrenNodes)
                {
                    var childNode = nodes[childNum];
                    childNode.InDegree--;
                    edges++;
                    if (childNode.InDegree==0)
                    {
                        originNodes.Enqueue(childNum);
                    }
                }
            }

            if (edges==prerequisites.Length)
            {
                return true;
            }


            return false;
        }

        private Node GetOrCreateNode(int num, Dictionary<int, Node> map)
        {
            if (map.ContainsKey(num))
            {
                return map[num];
            }
            else
            {
                var node = new Node();
                map[num] = node;
                return node;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[][] { new int[] { 1, 0 } };
            var result = new Solution().CanFinish(2, input);

            Console.WriteLine("Hello World!");
        }
    }
}
