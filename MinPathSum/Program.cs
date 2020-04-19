using System;

namespace MinPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 3, 1 };
            jaggedArray[1] = new int[] { 1, 5, 1 };
            jaggedArray[2] = new int[] { 4, 2, 1 };

            Console.WriteLine(MinPathSum(jaggedArray));

            jaggedArray[0] = new int[] { 9, 7, 5, 2 };
            jaggedArray[1] = new int[] { 5, 5, 5, 3 };
            jaggedArray[2] = new int[] { 8, 2, 4, 5 };

            Console.WriteLine(MinPathSum(jaggedArray));
        }

        // Copied solution from discussion area
        static int MinPathSum(int[][] grid)
        {
            //DisplayGrid(grid);

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (i == 0 && j == 0) continue;

                    grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);

                    //DisplayGrid(grid);
                }
            }

            return grid[grid.Length - 1][grid[0].Length - 1];
        }

        static void DisplayGrid(int[][] grid)
        {
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    Console.Write($"{grid[i][j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
