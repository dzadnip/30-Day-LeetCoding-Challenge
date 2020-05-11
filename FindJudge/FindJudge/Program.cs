using System;

namespace FindJudge
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution Solution = new Solution();

            int n = 3;

            int[][] trust = new int[][]
            {
                new int[] {1,3},
                new int[] {2,3},
                new int[] {3,1}
            };

            //-1
            Console.WriteLine(Solution.FindJudge2(n, trust));
        }
    }
}
