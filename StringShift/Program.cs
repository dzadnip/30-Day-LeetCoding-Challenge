using System;
using System.Text;

namespace StringShift
{
    class Program
    {
        static void Main(string[] args)
        {

            //You are given a string s containing lowercase English letters, and a matrix shift, where shift[i] = [direction, amount]:
            //direction can be 0(for left shift) or 1(for right shift).
            //amount is the amount by which string s is to be shifted.
            //A left shift by 1 means remove the first character of s and append it to the end.
            //Similarly, a right shift by 1 means remove the last character of s and add it to the beginning.
            //Return the final string after all operations.

            //Example 1:
            //Input: s = "abc", shift = [[0,1],[1,2]]
            //Output: "cab"
            //Explanation: 
            //[0,1] means shift to left by 1. "abc" -> "bca"
            //[1,2] means shift to right by 2. "bca" -> "cab"

            string s = "abc";
            int[][] shift = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 2 }
             };


            //Example 2:
            //Input: s = "abcdefg", shift = [[1,1],[1,1],[0,2],[1,3]]
            //Output: "efgabcd"
            //Explanation:  
            //[1,1] means shift to right by 1. "abcdefg" -> "gabcdef"
            //[1,1] means shift to right by 1. "gabcdef" -> "fgabcde"
            //[0,2] means shift to left by 2. "fgabcde" -> "abcdefg"
            //[1,3] means shift to right by 3. "abcdefg" -> "efgabcd"

            s = "abcdefg";
            shift = new int[][] {
                new int[] { 1, 1 },
                new int[] { 1, 1 },
                new int[] { 0, 2 },
                new int[] { 1, 3 },
                new int[] { 0, 4 },
                new int[] { 1, 40 }
             };

            StringShift(s, shift);

        }

        static string StringShift(string s, int[][] shift)
        {
            int rotateRight = 0;
            foreach (int[] shiftSet in shift)
            {
                if (shiftSet[0] == 0)
                {
                    rotateRight -= shiftSet[1];
                } else
                {
                    rotateRight += shiftSet[1];
                }
            }
            return StringShiftApply(s, rotateRight);
        }

        static string StringShiftApply(string s, int rotateRight)
        {
            Console.WriteLine($"string is {s}");
            Console.WriteLine($"string length is {s.Length}");
            Console.WriteLine($"Rotate is {rotateRight}");
            if (Math.Abs(rotateRight) > s.Length)
            {
                rotateRight %= s.Length;
                Console.WriteLine($"Remainder is {rotateRight}");
            }

            if (rotateRight < 0)
            {
                rotateRight %= s.Length;
                rotateRight += s.Length;
                Console.WriteLine($"Reverse is {rotateRight}");
            }
            Console.WriteLine($"Rotated string to the right by {rotateRight}");

            StringBuilder sb = new StringBuilder(s);

            for (int moveFromPointer = 0; moveFromPointer < s.Length; moveFromPointer++, rotateRight++)
            {
                if (rotateRight > s.Length - 1)
                {
                    rotateRight = 0;
                }
                sb[rotateRight] = s[moveFromPointer];
                Console.WriteLine($"Move {moveFromPointer} = {sb.ToString()}");
            }
            return sb.ToString();
        }

    }
}
