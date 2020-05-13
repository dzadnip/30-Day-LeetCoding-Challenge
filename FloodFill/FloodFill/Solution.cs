using System;
using System.Collections.Generic;
using System.Text;

namespace FloodFill
{
    public class Solution
    {
        // Copied this code from conversation area
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int oldColor = image[sr][sc];
            int rowMax = image.Length - 1;
            int colMax = image[0].Length - 1;

            if (oldColor != newColor) Fill(sr, sc);
            return image;

            void Fill(int row, int col)
            {
                if (
                    row < 0 || 
                    rowMax < row || 
                    col < 0 || 
                    colMax < col ||
                    image[row][col] != oldColor
                    ) return;

                image[row][col] = newColor;

                Fill(row - 1, col);
                Fill(row + 1, col);
                Fill(row, col - 1);
                Fill(row, col + 1);
            }
        }

        // Runtime Distribution
        public int[][] FloodFill2(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor)
                return image;

            Fill(image, sr, sc, image[sr][sc], newColor);
            return image;
        }

        public void Fill(int[][] image, int i, int j, int color, int newColor)
        {
            if (i < 0 || i >= image.Length || j < 0 || j >= image[i].Length || image[i][j] != color)
                return;

            image[i][j] = newColor;
            Fill(image, i - 1, j, color, newColor);
            Fill(image, i + 1, j, color, newColor);
            Fill(image, i, j - 1, color, newColor);
            Fill(image, i, j + 1, color, newColor);
        }

        public int[][] FloodFill3(int[][] image, int sr, int sc, int newColor)
        {

            dfs(image, sr, sc, image[sr][sc], newColor);
            return image;
        }

        public void dfs(int[][] img, int i, int j, int oldColor, int newColor)
        {
            if (i < 0 || i > img.Length - 1 || j < 0 || j > img[0].Length - 1 ||
               img[i][j] != oldColor || img[i][j] == newColor)
            {
                return;
            }

            img[i][j] = newColor;
            dfs(img, i, j - 1, oldColor, newColor);
            dfs(img, i - 1, j, oldColor, newColor);
            dfs(img, i, j + 1, oldColor, newColor);
            dfs(img, i + 1, j, oldColor, newColor);

        }
    }
}
