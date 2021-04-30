using System;

namespace AddTwoNumbers
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
            ListNode newHead = new ListNode();
            ListNode cur = newHead;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int v1 = l1 == null ? 0 : l1.val;
                int v2 = l2 == null ? 0 : l2.val;
                int sum = v1 + v2 + carry;
                int val = sum % 10;
                carry = sum / 10;
                cur.next = new ListNode(val);
                cur = cur.next;
                if (l1!=null)
                {
                    l1 = l1.next;
                }
                if (l2!=null)
                {
                    l2 = l2.next;
                }
                
            }
            if (carry!=0)
            {
                cur.next = new ListNode(carry);
            }

            return newHead.next;
        }

        //private ListNode Reverse(ListNode node)
        //{
        //    ListNode cur = node, prev = null;
        //    while (cur!=null)
        //    {
        //        var next = cur.next;
        //        cur.next = prev;
        //        prev = cur;
        //        cur = next;
        //    }
        //    return prev;
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
