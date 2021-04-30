using System;
using System.Collections.Generic;

namespace BalanceBinarySearchTree
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
        private List<TreeNode> nodes = new List<TreeNode>();
        public TreeNode BalanceBST(TreeNode root)
        {
            Inorder(root);
            return ArrayToBst(0, nodes.Count - 1);
        }

        private TreeNode ArrayToBst(int start, int end)
        {
            if (start>end)
            {
                return null;
            }
            int mid = start + (end - start) / 2;
            var root = nodes[mid];
            root.left = ArrayToBst(start, mid - 1);
            root.right = ArrayToBst(mid + 1, end);
            return root;
        }

        private void Inorder(TreeNode root)
        {
            if (root==null)
            {
                return;
            }
            Inorder(root.left);
            nodes.Add(root);
            Inorder(root.right);
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
