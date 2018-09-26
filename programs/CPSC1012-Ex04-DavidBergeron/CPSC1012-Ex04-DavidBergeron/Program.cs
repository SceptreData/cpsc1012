using System;

namespace CPSC1012_Ex04_DavidBergeron
{
    class Program
    {
       /*
       * Purpose: Determine whether or not a year is a leap year
       * 
       * Input: the year in question.
       * 
       * Process: Get input from user.
       *          Use logical operators to determine whether a year is a leap year.
       *
       * Output: Whether the year is a leap year.
       *         
       * Written By: David Bergeron
       * Date Modified: 2018.09.26
       * */
        static void Main(string[] args)
        {
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            bool isLeapYear = false;

            // if year is divisible by 4 AND the year is not divisible by 100
            // OR the year is divisible by 400.
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                isLeapYear = true;
            }

            if (isLeapYear)
            {
                Console.WriteLine($"{year} is a leap year!");
            } else {
                Console.WriteLine($"{year} is NOT a leap year.");
            }
        }
    }
}
