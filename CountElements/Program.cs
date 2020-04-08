using System;
using System.Collections.Generic;

namespace CountElements
{
    class Program
    {
        static void Main(string[] args)
        {
            //[1,2,3] = 2
            int[] arr = new int[] {1, 2, 3};
            Console.WriteLine(CountElements(arr));

            //[1,1,3,3,5,5,7,7] = 0

            //[1,3,2,3,5,0] = 3
            
            //[1,1,2,2] = 2

        }

        static int CountElements(int[] arr)
        {
            int pairCount = 0;
            List<int> elements = new List<int>();
            foreach (int ar in arr)
            {
                elements.Add(ar);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (elements.Contains(arr[i] + 1))
                {
                    pairCount++;
                }
            }
            return pairCount;
        }
    }
}
