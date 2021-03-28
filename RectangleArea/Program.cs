using System;

namespace RectangleArea
{
    public class Solution
    {
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            int area1 = (C - A) * (D - B);
            int area2 = (G - E) * (H - F);
            int area3 = 0;
            int left = Math.Max(A, E);
            int right = Math.Min(C, G);
            int top = Math.Min(D, H);
            int bottom = Math.Max(B, F);
            int x = right - left;
            int y = top - bottom;
            if (x > 0 && y > 0)
            {
                area3 = x * y;
            }
            return area1 + area2 - area3;
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
