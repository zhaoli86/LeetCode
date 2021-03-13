using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MyCalendarI
{
    public class MyCalendar
    {
        private List<int[]> books = new List<int[]>();

        public bool Book(int start, int end)
        {
            foreach (var item in books)
            {
                if (Math.Max(item[0], start) < Math.Min(item[1], end))
                {
                    return false;
                }
            }
            books.Add(new int[] { start, end });
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
