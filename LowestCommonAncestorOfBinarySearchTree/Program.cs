using System;

namespace LowestCommonAncestorOfBinarySearchTree
{
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while ((root.val - p.val) * (root.val - q.val) > 0)
            {
                if (p.val > root.val)
                {
                    root = root.right;
                }
                else
                {
                    root = root.left;
                }
            }
            return root;
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
