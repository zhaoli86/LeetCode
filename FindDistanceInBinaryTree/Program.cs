using System;

namespace FindDistanceInBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public int FindDistance(TreeNode root, int p, int q)
        {
            TreeNode lca = Lca(root, p, q);
            return Dist(lca, p, 0) + Dist(lca, q, 0);
        }

        private int Dist(TreeNode root, int target, int distance)
        {
            if (root==null)
            {
                return -1;
            }
            if (root.val==target)
            {
                return distance;
            }
            int distanceLeft = Dist(root.left, target, distance + 1);
            if (distanceLeft==-1)
            {
                distanceLeft = Dist(root.right, target, distance + 1);
            }
            return distanceLeft;
        }

        private TreeNode Lca(TreeNode root, int p, int q)
        {
            if (root==null)
            {
                return null;
            }
            var left = Lca(root.left, p, q);
            var right = Lca(root.right, p, q);
            if (root.val==p||root.val==q|| (left!=null && right!=null))
            {
                return root;
            }
            return left != null ? left : right;
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
