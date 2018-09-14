using System;

/* Sequential Exercise 4 */
namespace DigitExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = GetNum();

            int sum = 0;
            while (num != 0)
            {
                int digit = num % 10;
                //Console.Write($"Num: {num} Digit: {digit} ");
                sum += digit;
                num /= 10;
            }
            Console.WriteLine($"The sum of the digits is: {sum}");
        }

        static int GetNum()
        {
            Console.WriteLine("Enter a number between 0 and 1000:");
            int num = int.Parse(Console.ReadLine());

            if (num <= 0 || num >= 1000) GetNum();

            return num;
        }
    }
}
