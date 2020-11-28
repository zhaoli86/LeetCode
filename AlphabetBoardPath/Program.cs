using System;
using System.Linq;
using System.Text;

namespace AlphabetBoardPath
{
    public class Solution
    {
        public string AlphabetBoardPath(string target)
        {
            var ca = target.ToCharArray();
            var sb = new StringBuilder();
            int x = 0, y = 0;
            foreach (var c in ca)
            {
                int x1 = (c - 'a') % 5;
                int y1 = (c - 'a') / 5;

                int changeX = x1 - x;
                int changeY = y1 - y;

                if (changeY < 0)
                {
                    sb.Append(Enumerable.Repeat('U', -changeY).ToArray());

                }
                if (changeX < 0)
                {
                    sb.Append(Enumerable.Repeat('L', -changeX).ToArray());
                }
                if (changeY > 0)
                {
                    sb.Append(Enumerable.Repeat('D', changeY).ToArray());
                }


                if (changeX > 0)
                {
                    sb.Append(Enumerable.Repeat('R', changeX).ToArray());
                }


                sb.Append("!");

                x = x1;
                y = y1;
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            string input = "zdz";
            var result = s.AlphabetBoardPath(input);
            Console.WriteLine("Hello World!");
        }
    }
}
