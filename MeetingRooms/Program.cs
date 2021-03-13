using System;

namespace MeetingRooms
{
    public class Solution
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals == null)
            {
                return false;
            }
            Array.Sort(intervals, new Comparison<int[]>((x, y) => x[0] - y[0]));

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1])
                {
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
            Console.WriteLine("Hello World!");
        }
    }
}
