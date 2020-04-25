using System;

namespace CanJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 0, 8, 2, 0, 0, 1 };
            // true
            Console.WriteLine(CanJump3(nums));

            nums = new int[] { 2, 3, 1, 1, 4 };
            // true
            Console.WriteLine(CanJump3(nums));

            nums = new int[] { 3, 2, 1, 0, 4 };
            //false
            Console.WriteLine(CanJump3(nums));

        }

        // I'm clerly over engineering this solution, which did not work for all cases anyway.
        public static bool CanJump(int[] nums)
        {
            int jump = 0;
            int index = 0;
            bool reachedLastIndex = false;
            if (nums.Length == 1)
            {
                reachedLastIndex = true;
            }
            else
            {
                bool keepJumping = true;
                while (keepJumping)
                {
                    jump = nums[index];
                    index += jump;
                    if (index >= nums.Length - 1)
                    {
                        keepJumping = false;
                        reachedLastIndex = true;
                    }
                    else if (nums[index] == 0 && index != nums.Length - 1)
                    {
                        if (index != 0)
                        {
                            index--;
                            if (nums[index] == 1)
                            {
                                keepJumping = false;
                            }
                        }
                        else
                        {
                            keepJumping = false;
                        }
                        reachedLastIndex = false;
                    }
                }
            }
            return reachedLastIndex;
        }

        // found a very elegant solution in discussion area
        public static bool CanJump2(int[] nums)
        {
            int min = 0;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] > min) min = 0;
                else min++;
            }
            return min == 0;
        }

        public static bool CanJump3(int[] nums)
        {
            int finalDestination = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i + nums[i] > finalDestination)
                {
                    finalDestination = i + nums[i];
                }

                if (i + 1 > finalDestination || finalDestination >= nums.Length - 1)
                {
                    break;
                }
            }

            return finalDestination >= nums.Length - 1;
        }

    }
}
