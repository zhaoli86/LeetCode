using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpGameIV
{
    public class Solution
    {
        public int MinJumps(int[] arr)
        {
            var q = new Queue<int>();
            var map = new Dictionary<int, List<int>>();
            int n = arr.Length;
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    map[arr[i]].Add(i);
                }
                else
                {
                    map[arr[i]] = new List<int> { i };
                }
            }
            visited[0] = true;
            q.Enqueue(0);
            int step = 0;
            while (q.Any())
            {
                for (int size = q.Count; size > 0; size--)
                {
                    var node = q.Dequeue();
                    if (node == n - 1)
                    {
                        return step;
                    }
                    var list = map[arr[node]];
                    list.Add(node - 1);
                    list.Add(node + 1);
                    foreach (var item in list)
                    {
                        if (item >= 0 && !visited[item])
                        {
                            visited[item] = true;
                            q.Enqueue(item);
                        }
                    }
                    list.Clear();
                }
                step++;
            }
            return -1;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            var input = new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 };
            //var result = new Solution().MinJumps(input);
            Console.WriteLine("Hello World!");
        }
    }
}
