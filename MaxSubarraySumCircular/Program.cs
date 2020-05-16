using System;
using System.Security.Cryptography;

namespace MaxSubarraySumCircular
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 1, -2, 3, -2 };
            // 3
            Console.WriteLine(MaxSubarraySumCircular(A));

            A = new int[] { 5, -3, 5 };
            // 10
            Console.WriteLine(MaxSubarraySumCircular2(A));

            A = new int[] { 3, -1, 2, -1 };
            // 4
            Console.WriteLine(MaxSubarraySumCircular3(A));

            A = new int[] { 3, -2, 2, -3 };
            // 3
            Console.WriteLine(MaxSubarraySumCircular4(A));

            A = new int[] { -2, -3, -1 };
            // -1
            Console.WriteLine(MaxSubarraySumCircular5(A));
        }

        // Copied from discussion area
        public static int MaxSubarraySumCircular(int[] A)
        {
            int len = A.Length;
            int sum = 0;
            int maxSum = int.MinValue;
            for (int i = 0; i < len; i++)
            {
                sum = A[i] + Math.Max(0, sum);
                maxSum = Math.Max(maxSum, sum);
            }

            int[] rtl = new int[len];
            rtl[len - 1] = A[len - 1];
            int rsum = A[len - 1];
            for (int j = len - 2; j >= 0; j--)
            {
                rsum += A[j];
                rtl[j] = Math.Max(rsum, rtl[j + 1]);
            }

            int lsum = 0;
            for (int i = 0; i < len - 2; i++)
            {
                lsum += A[i];
                maxSum = Math.Max(maxSum, lsum + rtl[i + 2]);
            }
            return maxSum;
        }

        // From discussion area
        public static int MaxSubarraySumCircular2(int[] A)
        {
            // maximum subarray sum of the array
            int currentMax = A[0];
            int globalMax = A[0];

            // minimum subarray sum of the array
            int currentMin = A[0];
            int globalMin = A[0];

            // total sum of the array
            int totalSum = A[0];

            int len = A.Length;

            for (int i = 1; i < len; i++)
            {
                currentMax = Math.Max(A[i % len], currentMax + A[i % len]);
                globalMax = Math.Max(globalMax, currentMax);

                currentMin = Math.Min(A[i % len], currentMin + A[i % len]);
                globalMin = Math.Min(globalMin, currentMin);

                totalSum += A[i];
            }

            return globalMax > 0 ? Math.Max(globalMax, totalSum - globalMin) : globalMax;
        }

        public static int MaxSubarraySumCircular3(int[] A)
        {

            int maxSum = Int32.MinValue, currMax = 0;
            int minSum = Int32.MaxValue, currMin = 0;
            int sum = 0;

            foreach (int num in A)
            {
                currMax = Math.Max(currMax + num, num);
                maxSum = Math.Max(maxSum, currMax);

                currMin = Math.Min(currMin + num, num);
                minSum = Math.Min(minSum, currMin);

                sum += num;
            }

            return maxSum > 0 ? Math.Max(maxSum, sum - minSum) : maxSum;
        }

        // Runtime distribution
        private static int Kadane(int[] nums)
        {
            int cur = 0;
            int res = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                cur = cur + nums[i];
                if (cur < nums[i])
                {
                    cur = nums[i];
                }

                res = Math.Max(cur, res);
            }
            return res;
        }

        public static int MaxSubarraySumCircular4(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int res = Kadane(nums);

            int[] leftPart = new int[nums.Length];
            int[] rightPart = new int[nums.Length];
            int[] maxLeftPart = new int[leftPart.Length];
            int[] maxRightPart = new int[rightPart.Length];

            leftPart[nums.Length - 1] = maxLeftPart[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                leftPart[i] = leftPart[i + 1] + nums[i];
                maxLeftPart[i] = Math.Max(leftPart[i], maxLeftPart[i + 1]); //maximum sum of subarray on the chunk [i, n) that ends on nums[n - 1]
            }

            rightPart[0] = maxRightPart[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                rightPart[i] = rightPart[i - 1] + nums[i];
                maxRightPart[i] = Math.Max(maxRightPart[i - 1], rightPart[i]); //maximum sum of subarray on the chunk [0, i] that starts on nums[0]
            }

            for (int i = 0; i < nums.Length; i++)
            {
                //try to check sum of circular chunk [i, i+1, i+2, ....n-1, 0,1,2...i - 1]
                res = Math.Max(res, maxLeftPart[i] + (i == 0 ? 0 : maxRightPart[i - 1]));
            }

            return res;
        }

        public static int MaxSubarraySumCircular5(int[] A)
        {
            //find max
            //find sum-min
            //return max(max,(sum-min))
            if (A.Length == 0)
                return 0;
            int max = A[0], currentMax = A[0];
            int min = A[0], currentMin = A[0];
            int sum = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                currentMax = Math.Max(A[i], currentMax + A[i]);
                if (currentMax > max)
                    max = currentMax;

                sum += A[i];

                currentMin = Math.Min(A[i], currentMin + A[i]);
                if (currentMin < min)
                    min = currentMin;
            }
            return (sum - min) == 0 ? max : Math.Max(max, (sum - min));
        }
    }
}
