using System;

namespace NumIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] jaggedArray = new char[4][];

            jaggedArray[0] = new char[] { '1', '1', '1', '1', '0' };
            jaggedArray[1] = new char[] { '1', '1', '0', '1', '0' };
            jaggedArray[2] = new char[] { '1', '1', '0', '0', '0' };
            jaggedArray[3] = new char[] { '0', '0', '0', '0', '0' };

            Console.WriteLine($"Number of islands is {NumIslands2(jaggedArray)}");

            jaggedArray[0] = new char[] { '1', '1', '0', '0', '0' };
            jaggedArray[1] = new char[] { '1', '1', '0', '0', '0' };
            jaggedArray[2] = new char[] { '0', '0', '1', '0', '0' };
            jaggedArray[3] = new char[] { '0', '0', '0', '1', '1' };

            Console.WriteLine($"Number of islands is {NumIslands2(jaggedArray)}");
        }

        // This is the same question I had for the Amazon assesment test - that I failed.
        // Based on discussion area, this is what I submitted today
        public int NumIslands(char[][] grid)
        {
            var count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        //count as island
                        count++;

                        //sink it, and everything around so they are not counted as islands
                        UpdateGrid(i, j, grid);
                    }
                }
            }

            return count;
        }

        public void UpdateGrid(int i, int j, char[][] grid)
        {
            //if not an island, or outside grid, exit
            if (
                i < 0 ||
                j < 0 ||
                i == grid.Length ||
                j == grid[0].Length ||
                grid[i][j] == '0'
               ) return;

            //sink the island
            grid[i][j] = '0';

            //and everything touching it from 
            UpdateGrid(i - 1, j, grid); //top
            UpdateGrid(i + 1, j, grid); //bottom
            UpdateGrid(i, j - 1, grid); //left
            UpdateGrid(i, j + 1, grid); //right
        }



        // Runtime distribution

        int[][] dirs = new int[4][] {
            new int[2]{0,1},
            new int[2]{0,-1},
            new int[2]{1,0},
            new int[2]{-1,0}
        };

        public int NumIslands1(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        dfs(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        private void dfs(char[][] grid, int i, int j)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (i < 0 || j < 0 || i >= m || j >= n || grid[i][j] == '0')
                return;

            grid[i][j] = '0';
            for (int k = 0; k < 4; k++)
            {
                int innerRow = i + dirs[k][0];
                int innerCol = j + dirs[k][1];
                dfs(grid, innerRow, innerCol);
            }
        }




        private static int RowLen { get; set; }
        private static int ColLen { get; set; }

        static int NumIslands2(char[][] grid)
        {
            if (grid.Length == 0)
                return 0;

            RowLen = grid.Length;
            ColLen = grid[0].Length;

            int islandCount = 0;
            for (int rowIndex = 0; rowIndex < RowLen; rowIndex++)
            {
                for (int colIndex = 0; colIndex < ColLen; colIndex++)
                {
                    char currentSpotValue = grid[rowIndex][colIndex];
                    // at each coordinate, check if its an island ('1')
                    if (IsIsland(currentSpotValue))
                    {
                        islandCount++;
                        MarkLandAsVisited(grid, rowIndex, colIndex);
                    }
                }
            }

            return islandCount;
        }

        static bool IsIsland(char currentSpot)
        {
            return currentSpot == '1';
        }

        static void MarkLandAsVisited(char[][] grid, int rowIndex, int colIndex)
        {
            // check out of bounds --> do nothing, stop
            if (rowIndex >= RowLen ||
                colIndex >= ColLen ||
                rowIndex < 0 ||
                colIndex < 0)
                return;

            if (grid[rowIndex][colIndex] != '1')
                return;

            grid[rowIndex][colIndex] = 'X';

            // do the same for every up down left right until hit zeros
            MarkLandAsVisited(grid, rowIndex - 1, colIndex); // up
            MarkLandAsVisited(grid, rowIndex + 1, colIndex); // down
            MarkLandAsVisited(grid, rowIndex, colIndex - 1); // left
            MarkLandAsVisited(grid, rowIndex, colIndex + 1); // right
        }





    }
}
