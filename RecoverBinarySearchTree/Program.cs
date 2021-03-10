using System;

namespace RecoverBinarySearchTree
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
        private TreeNode first;
        private TreeNode second;
        private TreeNode prev = new TreeNode(int.MinValue);

        public void RecoverTree(TreeNode root)
        {
            Traverse(root);
            int temp = first.val;
            first.val = second.val;
            second.val = temp;
        }

        private void Traverse(TreeNode root)
        {
            if (root==null)
            {
                return;
            }
            Traverse(root.left);

            if (first==null&&prev.val>root.val)
            {
                first = prev;
            }

            if (root!=null&&prev.val>root.val)
            {
                second = root;
            }
            prev = root;

            Traverse(root.right);
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
