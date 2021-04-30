using System;
using System.Collections.Generic;

namespace ConstructBinaryTreeFromString
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
        public TreeNode Str2tree(string s)
        {
            var stack = new Stack<TreeNode>();
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                if (ch == ')')
                {
                    stack.Pop();
                }
                else if (ch >= '0' && ch <= '9' || ch == '-')
                {
                    int j = i;
                    while (i+1<s.Length&& s[i + 1] >= '0' && s[i + 1] <= '9')
                    {
                        i++;
                    }
                    var subs = s.Substring(j, i - j + 1);
                    var child = new TreeNode(int.Parse(subs));
                    if (stack.Count != 0)
                    {
                        var parent = stack.Peek();
                        if (parent.left != null)
                        {
                            parent.right = child;
                        }
                        else
                        {
                            parent.left = child;
                        }
                    }
                    stack.Push(child);
                }
            }
            return stack.Count == 0 ? null : stack.Peek();
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
