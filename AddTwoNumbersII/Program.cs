using System;
using System.Collections.Generic;

namespace AddTwoNumbersII
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var s1 = new Stack<int>();
            var s2 = new Stack<int>();
            var s3 = new Stack<int>();
            while (l1!=null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }
            while (l2!=null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }
            var head = new ListNode();
            ListNode cur = head;
            int carry = 0;
            while (s1.Count!=0||s2.Count!=0)
            {
                int num = (s1.Count == 0 ? 0 : s1.Pop()) + (s2.Count == 0 ? 0 : s2.Pop()) + carry;
                int val = num % 10;
                carry = num / 10;

                s3.Push(val);


            }
            if (carry>0)
            {
                s3.Push(carry);
            }

            while (s3.Count!=0)
            {
                cur.next = new ListNode(s3.Pop());
                cur = cur.next;
            }
            return head.next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(7, new ListNode(2, new ListNode(4, new ListNode(3))));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            var r = new Solution().AddTwoNumbers(l1, l2);
            Console.WriteLine("Hello World!");
        }
    }
}
