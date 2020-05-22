using System;

namespace CountSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[][]
            {
                new int[] {0,1,1,1},
                new int[] {1,1,1,1},
                new int[] {0,1,1,1}
            };
            // expected 15
            Console.WriteLine(CountSquares(matrix));
            Console.WriteLine(CountSquares3(matrix));

            matrix = new int[][]
            {
                new int[] {1,0,1},
                new int[] {1,1,0},
                new int[] {1,1,0}
            };
            //expected 7
            Console.WriteLine(CountSquares4(matrix));

            // CountSquares2 changes the matrix
            Console.WriteLine(CountSquares2(matrix));
        }

        // Copied from discussion area
        public static int CountSquares(int[][] matrix)
        {
            int[,] d = new int[matrix.Length, matrix[0].Length];
            int count = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        d[i, j] = matrix[i][j];
                    }

                    else if (matrix[i][j] == 0)
                    {
                        d[i, j] = 0;
                    }

                    else
                    {
                        d[i, j] = 1 + Math.Min(d[i - 1, j], Math.Min(d[i - 1, j - 1], d[i, j - 1]));
                    }

                    count += d[i, j];
                }
            }

            return count;
        }

        // Runtime distribution
        public static int CountSquares2(int[][] matrix)
        {
            int total = 0;
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 0)
                        continue;
                    if (i == 0 || j == 0)
                    {
                        total += matrix[i][j];
                        continue;
                    }
                    int min = Math.Min(matrix[i - 1][j], Math.Min(matrix[i][j - 1], matrix[i - 1][j - 1]));
                    matrix[i][j] += min;
                    total += matrix[i][j];
                }
            }
            return total;
        }

        public static int CountSquares3(int[][] matrix)
        {
            var sum = 0;
            for (var i = 1; i < matrix.Length; i++)
            {
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    var min1 = Math.Min(matrix[i][j - 1], matrix[i - 1][j - 1]);
                    var min2 = Math.Min(matrix[i - 1][j], matrix[i - 1][j - 1]);
                    matrix[i][j] = matrix[i][j] * (1 + Math.Min(min1, min2));
                    sum = sum + matrix[i][j];
                }
            }
            foreach (var v in matrix[0])
            {
                sum = sum + v;
            }
            for (var j = 0; j < matrix.Length; j++)
            {
                sum = sum + matrix[j][0];
            }
            return sum - matrix[0][0];
        }

        public static int CountSquares4(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return 0;
            }

            int m = matrix.Length;
            int n = matrix[0].Length;

            int count = 0;
            int[] dp = new int[n + 1];

            int tmp = 0;

            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    if (matrix[i - 1][j - 1] == 1)
                    {
                        int curMin = Math.Min(Math.Min(dp[j - 1], dp[j]), tmp) + 1;
                        tmp = dp[j];
                        count += (dp[j] = curMin);
                    }
                    else
                    {
                        dp[j] = tmp = 0;
                    }
                }
            }

            return count;
        }
    }
}
