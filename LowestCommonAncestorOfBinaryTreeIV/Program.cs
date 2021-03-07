using System;
using System.Collections.Generic;

namespace LowestCommonAncestorOfBinaryTreeIV
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
        private TreeNode lca;
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes)
        {
            var vals = new HashSet<int>();
            foreach (var node in nodes)
            {
                vals.Add(node.val);
            }
            Helper(root, vals);
            return lca;
        }

        private int Helper(TreeNode root, HashSet<int> vals)
        {
            if (root==null)
            {
                return 0;
            }
            int leftFound = Helper(root.left, vals);
            int rightFound = Helper(root.right, vals);
            int foundCount = leftFound + rightFound;
            if (vals.Contains(root.val))
            {
                foundCount++;
            }
            if (lca==null&&foundCount==vals.Count)
            {
                lca = root;
            }
            return foundCount;
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
