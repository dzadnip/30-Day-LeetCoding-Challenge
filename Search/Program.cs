using System;
using System.Globalization;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };

            int target = 0; // expect 4
            Console.WriteLine(Search3(nums, target));

            target = 3; // expect -1
            Console.WriteLine(Search3(nums, target));
        }

        static public int Search(int[] nums, int target)
        {
            //Array.Sort(nums);
            return BinarySearch2(nums, target, 0, nums.Length - 1);
        }

        // at first I thought this would work, but it would require a sorted array, which would mean the initial index would be wrong.
        static int BinarySearch(int[] nums, int target, int start, int end)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] == target) return mid;
                else if (nums[mid] < target) start = mid + 1;
                else end = mid - 1;

                BinarySearch(nums, target, start, end);
            }

            return -1;
        }

        // submitted this function based on a solution I saw in discussion area.
        static int BinarySearch2(int[] nums, int target, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = start + (end - start) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[start] <= nums[mid] && target <= nums[mid] && target >= nums[start])
            {
                return BinarySearch2(nums, target, start, mid - 1);
            }

            else if (nums[mid] <= nums[end] && target >= nums[mid] && target <= nums[end])
            {
                return BinarySearch2(nums, target, mid + 1, end);
            }

            else if (nums[end] <= nums[mid])
            {
                return BinarySearch2(nums, target, mid + 1, end);
            }

            else if (nums[start] >= nums[mid])
            {
                return BinarySearch2(nums, target, start, mid - 1);
            }

            return -1;
        }


        // Memory Distrbution
        // I like this one
        static int Search2(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[start] <= nums[mid])
                {
                    if (target >= nums[start] && target < nums[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }

                if (nums[mid] <= nums[end])
                {
                    if (target > nums[mid] && target <= nums[end])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }

            }

            return -1;
        }

        // This was another good solution
        static int Search3(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int start = 0, end = nums.Length - 1;

            int pivot = FindPivot(nums);
            if (target >= nums[pivot] && target <= nums[end])
            {
                start = pivot;
            }
            else
            {
                end = pivot;
            }

            return BinarySearch(nums, target, start, end);
        }

        static int BinarySearch(int[] nums, int target, long start, long end)
        {
            if (start > end)
                return -1;
            long mid = start + (end - start) / 2;
            if (nums[mid] == target)
                return (int)mid;
            else if (nums[mid] > target)
                end = mid - 1;
            else if (nums[mid] < target)
                start = mid + 1;
            return BinarySearch(nums, target, start, end);
        }

        static int FindPivot(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            int pivot = 0;

            while (start < end)
            {
                if (nums[start] > nums[start + 1])
                {
                    pivot = start + 1;
                    break;
                }

                start++;
            }

            return pivot;
        }

    }
}
