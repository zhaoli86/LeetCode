using System;

namespace InsertIntoSortedCircularLinkedList
{
    public class Node
    {
        public int val;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            next = null;
        }

        public Node(int _val, Node _next)
        {
            val = _val;
            next = _next;
        }
    }

    public class Solution
    {
        public Node Insert(Node head, int insertVal)
        {
            if (head==null)
            {
                var n = new Node(insertVal);
                n.next = n;
                return n;
            }

            Node prev = head, cur = head.next;
            bool found = false;
            do
            {
                if (insertVal<=cur.val&&insertVal>=prev.val || (prev.val>cur.val && (insertVal<=cur.val || insertVal>=prev.val)))
                {
                    prev.next = new Node(insertVal, cur);
                    found = true;
                    break;
                }
                prev = cur;
                cur = cur.next;
            } while (prev!=head);

            if (!found)
            {
                prev.next = new Node(insertVal, cur);
            }
            return head;
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
