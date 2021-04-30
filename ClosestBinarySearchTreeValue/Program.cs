using System;

namespace ClosestBinarySearchTreeValue
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
        public int ClosestValue(TreeNode root, double target)
        {
            int result = root.val;
            while (root!=null)
            {
                if (Math.Abs(root.val - target) < Math.Abs(result - target))
                {
                    result = root.val;
                }
                if (root.val>target)
                {
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
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
