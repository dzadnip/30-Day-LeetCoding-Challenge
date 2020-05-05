using System;

namespace FindComplement
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;
            Console.WriteLine(FindComplement(num));
            Console.WriteLine(FindComplement2(num));
            Console.WriteLine(FindComplement3(num));
            Console.WriteLine(FindComplement4(num));
            Console.WriteLine(FindComplement5(num));
        }

        static int FindComplement(int num)
        {
            return Convert.ToInt32(Convert.ToString(num, 2));
        }

        // My solution
        static int FindComplement2(int num)
        {
            return Convert.ToInt32(Convert.ToString(num, 2).Replace('0', 'z').Replace('1', 'o').Replace('z', '1').Replace('o', '0'), 2);
        }

        // Runtime Distribution
        static int FindComplement3(int num)
        {
            return num ^ ((int)Math.Pow(2, (int)Math.Log(num, 2) + 1) - 1);
        }

        static int FindComplement4(int num)
        {
            int x = num;
            while (true)
            {
                var b = x & x - 1;
                if (b == 0)
                {
                    return ~num & (x - 1);
                }

                x = b;
            }
        }

        // Memory Distribution
        static int FindComplement5(int num)
        {
            int mask = 1;
            while (mask < num)
                mask = (mask << 1) | 1;
            return ~num & mask;
        }
    }
}
