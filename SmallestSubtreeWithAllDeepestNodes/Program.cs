using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallestSubtreeWithAllDeepestNodes
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            var parents = new Dictionary<TreeNode, TreeNode>();
            var list = new List<TreeNode>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int c = q.Count;
                list.Clear();
                while (c-->0)
                {
                    var node = q.Dequeue();
                    list.Add(node);
                    if (node.left!=null)
                    {
                        parents[node.left] = node;
                        q.Enqueue(node.left);
                    }
                    if (node.right!=null)
                    {
                        parents[node.right] = node;
                        q.Enqueue(node.right);
                    }


                }
            }

            while (!SameNodes(list))
            {
                list = list.Select(i => parents[i]).ToList();
            }
            return list.First();

        }

        private bool SameNodes(List<TreeNode> nodes)
        {
            for (int i = 1; i < nodes.Count; i++)
            {
                if (nodes[i]!=nodes[i-1])
                {
                    return false;
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
