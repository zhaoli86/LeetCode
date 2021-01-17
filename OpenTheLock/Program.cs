using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTheLock
{
    public class Solution
    {
        public int OpenLock(string[] deadends, string target)
        {
            var visited = new HashSet<string>();
            var q = new Queue<string>();
            var dead = new HashSet<string>();
            foreach (var item in deadends)
            {
                dead.Add(item);
            }

            q.Enqueue("0000");
            visited.Add("0000");
            q.Enqueue(null);
            int depth = 0;

            while (q.Any())
            {
                var node = q.Dequeue();
                if (node==null)
                {
                    depth++;
                    if (q.Any() && q.Peek() != null)
                    {
                        q.Enqueue(null);
                    }
                }
                else if (node==target)
                {
                    return depth;
                }
                else if(!dead.Contains(node))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = -1; j <= 1; j+=2)
                        {
                            int y = ((node[i] - '0') + 10 + j) % 10;
                            var variation = node.Substring(0, i) + y.ToString() + node.Substring(i + 1);
                            if (!visited.Contains(variation))
                            {
                                q.Enqueue(variation);
                                visited.Add(variation);
                            }
                        }
                    }
                }
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" };
            var result = new Solution().OpenLock(input, "8888");

            Console.WriteLine("Hello World!");
        }
    }
}
