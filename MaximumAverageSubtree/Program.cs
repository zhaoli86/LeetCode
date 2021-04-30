using System;

namespace MaximumAverageSubtree
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
        private double max = double.MinValue;
        public double MaximumAverageSubtree(TreeNode root)
        {
            Helper(root);
            return max;
        }

        private double[] Helper(TreeNode root)
        {
            double size = 1;
            double val = root.val;
            if (root.left!=null)
            {
                var leftData = Helper(root.left);
                size += leftData[0];
                val += leftData[1];
            }
            if (root.right!=null)
            {
                var rightData = Helper(root.right);
                size += rightData[0];
                val += rightData[1];
            }
            double avg = val / size;
            max = Math.Max(max, avg);
            return new double[] { size, val };
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
