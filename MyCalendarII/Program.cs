using System;
using System.Collections.Generic;

namespace MyCalendarII
{
    public class MyCalendarTwo
    {
        private SortedDictionary<int, int> map = new SortedDictionary<int, int>();


        public bool Book(int start, int end)
        {
            if (map.ContainsKey(start))
            {
                map[start]++;
            }
            else
            {
                map[start] = 1;
            }

            if (map.ContainsKey(end))
            {
                map[end]--;
            }
            else
            {
                map[end] = -1;
            }
            int count = 0;
            foreach (var kvp in map)
            {
                count += kvp.Value;
                if (count>2)
                {
                    map[start]--;
                    map[end]++;
                    return false;
                }
            }
            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            map[3] = 4;
            map[1] = 2;
            map[2] = 3;
            foreach (var kvp in map)
            {
                Console.WriteLine(kvp.Key);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
