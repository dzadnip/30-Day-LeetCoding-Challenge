using System;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given two strings text1 and text2, return the length of their longest common subsequence.

            //A subsequence of a string is a new string generated from the original string with some 
            //characters(can be none) deleted without changing the relative order of the remaining characters.
            //(eg, "ace" is a subsequence of "abcde" while "aec" is not). A common subsequence of two strings 
            //is a subsequence that is common to both strings.

            //If there is no common subsequence, return 0.

            string text1 = "abcde", text2 = "ace";
            //3
            Console.WriteLine(LongestCommonSubsequence(text1, text2));

            text1 = "abc";
            text2 = "abc";
            //3
            Console.WriteLine(LongestCommonSubsequence(text1, text2));

            text1 = "abc";
            text2 = "def";
            //0
            Console.WriteLine(LongestCommonSubsequence(text1, text2));

            text1 = "abcdefghijklmnopqrstuvwxyz";
            text2 = "zyxwvutsrqponmlkjihgfedcba";
            //1
            Console.WriteLine(LongestCommonSubsequence(text1, text2));

            text1 = "acegikmoqsuwy";
            text2 = "zxvtrpnljhfdb";
            //0
            Console.WriteLine(LongestCommonSubsequence(text1, text2));
        }

        //Not sure I fully understand yet how this Dynamic Programming solution works, but here's a simple to read function from the discussion area
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];
            for (int i = 1; i <= text1.Length; i++)
                for (int j = 1; j <= text2.Length; j++)
                    if (text1[i - 1] == text2[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                    else dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            return dp[text1.Length, text2.Length];
        }
    }
}
