using System;
using System.Linq;

namespace NumJewelsInStones
{
    class Program
    {
        static void Main(string[] args)
        {
            string J = "aA";
            string S = "aAAbbbb";
            Console.WriteLine(NumJewelsInStones(J, S));
        }
        public static int NumJewelsInStones(string J, string S)
        {
            int stonesThatAreJewels = 0;
            foreach (char s in S)
            {
                foreach (char j in J)
                {
                    if (s == j)
                    {
                        stonesThatAreJewels++;
                    }
                }
            }
            return stonesThatAreJewels;
        }

        // Not sure why, but the fastest Runtime Distribution solution used for loops and was 2 times faster

        public static int NumJewelsInStones2(string J, string S)
        {
            int count = 0;
            for (int i = 0; i < J.Length; i++)
            {

                for (int k = 0; k < S.Length; k++)
                {
                    if (J[i] == S[k])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // second fastest, using Linq
        public static int NumJewelsInStones3(string J, string S)
        {
            return S.Count(c => J.Contains(c));
        }

        // Memory Distribution

        public static int NumJewelsInStones11(string J, string S)
        {
            int result = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (J.Contains(S[i]))
                    result++;
            }

            return result;
        }
    }
}
