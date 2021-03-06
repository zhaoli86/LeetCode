using System;

namespace LowestCommonAncestorOfBinaryTreeII
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
        private bool pFound = false;
        private bool qFound = false;

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode node = Lca(root, p, q);
            return pFound && qFound ? node : null;
        }

        private TreeNode Lca(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }
            var left = Lca(root.left, p, q);
            var right = Lca(root.right, p, q);
            if (root == p)
            {
                pFound = true;
                return p;
            }
            if (root == q)
            {
                qFound = true;
                return q;
            }
            return left == null ? right : (right == null ? left : root);
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
