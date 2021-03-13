using System;

namespace MeetingRoomsII
{
    public class Solution
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            int len = intervals.Length;
            var starts = new int[len];
            var ends = new int[len];
            for (int i = 0; i < len; i++)
            {
                starts[i] = intervals[i][0];
                ends[i] = intervals[i][1];
            }
            Array.Sort(starts);
            Array.Sort(ends);
            int lastEnd = 0, rooms = 0;
            for (int i = 0; i < len; i++)
            {
                if(starts[i]<ends[lastEnd])
                {
                    rooms++;
                }
                else
                {
                    lastEnd++;
                }
            }
            return rooms;
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
