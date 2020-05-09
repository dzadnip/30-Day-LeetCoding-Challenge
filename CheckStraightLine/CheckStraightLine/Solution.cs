using System;
using System.Collections.Generic;
using System.Text;

namespace CheckStraightLine
{
    public class Solution
    {
        // Was not familiar with this solution - found this solution online
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length > 2)
            {
                int xChange = coordinates[1][0] - coordinates[0][0];
                int yChange = coordinates[1][1] - coordinates[0][1];
                for (int i = 2; i < coordinates.Length; i++)
                {
                    if (xChange * (coordinates[i][1] - coordinates[i - 1][1]) != yChange * (coordinates[i][0] - coordinates[i - 1][0]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Runtime Distribution
        public bool CheckStraightLine2(int[][] coordinates)
        {

            if (coordinates == null || coordinates.Length == 1)
            {
                return true;
            }

            int x1 = coordinates[0][0];
            int y1 = coordinates[0][1];

            int x2, y2, x3, y3;

            for (int i = 1; i < coordinates.Length - 1; i++)
            {
                x2 = coordinates[i][0];
                y2 = coordinates[i][1];

                x3 = coordinates[i + 1][0];
                y3 = coordinates[i + 1][1];

                int a = (y2 - y1) * (x3 - x2);
                int b = (y3 - y2) * (x2 - x1);

                if (a != b)
                {
                    return false;
                }

                x2 = x1;
                y2 = y1;

                x1 = x2;
                y1 = y2;
            }

            return true;

        }

        public bool CheckStraightLine3(int[][] coordinates)
        {
            int x0 = coordinates[0][0], y0 = coordinates[0][1], x1 = coordinates[1][0], y1 = coordinates[1][1];
            int dx = x1 - x0, dy = y1 - y0;
            foreach (var co in coordinates)
            {
                int x = co[0], y = co[1];
                if (dx * (y - y1) != dy * (x - x1))
                    return false;
            }
            return true;
        }
    }
}
