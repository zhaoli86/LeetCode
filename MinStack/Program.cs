using System;
using System.Collections.Generic;

namespace MinStack
{
    public class MinStack
    {

        private class Node
        {
            public int Val { get; }
            public Node Next { get; }
            public int Min { get; }

            public Node(int val, int min)
            {
                Val = val;
                Min = min;
            }
            public Node(int val, int min, Node next) : this(val, min)
            {
                Next = next;
            }
        }

        /** initialize your data structure here. */

        private Node head;
        
        public MinStack()
        {

        }

        public void Push(int x)
        {
            if (head == null)
            {
                head = new Node(x, x);
            }
            else
            {
                head = new Node(x, Math.Min(x, head.Min), head);
            }
        }

        public void Pop()
        {
            head = head.Next;
        }

        public int Top()
        {
            return head.Val;
        }

        public int GetMin()
        {
            return head.Min;
        }
    }

    public class MinStack2
    {
        private Stack<int> stack = new Stack<int>();
        private int min = int.MaxValue;

        public MinStack2()
        {

        }
        public void Push(int x)
        {
            if (x < min)
            {
                stack.Push(min);
                min = x;
            }
            stack.Push(x);
        }

        public void Pop()
        {
            if (stack.Pop() == min)
            {
                min = stack.Pop();
            }
        }

        public int Top()
        {
            return stack.Peek();
        }
        public int GetMin()
        {
            return min;
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
