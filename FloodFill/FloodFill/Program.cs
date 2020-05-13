using System;
using System.Text.RegularExpressions;

namespace FloodFill
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution FloodFill = new Solution();

            int[][] image = {
                new int[] { 1, 1, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 1, 0, 1 }
            };

            Console.WriteLine("Input");

            for (int j = 0; j < image.Length; j += 1)
            {
                for (int k = 0; k < image[j].Length; k += 1)
                {
                    Console.Write($"{image[j][k]} ");
                }
                Console.WriteLine();
            }

            int sr = 1;
            int sc = 1;
            int newColor = 2;

            int[][] result = FloodFill.FloodFill(image, sr, sc, newColor);

            Console.WriteLine("Ouput");

            for (int j = 0; j < result.Length; j += 1)
            {
                for (int k = 0; k < result[j].Length; k += 1)
                {
                    Console.Write($"{result[j][k]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
