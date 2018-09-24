using System;

namespace CPSC1012_Ex04_DavidBergeron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            bool isLeapYear = false;

            // if year is divisible by 4
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
