using System;

namespace RepeatAdditionQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate two random numbers between 1 and 9
            Random keygen = new Random();
            int num1 = keygen.Next(1, 10);
            int num2 = keygen.Next(1, 10);

            int answer = 0;
            int attempts = 0;
            // Ask the user for the sum of the two numbers
            while (answer != num1 + num2 && attempts < 5)
            {
                Console.WriteLine($"You have {5 - attempts} remaining.");
                Console.WriteLine($"{num1} + {num2} = ???");
                Console.Write("Enter the sum of the two numbers: ");
                answer = int.Parse(Console.ReadLine());
                attempts++;
            }

            if (answer == num1 + num2)
            {
                Console.WriteLine("Way to go buddy!");
            } else
            {
                Console.WriteLine("Please learn to math.");
            }

            // If the answer is not correct, ask the user for the answer again.
        }
    }
}
