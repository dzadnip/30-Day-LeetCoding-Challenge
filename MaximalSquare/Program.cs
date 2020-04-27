using System;

namespace MaximalSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = new char[][]
                {
                    new char[] { '1', '0', '1', '0', '0' },
                    new char[] { '1', '0', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '0', '0', '1', '0' }
                };
            // 4
            Console.WriteLine(MaximalSquare(matrix));


            matrix = new char[][]
                {
                    new char[] { '0', '0', '0', '0', '0' },
                    new char[] { '0', '0', '0', '0', '0' },
                    new char[] { '0', '0', '0', '0', '0' },
                    new char[] { '0', '0', '0', '0', '0' }
                };
            // 0
            Console.WriteLine(MaximalSquare(matrix));


            matrix = new char[][]
                {
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' }
                };
            // 16
            Console.WriteLine(MaximalSquare(matrix));

            matrix = new char[][]
                {
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' },
                    new char[] { '1', '1', '1', '1', '1' }
                };
            // 25
            Console.WriteLine(MaximalSquare(matrix));


            matrix = new char[][]
                {
                    new char[] { '0', '1', '1', '1', '1' },
                    new char[] { '1', '0', '1', '1', '1' },
                    new char[] { '1', '1', '0', '1', '1' },
                    new char[] { '1', '1', '1', '0', '1' },
                    new char[] { '1', '1', '1', '1', '0' }
                };
            // 4
            Console.WriteLine(MaximalSquare(matrix));


            matrix = new char[][]
                {
                    new char[] { '0', '1', '1', '1', '0' },
                    new char[] { '1', '0', '1', '0', '1' },
                    new char[] { '1', '1', '0', '1', '1' },
                    new char[] { '1', '0', '1', '0', '1' },
                    new char[] { '0', '1', '1', '1', '0' }
                };
            // 1
            Console.WriteLine(MaximalSquare(matrix));


            matrix = new char[][]
                {
                    new char[] { '1', '1', '1', '1', '0' },
                    new char[] { '1', '1', '1', '0', '1' },
                    new char[] { '1', '1', '0', '1', '1' },
                    new char[] { '1', '0', '1', '1', '1' },
                    new char[] { '0', '1', '1', '1', '1' }
                };
            // 4
            Console.WriteLine(MaximalSquare(matrix));
        }

        // Given a 2D binary matrix filled with 0's and 1's, find the largest square containing only 1's and return its area.

        // Here's an in place solution from discussion area
        public static int MaximalSquare(char[][] matrix)
        {
            bool onlyZeroes = true;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        onlyZeroes = false;
                        break;
                    }
                }
                if (!onlyZeroes) break;
            }
            if (onlyZeroes) return 0;

            bool squaresFound = true;
            int size = 1;
            while (squaresFound)
            {
                squaresFound = false;
                for (int i = 1; i <= matrix.Length - size; i++)
                {
                    for (int j = 1; j <= matrix[i].Length - size; j++)
                    {
                        if (matrix[i][j] != '1' || matrix[i - 1][j] != '1' || matrix[i][j - 1] != '1')
                        {
                            matrix[i - 1][j - 1] = '0';
                        }
                        else if (matrix[i - 1][j - 1] == '1')
                        {
                            squaresFound = true;
                        }
                    }
                }
                if (squaresFound) size++;
            }
            return size * size;
        }


        //Not sure I fully understand yet how this Dynamic Programming solution works
        public static int MaximalSquare2(char[][] matrix)
        {

            if (matrix.Length == 0 || matrix[0].Length == 0) return 0;
            int[][] dp = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i] = new int[matrix[i].Length];
            }
            int max = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp[i].Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        if (matrix[i][j] == '1') dp[i][j] = 1;
                    }
                    else
                    {
                        if (matrix[i][j] == '1')
                        {
                            dp[i][j] = Math.Min(dp[i][j - 1], Math.Min(dp[i - 1][j], dp[i - 1][j - 1])) + 1;
                        }
                    }
                    max = Math.Max(dp[i][j], max);
                }
            }
            return max * max;
        }


        public static int MaximalSquare3(char[][] matrix)
        {
            int max = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        int square = getSquare(matrix, i, j);
                        if (max < square)
                            max = square;
                    }
                }
            }

            return max;
        }

        public static int getSquare(char[][] matrix, int i, int j)
        {
            int size = 1;
            while (i + size < matrix.Length && j + size < matrix[0].Length && matrix[i + size][j + size] == '1')
            {
                for (int x = 1; x <= size; x++)
                {
                    if (matrix[i + size][j + size - x] != '1' || matrix[i + size - x][j + size] != '1')
                        return size * size;
                }
                size++;
            }

            return size * size;
        }

        // Fastest
        public static int MaximalSquare4(char[][] matrix)
        {
            if ((matrix?.Length ?? 0) == 0 || (matrix[0]?.Length ?? 0) == 0)
            {
                return 0;
            }

            var ans = 0;
            var M = matrix.Length;
            var N = matrix[0].Length;
            var dp = new int[M + 1][];
            for (var i = 0; i <= M; i++)
            {
                dp[i] = new int[N + 1];
            }

            for (var i = 1; i <= M; i++)
            {
                for (var j = 1; j <= N; j++)
                {
                    var target = matrix[i - 1][j - 1] - '0';
                    dp[i][j] = target == 0 ? 0 : Math.Min(dp[i - 1][j - 1], Math.Min(dp[i][j - 1], dp[i - 1][j])) + 1;
                    ans = Math.Max(ans, dp[i][j] * dp[i][j]);
                }
            }

            return ans;
        }
    }
}
