using System;
using System.Collections.Generic;

namespace SubarraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            int k = 1;
            // 3
            Console.WriteLine(SubarraySum(nums, k));

            k = 2;
            // 8
            Console.WriteLine(SubarraySum(nums, k));

            k = 3;
            // 7
            Console.WriteLine(SubarraySum(nums, k));

            k = 4;
            // 15
            Console.WriteLine(SubarraySum(nums, k));

            k = 5;
            // 3
            Console.WriteLine(SubarraySum(nums, k));

            k = 6;
            // 9
            Console.WriteLine(SubarraySum(nums, k));

            k = 7;
            // 4
            Console.WriteLine(SubarraySum(nums, k));

            k = 8;
            // 13
            Console.WriteLine(SubarraySum(nums, k));

            k = 9;
            // 6
            Console.WriteLine(SubarraySum(nums, k));

            k = 10;
            // 5
            Console.WriteLine(SubarraySum(nums, k));

            k = 11;
            // 5
            Console.WriteLine(SubarraySum(nums, k));

            k = 12;
            // 12
            Console.WriteLine(SubarraySum(nums, k));

            k = 13;
            // 5
            Console.WriteLine(SubarraySum(nums, k));

            k = 14;
            // 4
            Console.WriteLine(SubarraySum(nums, k));

            k = 15;
            // 5    
            Console.WriteLine(SubarraySum(nums, k));
        }

        // Did not know how to solve this, used example from discussion area.
        public static int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int> { [0] = 1 };
            foreach (int num in nums)
            {
                sum += num;
                count += dictionary.GetValueOrDefault(sum - k);
                dictionary[sum] = dictionary.GetValueOrDefault(sum) + 1;
            }
            return count;
        }

        // Runtime Distribution
        public static int SubarraySum1(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;

            if (nums.Length == 0)
            {
                return count;
            }

            Dictionary<int, int> memo = new Dictionary<int, int>();
            // default occurance of sum to 0 is 1.
            memo.Add(0, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (memo.ContainsKey(sum - k))
                {
                    count += memo[sum - k];
                }

                if (!memo.ContainsKey(sum))
                {
                    memo.Add(sum, 0);
                }

                memo[sum]++;
            }

            return count;
        }


        // Memory distribution
        public static int SubarraySum2(int[] nums, int k)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum == k)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
