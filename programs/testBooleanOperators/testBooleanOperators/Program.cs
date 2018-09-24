using System;

namespace testBooleanOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt for and read in an integer
            Console.WriteLine("Enter an integer:");
            int num = int.Parse(Console.ReadLine());

            // Display message if number is divisible by 2 and 3.
            if (num % 2 == 0 && num % 3 == 0)
            {
                Console.WriteLine($"{num} is divisible by 2 and 3.");
            }
            if (num % 2 == 0 || num % 3 == 0)
            {
                Console.WriteLine($"{num} is divisible by 2 OR 3.");
            }

            if (num % 2 == 0 ^ num % 3 == 0)
            {
                Console.WriteLine($"{num} is divisible by 2 XOR 3.");
            }
        }
    }
}
