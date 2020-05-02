using System;
using System.Diagnostics.CodeAnalysis;

namespace FirstBadVersion
{
    class Program
    {
        private static int LastGoodVersion;
        static void Main(string[] args)
        {
            LastGoodVersion = 4 - 1;
            Console.WriteLine(FirstBadVersion2(5));

            LastGoodVersion = 2 - 1;
            Console.WriteLine(FirstBadVersion2(2));

            LastGoodVersion = 1 - 1;
            Console.WriteLine(FirstBadVersion2(1));

            LastGoodVersion = 1702766719 - 1;
            Console.WriteLine(FirstBadVersion2(2126753390));

            LastGoodVersion = 1 - 1;
            Console.WriteLine(FirstBadVersion2(4));
        }

        // Does not work
        public static int FirstBadVersion(int n)
        {
            int FirstBadVersion = n;

            int pointer = 0;

            if (pointer != FirstBadVersion)
            {
                int previousPointer = pointer;

                bool keepRunning = true;

                while (keepRunning)
                {
                    Console.WriteLine(pointer);
                    if (IsBadVersion(pointer))
                    {
                        if (FirstBadVersion != pointer)
                        {
                            FirstBadVersion = pointer;
                            //go back lower
                            if (pointer != 1)
                            {
                                pointer = ((pointer / 2) + (previousPointer / 2));
                            }
                        }
                        else
                        {
                            keepRunning = false;
                        }
                    }
                    else
                    {
                        //keep going higher
                        previousPointer = pointer;
                        pointer = ((pointer / 2) + (n / 2));
                        if (pointer == previousPointer && pointer < n)
                        {
                            pointer++;
                        }
                    }
                }
            }
            return FirstBadVersion;
        }

        public static int FirstBadVersion2(int n)
        {
            return IsVersionBad3(0, n);
        }

        // Doesn't work
        public static int IsVersionBad(int low, int high)
        {
            if (low != high)
            {
                int mid = (high - low) / 2;

                if (IsBadVersion(mid))
                {
                    IsVersionBad(low, mid);
                }
                else
                {
                    IsVersionBad(mid, high);
                }
            }
            return low;
        }

        // Doesn't work
        public static int IsVersionBad2(int low, int high)
        {
            int mid = (low + high) / 2;
            int lowRun = low;
            int highRun = high;
            if (low < high)
            {
                
                if (IsBadVersion(mid))
                {
                    lowRun = IsVersionBad2(low, mid - 1);
                }
                else
                {
                    highRun = IsVersionBad2(mid + 1, high);
                }
            }
            return Math.Max(lowRun, highRun);
        }

        // Submitted this solution, based on example from discuttion area
        public static int IsVersionBad3(int low, int high)
        {
            if (low == high) return low;
            int middle = low + (high - low) / 2;
            return IsBadVersion(middle) ? IsVersionBad3(low, middle) : IsVersionBad3(middle + 1, high);
        }


        public static bool IsBadVersion(int version)
        {
            if (version > LastGoodVersion)
            {
                return true;
            }
            return false;
        }




        // Runtime Distribution
        public static int FirstBadVersion11(int n)
        {
            return CheckBadVersion(1, n);
        }

        public static int CheckBadVersion(int l, int r)
        {
            int mid = l + (r - l) / 2;
            if (IsBadVersion(mid))
            {
                if (!IsBadVersion(mid - 1))
                    return mid;
                else
                    return CheckBadVersion(l, mid - 1);
            }
            else
                return CheckBadVersion(mid + 1, r);
        }


        public static int FirstBadVersion12(int n)
        {
            int left = 1, right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

    }
}
