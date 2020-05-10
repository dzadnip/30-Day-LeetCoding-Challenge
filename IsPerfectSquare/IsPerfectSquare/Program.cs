using System;

namespace IsPerfectSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution IsPerfectSquare = new Solution();
            Console.WriteLine(IsPerfectSquare.IsPerfectSquare(16));
            Console.WriteLine(IsPerfectSquare.IsPerfectSquare(14));

            Console.WriteLine(IsPerfectSquare.IsPerfectSquare2(16));
            Console.WriteLine(IsPerfectSquare.IsPerfectSquare2(14));

            Console.WriteLine(IsPerfectSquare.IsPerfectSquare3(16));
            Console.WriteLine(IsPerfectSquare.IsPerfectSquare3(14));

            Console.WriteLine(IsPerfectSquare.IsPerfectSquare4(16));
            Console.WriteLine(IsPerfectSquare.IsPerfectSquare4(14));
        }
    }
}
