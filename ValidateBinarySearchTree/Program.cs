using System;

namespace ValidateBinarySearchTree
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
        public bool IsValidBST(TreeNode root)
        {
            return Helper(root, long.MaxValue, long.MinValue);
        }

        private bool Helper(TreeNode root, long max, long min)
        {
            if (root==null)
            {
                return true;
            }
            if (root.val>=max||root.val<=min)
            {
                return false;
            }
            return Helper(root.left, root.val, min) && Helper(root.right, max, root.val);
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
