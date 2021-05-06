using System;

namespace IntersectionOfTwoLinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode curA = headA, curB = headB;
            while (true)
            {
                if (curA==curB)
                {
                    return curA;
                }
                curA = curA == null ? headB : curA.next;
                curB = curB == null ? headA : curB.next;
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
