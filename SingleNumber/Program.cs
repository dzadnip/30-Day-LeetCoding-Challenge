using System;

namespace SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4 };

            int[] nums2 = new int[] { 1, 3, 1, -1, 3 };

            Console.WriteLine(SingleNumber2(nums));
        }

        static int SingleNumber(int[] nums)
        {
            Array.Sort(nums);
            int returnNum = nums[nums.Length - 1];

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    returnNum = nums[i];
                }
                else
                {
                    i++;
                }
            }
            return returnNum;
        }

        static int SingleNumber2(int[] nums)
        {
            var xor = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                xor ^= nums[i];
            }
            return xor;
        }
    }
}
