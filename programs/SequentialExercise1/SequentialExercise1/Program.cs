using System;

namespace SequentialExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Don Iveson";
            int age = 45;
            double annualPay = 204747;

            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your annual salary:");
            annualPay = double.Parse(Console.ReadLine());
            string payString = $"{annualPay,0:F2}"; // annualPay.ToString("F2");

            // In string interpolation, format strings like this: {var:format}

            Console.WriteLine($"My name is {name}, my age is {age} " +
                              $"and I hope to earn {annualPay:C} per year.");
        }
    }
}
