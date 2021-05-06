using System;

namespace LargestBSTSubtree
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
        public int LargestBSTSubtree(TreeNode root)
        {
            var result = Helper(root);
            return result[2];
        }
        private int[] Helper(TreeNode root)
        {
            if (root == null)
            {
                return new int[] { int.MaxValue, int.MinValue, 0 };
            }
            var leftInfo = Helper(root.left);
            var rightInfo = Helper(root.right);
            if (root.val>leftInfo[1]&&root.val<rightInfo[0])
            {
                return new int[] { Math.Min(leftInfo[0], root.val), Math.Max(rightInfo[1], root.val), leftInfo[2] + rightInfo[2] + 1 };
            }
            else
            {
                return new int[] { int.MinValue, int.MaxValue, Math.Max(leftInfo[2], rightInfo[2]) };
            }
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
