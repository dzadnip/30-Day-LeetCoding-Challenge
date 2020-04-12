using System;
using System.Collections.Generic;
using System.Linq;

namespace LastStoneWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: [2,7,4,1,8,1]
            //Output: 1
            //Explanation: 
            //We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
            //we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
            //we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
            //we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of last stone.


            int[] stones = new int[] { 2, 7, 4, 1, 8, 1 };

            Console.WriteLine(LastStoneWeight(stones));
        }

        // My submission
        public static int LastStoneWeight(int[] stones)
        {
            List<int> stonesList = stones.OfType<int>().ToList();
            while (stonesList.Count > 1)
            {
                int max1 = stonesList.Max();
                stonesList.Remove(max1);
                int max2 = stonesList.Max();
                stonesList.Remove(max2);

                if (max1 != max2)
                {
                    max1 -= max2;
                    stonesList.Add(max1);
                }
            }
            if (stonesList.Count == 0)
            {
                return 0;
            }
            return stonesList[0];
        }

        // Runtime Distribution

        // My favorite
        public int LastStoneWeight1(int[] stones)
        {
            Array.Sort(stones);

            int last = stones.Length - 1, prev = last - 1, stonesToSmash = last;

            while (stonesToSmash-- > 0)
            {
                stones[last] -= stones[prev];
                stones[prev] = 0;

                Array.Sort(stones);
            }

            return stones[last];
        }




    }
}
