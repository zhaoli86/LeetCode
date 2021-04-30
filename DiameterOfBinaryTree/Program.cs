using System;

namespace DiameterOfBinaryTree
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
        private int max;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            MaxNodeDepth(root);
            return max;
        }

        private int MaxNodeDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftNodes = MaxNodeDepth(root.left);
            int rightNodes = MaxNodeDepth(root.right);

            max = Math.Max(max, leftNodes + rightNodes);

            return Math.Max(leftNodes, rightNodes) + 1;
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
