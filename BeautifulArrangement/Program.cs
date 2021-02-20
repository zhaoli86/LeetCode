using System;

namespace BeautifulArrangement
{
    public class Solution
    {
        private int count;
        public int CountArrangement(int n)
        {
            var visited = new bool[n + 1];
            Helper(n, 1, visited);
            return count;
        }

        private void Helper(int n, int pos, bool[] visited)
        {
            if (pos>n)
            {
                count++;
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    if (!visited[i] && (i%pos==0||pos%i==0))
                    {
                        visited[i] = true;
                        Helper(n, pos + 1, visited);
                        visited[i] = false;
                    }
                }
            }
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
