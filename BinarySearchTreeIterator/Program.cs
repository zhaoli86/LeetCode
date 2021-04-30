using System;
using System.Collections.Generic;

namespace BinarySearchTreeIterator
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

    public class BSTIterator
    {
        private Stack<TreeNode> stack = new Stack<TreeNode>();
        public BSTIterator(TreeNode root)
        {
            PushSelfAndLeftChildren(root);
        }

        public int Next()
        {
            var node = stack.Pop();
            PushSelfAndLeftChildren(node.right);
            return node.val;
        }

        public bool HasNext()
        {
            return stack.Count != 0;
        }

        private void PushSelfAndLeftChildren(TreeNode root)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
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
