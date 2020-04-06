using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0, 1, 0, 3, 12 };

            DisplayArray(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] == 0)
                {
                    int temp = nums[i];
                    int nextNonZero = FindNextNonZeroNumber(nums, i);
                    nums[i] = nums[nextNonZero];
                    nums[nextNonZero] = temp;
                }
            }

            DisplayArray(nums);
        }

        static int FindNextNonZeroNumber (int[] nums, int i)
        {
            for(int j = i; j < nums.Length; j++)
            {
                if(nums[j] != 0)
                {
                    return j;
                }
            }
            return nums.Length - 1;
        }

        static void DisplayArray(int[] nums)
        {
            Console.WriteLine();
            foreach(int num in nums)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }


        public void MoveZeroes1(int[] nums)
        {
            var zeros = 0;
            var write = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    zeros++;
                else
                {
                    nums[write++] = nums[i];
                }
            }

            Array.Fill(nums, 0, nums.Length - zeros, zeros);
        }


        public void MoveZeroes2(int[] nums)
        {
            int i = 0, j;
            while (i < nums.Length && nums[i] != 0) { i++; }
            j = i + 1;
            while (j < nums.Length)
            {
                if (nums[j] != 0)
                {
                    nums[i++] = nums[j];
                    nums[j] = 0;
                }
                j++;
            }
        }


        public void MoveZeroes3(int[] nums)
        {
            var insertAt = 0;

            for (var i = 0; i < nums.Length; i++)
                if (nums[i] != 0)
                    nums[insertAt++] = nums[i];

            while (insertAt < nums.Length)
                nums[insertAt++] = 0;
        }


        public void MoveZeroes4(int[] nums)
        {
            if (nums.Length == 0) return;

            int index = 0;
            int zeroIndex = -1;

            while (index < nums.Length)
            {
                if (nums[index] == 0 && zeroIndex == -1) zeroIndex = index;
                else if (nums[index] != 0)
                {
                    if (zeroIndex >= 0)
                    {
                        nums[zeroIndex] = nums[index];
                        nums[index] = 0;

                        if (nums[zeroIndex + 1] == 0) zeroIndex++;
                        else zeroIndex = -1;
                    }
                }

                index++;
            }
        }


        public void MoveZeroes5(int[] nums)
        {
            int i = 0;
            while (i < nums.Length && nums[i] != 0) i++;
            int zeroes = 1;
            while (i + zeroes < nums.Length)
            {
                int temp = nums[i + zeroes];
                nums[i + zeroes] = 0;
                nums[i] = temp;

                if (nums[i] == 0)
                {
                    zeroes++;
                }
                else
                {
                    i++;
                }
            }
        }


        public void MoveZeroes6(int[] nums)
        {
            int zeros = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    zeros++;
                else if (zeros > 0)
                {
                    nums[i - zeros] = nums[i];
                    nums[i] = 0;
                }
            }
        }


        public void MoveZeroes7(int[] nums)
        {
            int pointerPosition = 0;
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (nums[i] != 0)
                {
                    nums[pointerPosition++] = nums[i];
                }
            }
            while (pointerPosition <= nums.Length - 1)
            {
                nums[pointerPosition++] = 0;
            }
        }


        public void MoveZeroes8(int[] nums)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            for (var i = k; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }



        public void MoveZeroes11(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                if (nums[i] != 0)
                {
                    continue;
                }
                for (int j = i; j < nums.Length; ++j)
                {
                    if (nums[j] == '0')
                    {
                        break;
                    }
                    if (j == nums.Length - 1)
                    {
                        nums[j] = 0;
                        break;
                    }
                    nums[j] = nums[j + 1];
                }
            }
        }


        public void MoveZeroes12(int[] nums)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != 0)
                {
                    continue;
                }
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (nums[j] != 0)
                    {
                        nums[i] = nums[j];
                        nums[j] = 0;
                        break;
                    }
                }
            }
        }


        public void MoveZeroes13(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j++] = nums[i];
                }
            }
            while (j < nums.Length)
            {
                nums[j++] = 0;
            }
        }


        public void MoveZeroes14(int[] nums)
        {
            int nonZeroLeft = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != 0)
                {
                    continue;
                }
                nonZeroLeft = Math.Max(nonZeroLeft, i + 1);
                for (int j = nonZeroLeft; j < nums.Length; ++j)
                {
                    if (nums[j] != 0)
                    {
                        nums[i] = nums[j];
                        nums[j] = 0;
                        nonZeroLeft = j + 1;
                        break;
                    }
                }
                if (nonZeroLeft >= nums.Length)
                {
                    break;
                }
            }
        }


        public void MoveZeroes15(int[] nums)
        {
            int curStartIndex = 0;
            int curIndex = 0;
            while (curIndex < nums.Length)
            {
                if (nums[curIndex] != 0)
                {
                    nums[curStartIndex] = nums[curIndex];
                    curStartIndex++;
                }
                curIndex++;
            }

            while (curStartIndex < nums.Length)
            {
                nums[curStartIndex] = 0;
                curStartIndex++;
            }
        }


    }
}
