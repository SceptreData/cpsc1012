using System;

namespace CupConverter
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static double GetPositiveDouble(string msg)
        {
            double doubleVal = 1;
            bool validInput = false;

            Console.WriteLine(msg);
            doubleVal = double.Parse(Console.ReadLine());

            if (doubleVal > 0)
                validInput = true;
            else
            {
                Console.WriteLine("Invalid Input Value. TRY AGAIN.");
            }

            return doubleVal;
        }
    }
}
