using System;
using System.Collections.Generic;
using System.Text;

namespace LeftMostColumnWithOne
{
    /**
    * // This is BinaryMatrix's API interface.
    * // You should not implement it, or speculate about its implementation
    * class BinaryMatrix {
    *     public int Get(int x, int y) {}
    *     public IList<int> Dimensions() {}
    * }
    */

    class BinaryMatrix
    {
        private int[][] _jaggedArray = new int[1][];
        public BinaryMatrix(int[][] jaggedArray)
        {
            _jaggedArray = jaggedArray;
        }

        public int Get(int x, int y)
        {
            return _jaggedArray[x][y];
        }
        public IList<int> Dimensions()
        {
            List<int> dimensions = new List<int>();
            dimensions.Add(_jaggedArray.Length);
            dimensions.Add(_jaggedArray[0].Length);
            return dimensions;
        }
    }
}
