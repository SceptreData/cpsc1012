using System;

namespace SequentialExercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Investment Amount:");
            double investAmt = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter annual interest rate in percentage:");
            double interestRate = double.Parse(Console.ReadLine());
            double monthlyInterest = interestRate / 12 / 100;

            Console.WriteLine("Enter Number of years:");
            int numYears = int.Parse(Console.ReadLine());

            double futureVal = investAmt * Math.Pow(1 + monthlyInterest, numYears * 12);

            Console.WriteLine($"Future Value is {futureVal:C}");
        }
    }
}
