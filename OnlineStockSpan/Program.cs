using System;
using System.Collections.Generic;

namespace OnlineStockSpan
{
    public class StockSpanner
    {       
        private class StockHolder
        {
            public int Val { get; set; }
            public int Num { get; set; }
        }

        private Stack<StockHolder> stack = new Stack<StockHolder>();

        public StockSpanner()
        {

        }

        public int Next(int price)
        {
            
            var result = 1;
            while (stack.Count!=0 && stack.Peek().Val <= price)
            {
                result += stack.Pop().Num;
            }
            stack.Push(new StockHolder { Val = price, Num = result });
            return result;
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
