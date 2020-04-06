using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (IsHappy(19))
            {
                Console.WriteLine("Is happy");
            }
            else
            {
                Console.WriteLine("Not happy");
            }
        }

        static bool IsHappy(int n)
        {
            int counter = 100;

            while (n != 1 && counter > 0)
            {
                n = SquareEachDigit(GetListOfDigits(n));
                counter--;
            }

            if (counter > 0)
            {
                return true;
            }
            return false;

        }

        static int SquareEachDigit(List<int> digits)
        {
            int number = 0;
            foreach (int digit in digits)
            {
                number += (int)Math.Pow(digit, 2);
            }
            return number;
        }

        static List<int> GetListOfDigits(int number)
        {
            List<int> digits = new List<int>();
            while (number > 0)
            {
                if (number < 10)
                {
                    digits.Add(number);
                    number = 0;
                }
                else
                {
                    digits.Add(number % 10);
                    number /= 10;
                }
            }
            return digits;
        }
    }
}


/*

function isHappy(n)
{
  const target = 1;

  for (let seen = new Set(); n !== target && !seen.has(n); n = sumDigitSquares(n))
  {
    seen.add(n);
  }

  return n === target;
}

function sumDigitSquares(n)
{
  let sum = 0;

  for (; n !== 0; n = butLastDigit(n))
  {
    sum += lastDigit(n) * *2;
  }

  return sum;
}

function square(n)
{
  return n * n;
}

const base10 = 10;

function lastDigit(n)
{
  return n % base10;
}

function butLastDigit(n)
{
  return quotient(n, base10);
}

function quotient(n, d)
{
  return Math.floor(n / d);
}

  */