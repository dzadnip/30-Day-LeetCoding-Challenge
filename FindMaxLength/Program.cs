using System;
using System.Collections.Generic;

namespace FindMaxLength
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0,1,0 };
            Console.WriteLine(FindMaxLength1(nums));
            Console.WriteLine(FindMaxLength2(nums));
        }

        // Copied this from the discussion area - still trying to figure out the logic for this question
        static int FindMaxLength1(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int> { [0] = -1 };
            int count = 0;
            int maxL = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count += (nums[i] == 0 ? -1 : 1);
                if (dict.ContainsKey(count))
                {
                    maxL = Math.Max(maxL, i - dict[count]);
                }
                else
                {
                    dict[count] = i;
                }
            }
            return maxL;
        }

        static int FindMaxLength2(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int count = 0;
            int maxLength = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) count++;
                if (nums[i] == 0) count--;

                if (dict.ContainsKey(count))
                    maxLength = Math.Max(maxLength, i - dict[count]);
                else
                    dict[count] = i;

                if (count == 0)
                    maxLength = i + 1;
            }
            return maxLength;
        }
    }
}
