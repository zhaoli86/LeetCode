using System;

namespace LowestCommonAncestorOfABinaryTreeIII
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }

    public class Solution
    {
        public Node LowestCommonAncestor(Node p, Node q)
        {
            Node a = p, b = q;
            while (a!=b)
            {
                if (a==null)
                {
                    a = q;
                }
                else
                {
                    a = a.parent;
                }
                if (b==null)
                {
                    b = p;
                }
                else
                {
                    b = b.parent;
                }
            }
            return a;
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
