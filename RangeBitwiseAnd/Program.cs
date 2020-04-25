using System;

namespace RangeBitwiseAnd
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 5, 7 };
            // 4
            Console.WriteLine(RangeBitwiseAnd(input[0], input[1]));

            input = new int[] { 0,1 };
            // 0
            Console.WriteLine(RangeBitwiseAnd(input[0], input[1]));
        }

        // Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.
        public static int RangeBitwiseAnd(int m, int n)
        {
            if (m < n) return (RangeBitwiseAnd(m >> 1, n >> 1) << 1);
            return m;
        }
    }
}
