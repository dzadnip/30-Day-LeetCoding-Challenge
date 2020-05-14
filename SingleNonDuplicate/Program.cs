using System;

namespace SingleNonDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {

            //Input: [1, 1, 2, 3, 3, 4, 4, 8, 8]
            //Output: 2
            Console.WriteLine(SingleNonDuplicate(new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }));

            //Input: [3, 3, 7, 7, 10, 11, 11]
            //Output: 10
            Console.WriteLine(SingleNonDuplicate2(new int[] { 3, 3, 7, 7, 10, 11, 11 }));
        }

        // Copied from discussion area
        public static int SingleNonDuplicate(int[] nums)
        {
            int once = 0;
            foreach (int n in nums)
                once ^= n;
            return once;
        }

        // Runtime Distribution
        public static int SingleNonDuplicate2(int[] nums)
        {
            int l = 0, r = nums.Length - 1;

            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (mid % 2 == 1) mid--;

                if (nums[mid] != nums[mid + 1])
                {
                    r = mid;
                }
                else
                {
                    l = mid + 2;
                }
            }

            return nums[l];
        }
    }
}
