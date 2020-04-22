using System;
using System.Collections.Generic;

namespace LeftMostColumnWithOne
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: mat = [[0,0],[1,1]]
            //Output: 0
            int[][] jaggedArray1 =
            {
                new int[] { 0, 0},
                new int[] { 1, 1 },
            };

            //Input: mat = [[0,0],[0,1]]
            //Output: 1
            int[][] jaggedArray2 =
            {
                new int[] { 0, 0},
                new int[] { 0, 1 },
            };

            //Input: mat = [[0,0],[0,0]]
            //Output: -1
            int[][] jaggedArray3 =
            {
                new int[] { 0, 0},
                new int[] { 0, 0 },
            };

            //Input: mat = [[0,0,0,1],[0,0,1,1],[0,1,1,1]]
            //Output: 1
            int[][] jaggedArray4 =
            {
                new int[] { 0, 0, 0, 1},
                new int[] { 0, 0, 1, 1 },
                new int[] { 0, 1, 1, 1 }
            };


            BinaryMatrix binaryMatrix = new BinaryMatrix(jaggedArray1);
            Console.WriteLine(LeftMostColumnWithOne(binaryMatrix));
        }

        static public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            IList<int> pointer = binaryMatrix.Dimensions();

            int x = 0;
            int y = pointer[1] - 1;
            int leftmostColumn = -1;
            bool keepRunning = true;

            int valueAtXY = binaryMatrix.Get(x, y);

            while (keepRunning)
            {
                Console.WriteLine($"Value at: {x}, {y} = {valueAtXY}");

                if (valueAtXY == 1)
                {
                    leftmostColumn = y;
                    Console.WriteLine($"Setting leftmost column to {x}");
                    //move left
                    y--;
                    Console.WriteLine($"y is now {y}");
                }
                else
                {
                    //move down
                    x++;
                    Console.WriteLine($"x is now {x}");
                }

                if (x > pointer[0] - 1 || y < 0)
                {
                    Console.WriteLine($"Getting out of while loop");
                    keepRunning = false;
                }
                else
                {
                    valueAtXY = binaryMatrix.Get(x, y);
                }
            }

            return leftmostColumn;
        }
    }
}
