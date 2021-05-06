using System;
using System.Collections.Generic;

namespace PalindromeLinkedList
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
        public bool IsPalindrome(ListNode head)
        {
            var list = new List<int>();
            while (head!=null)
            {
                list.Add(head.val);
                head = head.next;
            }
            int i = 0, j = list.Count - 1;
            while (i<j)
            {
                if (list[i]!=list[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
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
