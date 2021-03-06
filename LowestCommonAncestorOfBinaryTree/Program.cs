using System;

namespace LowestCommonAncestorOfBinaryTree
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
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root==null||root==p||root==q)
            {
                return root;
            }
            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (left==null)
            {
                return right;
            }
            else if (right==null)
            {
                return left;
            }
            else
            {
                return root;
            }
        }
    }


    public class Solution2
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root==null)
            {
                return null;
            }
            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if (root==p)
            {
                return p;
            }
            if (root==q)
            {
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
