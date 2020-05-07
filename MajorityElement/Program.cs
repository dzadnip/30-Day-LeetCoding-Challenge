using System;
using System.Collections.Generic;

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MajorityElement(new int[] { 3, 2, 3}));
            //3

            Console.WriteLine(MajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2 }));
            //2
        }

        static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> numHash = new Dictionary<int, int>();
            int majorityNum = nums[0];
            int majorityCount = 0;
            foreach (int num in nums)
            {
                if (numHash.ContainsKey(num))
                {
                    numHash[num] = numHash[num] + 1;
                    if (numHash[num] > majorityCount)
                    {
                        majorityNum = num;
                        majorityCount = numHash[num];
                    }
                }
                else
                {
                    numHash.Add(num, 1);
                }
            }
            return majorityNum;
        }

        //Runtime Distribution
        static int MajorityElement2(int[] nums)
        {

            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            int m = nums.Length / 2;

            var dict = new Dictionary<int, int>();

            foreach (int n in nums)
            {
                if (dict.ContainsKey(n))
                {
                    dict[n] = dict[n] + 1;
                }
                else
                {
                    dict.Add(n, 1);
                }
            }
            foreach (int k in dict.Keys)
            {
                if (dict[k] > m)
                    return k;
            }
            return 0;
        }

        static int MajorityElement3(int[] nums)
        {
            int result = 0;
            int count = 0;
            foreach (int n in nums)
            {
                if (count == 0)
                {
                    result = n;
                    count = 1;
                }
                else if (n == result)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            return result;
        }

        // Memory Distribution
        // Didn't realize this was the solution until submitted my solution
        static int MajorityElement4(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
    }
}
