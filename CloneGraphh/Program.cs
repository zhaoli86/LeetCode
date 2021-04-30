using System;
using System.Collections.Generic;

namespace CloneGraphh
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution
    {
        private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
        public Node CloneGraph(Node node)
        {
            if (node==null)
            {
                return null;
            }

            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            var newNode = new Node(node.val);
            visited[node] = newNode;

            foreach (var neighbor in node.neighbors)
            {
                newNode.neighbors.Add(CloneGraph(neighbor));
            }
            return newNode;
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
