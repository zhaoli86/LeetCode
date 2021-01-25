using System;
using System.Collections.Generic;
using Utility;

namespace TrappingRainWaterII
{
    public class Solution
    {
        private class Cell
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Height { get; set; }
            public Cell(int row, int column, int height)
            {
                Row = row;
                Column = column;
                Height = height;
            }
        }


        public int TrapRainWater(int[][] heightMap)
        {
            if (heightMap == null || heightMap.Length == 0 || heightMap[0].Length == 0)
            {
                return 0;
            }

            var visited = new bool[heightMap.Length, heightMap[0].Length];
            var q = new PriorityQueue<Cell, int>(cell => cell.Height);

            int rowCount = heightMap.Length;
            int columnCount = heightMap[0].Length;
            for (int i = 0; i < rowCount; i++)
            {
                visited[i, 0] = true;
                visited[i, columnCount - 1] = true;
                q.Enqueue(new Cell(i, 0, heightMap[i][0]));
                q.Enqueue(new Cell(i, columnCount - 1, heightMap[i][columnCount - 1]));
            }

            for (int i = 0; i < columnCount; i++)
            {
                visited[0, i] = true;
                visited[rowCount - 1, i] = true;
                q.Enqueue(new Cell(0, i, heightMap[0][i]));
                q.Enqueue(new Cell(rowCount - 1, i, heightMap[rowCount - 1][i]));
            }

            var dirs = new int[4][] { new int[] {-1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[]{0, 1} };

            int result = 0;
            while (q.Any())
            {
                var cell = q.Dequeue();
                foreach (var dir in dirs)
                {
                    int row = cell.Row + dir[0];
                    int column = cell.Column + dir[1];
                    if (row >= 0 && row < rowCount && column >= 0 && column < columnCount && !visited[row, column])
                    {
                        visited[row, column] = true;
                        if (cell.Height > heightMap[row][column])
                        {
                            result += cell.Height - heightMap[row][column];
                        }
                        q.Enqueue(new Cell(row, column, Math.Max(heightMap[row][column], cell.Height)));
                    }
                }
            }
            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[3][] { new int[] { 1, 4, 3, 1, 3, 2 }, new int[] { 3, 2, 1, 3, 2, 4 }, new int[] { 2, 3, 3, 2, 3, 1 } };
            var result = new Solution().TrapRainWater(input);
            Console.WriteLine("Hello World!");
        }
    }
}
