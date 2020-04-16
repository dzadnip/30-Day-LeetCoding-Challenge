using System;
using System.Linq;

namespace ProductExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 2, 3, 4 };
            Console.Write("Input: ");
            foreach (int value in input)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            int[] output = ProductExceptSelf01(input);
            Console.WriteLine("Expected: 24,12,8,6");
            Console.WriteLine();
            Console.Write("Output: ");
            foreach (int value in output)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();

            input = new int[] { 0, 0 };
            Console.Write("Input: ");
            foreach (int value in input)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            output = ProductExceptSelf01(input);
            Console.WriteLine("Expected: 0,0");
            Console.WriteLine();
            Console.Write("Output: ");
            foreach (int value in output)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();

            input = new int[] { 1, 0 };
            Console.Write("Input: ");
            foreach (int value in input)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            output = ProductExceptSelf01(input);
            Console.WriteLine("Expected: 0,1");
            Console.WriteLine();
            Console.Write("Output: ");
            foreach (int value in output)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        static int[] ProductExceptSelf(int[] nums)
        {
            int[] output = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < output.Length; j++)
                {
                    if (output[j].Equals(0) && !nums[i].Equals(0))
                    {
                        output[j] = nums[i];
                    }
                    else
                    {
                        if (j != i)
                        {
                            output[j] *= nums[i];
                        }
                    }
                }
            }
            return output;
        }


        // from Discussion area
        static int[] ProductExceptSelf01(int[] nums)
        {
            int[] arr = new int[nums.Length];

            // forward
            Console.WriteLine("Forward");
            Console.WriteLine("");
            int prod = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"i = {i}");
                Console.WriteLine($"nums[{i}] = {nums[i]}");
                Console.WriteLine($"prod before = {prod}");
                prod *= nums[i];
                Console.WriteLine($"prod after = {prod}");
                arr[i] = prod;
                Console.WriteLine($"arr[{i}] = {arr[i]}");
                Console.WriteLine("");
            }

            // backwards
            Console.WriteLine("Backward");
            Console.WriteLine("");
            prod = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"i = {i}");
                Console.WriteLine($"arr[{i}] before = {arr[i]}");
                if (i > 0)
                {
                    Console.WriteLine($"arr[{i} - 1] = {arr[i - 1]}");
                }
                Console.WriteLine($"prod before = {prod}");
                arr[i] = prod * (i > 0 ? arr[i - 1] : 1);
                Console.WriteLine($"arr[{i}] after = {arr[i]}");
                Console.WriteLine($"nums[{i}] = {nums[i]}");
                prod *= nums[i];
                Console.WriteLine($"prod after = {prod}");
                Console.WriteLine("");
            }

            return arr;
        }
    }
}
