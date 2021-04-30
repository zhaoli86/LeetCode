using System;
using System.Collections.Generic;

namespace FindLargestValueInEachTreeRow
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
        public IList<int> LargestValues(TreeNode root)
        {
            var result = new List<int>();
            if (root==null)
            {
                return result;
            }

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count!=0)
            {
                int c = q.Count;
                int max = int.MinValue;
                while (c-->0)
                {
                    var node = q.Dequeue();
                    max = Math.Max(max, node.val);
                    if (node.left!=null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right!=null)
                    {
                        q.Enqueue(node.right);
                    }
                }
                result.Add(max);
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
