using System;

namespace PopulatingNextRightPointersInEachNode
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class Solution
    {
        public Node Connect(Node root)
        {
            var r = root;
            while (r != null)
            {
                var cur = r;
                while (cur!=null&&cur.left!=null)
                {
                    cur.left.next = cur.right;
                    cur.right.next = cur.next == null ? null : cur.next.left;
                    cur = cur.next;
                }
                r = r.left;
            }
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(-1);
            root.left = new Node(0);
            root.right = new Node(1);
            Node n0 = root.left, n1 = root.right;

            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);
            var n5 = new Node(5);


            var n6 = new Node(6);
            var n7 = new Node(7);
            var n8 = new Node(8);
            var n9 = new Node(9);
            var n10 = new Node(10);
            var n11 = new Node(11);
            var n12 = new Node(12);
            var n13 = new Node(13);
            n0.left = n2;
            n0.right = n3;
            n1.left = n4;
            n1.right = n5;

            n2.left = n6;
            n2.right = n7;
            n3.left = n8;
            n3.right = n9;

            n4.left = n10;
            n4.right = n11;
            n5.left = n12;
            n5.right = n13;
            var result = new Solution().Connect(root);

            Console.WriteLine("Hello World!");
        }
    }
}
