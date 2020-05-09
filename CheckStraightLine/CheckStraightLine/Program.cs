using System;

namespace CheckStraightLine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution asdf = new Solution();

            int[][] coordinates = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
                new int[] { 6, 7 }
            };

            Console.WriteLine(asdf.CheckStraightLine(coordinates));
        }
    }
}
