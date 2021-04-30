using System;
using System.Collections.Generic;
using System.Linq;

namespace AllNodesDistanceKInBinaryTree
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
        private Dictionary<TreeNode, TreeNode> parents = new Dictionary<TreeNode, TreeNode>();

        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            var q = new Queue<TreeNode>();
            var visited = new HashSet<TreeNode>();
            visited.Add(null);
            
            Dfs(root, null);
            q.Enqueue(target);
            visited.Add(target);
            while (q.Count!=0)
            {
                if (K == 0)
                {
                    return q.Select(i => i.val).ToList();
                }
                int count = q.Count;
                while (count-->0)
                {
                    var node = q.Dequeue();
                    var parentNode = parents[node];
                    if (parentNode!=null&&visited.Add(parentNode))
                    {
                        q.Enqueue(parentNode);
                    }

                    var leftNode = node.left;
                    if (visited.Add(leftNode))
                    {
                        q.Enqueue(leftNode);
                    }

                    var rightNode = node.right;
                    if (visited.Add(rightNode))
                    {
                        q.Enqueue(rightNode);
                    }
                }
                K--;

            }
            return new List<int>();
        }

        private void Dfs(TreeNode node, TreeNode parent)
        {
            if (node==null)
            {
                return;
            }
            parents[node] = parent;
            Dfs(node.left, node);
            Dfs(node.right, node);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3);
            var l1 = new TreeNode(5);
            var r1 = new TreeNode(1);
            var l21 = new TreeNode(6);
            var l22 = new TreeNode(2);
            var l23 = new TreeNode(0);
            var l24 = new TreeNode(8);
            var l31 = new TreeNode(7);
            var l32 = new TreeNode(4);
            l22.left = l31;
            l22.right = l32;
            l1.left = l21;
            l1.right = l22;
            r1.left = l23;
            r1.right = l24;
            root.left = l1;
            root.right = r1;
            var result = new Solution().DistanceK(root, l1, 2);
            Console.WriteLine("Hello World!");
        }
    }
}
