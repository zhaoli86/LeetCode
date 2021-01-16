using System;
using System.Collections.Generic;

namespace CheapestFlightsWithinKStops
{
    public class Solution
    {
        private struct Key
        {
            public int Src { get; set; }
            public int Stops { get; set; }

        }
        private Dictionary<Key, long> map = new Dictionary<Key, long>();

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var adjMatrix = new int[n][];
            for (int i = 0; i < adjMatrix.Length; i++)
            {
                adjMatrix[i] = new int[n];
            }
            foreach (var flight in flights)
            {
                adjMatrix[flight[0]][flight[1]] = flight[2];
            }

            long result = GetShortest(adjMatrix, src, dst, K, n);

            if (result >= int.MaxValue)
            {
                return -1;
            }
            return (int)result;
        }

        private long GetShortest(int[][] adjMatrix, int src, int dst, int stops, int n)
        {

            if (src==dst)
            {
                return 0;
            }

            if (stops < 0)
            {
                return int.MaxValue;
            }

            var key = new Key { Src = src, Stops = stops };
            if (map.ContainsKey(key))
            {
                return (int)map[key];
            }
            long result = int.MaxValue;

            for (int neighbor = 0; neighbor < n; neighbor++)
            {
                int weight = adjMatrix[src][neighbor];
                if (weight>0)
                {
                    result = Math.Min(result, GetShortest(adjMatrix, neighbor, dst, stops - 1, n)+weight);
                }
            }
            map[key] = result;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[3][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0, 2, 500 } };
            var result = new Solution().FindCheapestPrice(3, input, 0, 2, 0);
            Console.WriteLine("Hello World!");
        }
    }
}
