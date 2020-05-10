using System;
using System.Collections.Generic;
using System.Text;

namespace IsPerfectSquare
{
    public class Solution
    {
        /*
            1:  1
            4:  1 + 3
            9:  1 + 3 + 5
            16: 1 + 3 + 5 + 7
            25: 1 + 3 + 5 + 7 + 9   
    
            Time: O(sqrt(num))
                  num = 1 + 2 + 3 + ... + n = n*(n+1)/2 => n = O(sqrt(num))
            Space: O(1)
        */
        public bool IsPerfectSquare(int num)
        {
            int i = 1;
            while (num > 0)
            {
                num -= i;
                i += 2;
            }
            return num == 0 ? true : false;
        }

        // Runtime Distribution
        public bool IsPerfectSquare2(int num)
        {
            int i = 1; int j = num;
            while (i <= j)
            {
                int m = i + (j - i) / 2;
                if (m == num / m)
                {
                    if (num % m == 0) return true;
                    return false;
                }
                else if (m > num / m)
                {
                    j = m - 1;
                }
                else
                {
                    i = m + 1;
                }
            }
            return false;
        }

        public bool IsPerfectSquare3(int num)
        {
            if (num == 0)
                return false;

            long r = num;
            while (r * r > num)
            {
                r = (r + num / r) / 2;
            }
            if (r * r == num)
                return true;

            return false;
        }

        // Memory Distribution
        public bool IsPerfectSquare4(int num)
        {
            long begin = 0;
            long end = num;
            while (begin <= end)
            {
                long mid = (end - begin) / 2 + begin;
                long mid2 = mid * mid;

                if (mid2 == num)
                {
                    return true;
                }
                if (mid2 < num)
                {
                    begin = mid + 1;
                }
                if (mid2 > num)
                {
                    end = mid - 1;
                }
            }
            return false;
        }
    }
}
