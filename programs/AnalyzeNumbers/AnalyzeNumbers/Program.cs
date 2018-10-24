using System;

namespace AnalyzeNumbers
{
    /* This program prompts for the number of items
     * and stores each item into an array. Then it calculates the 
     * average of all items.
     */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tNumber Analyzer\n");
            Console.Write("Enter number of items: ");
            int size = int.Parse(Console.ReadLine());

            double[] arr = new double[size];
            double sum = 0;

            // Get Each number for the array from the user.
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter a number: ");
                arr[i] = double.Parse(Console.ReadLine());
                sum += arr[i];
            }

            double avg = sum / size;
            Console.WriteLine($"Num Elements: {size} Average: {avg}");

            double min = arr[0];
            double max = arr[0];

            double bigCount = 0;
            for (int i = 0; i < size; i++)
            {
                if (arr[i] > avg)
                    bigCount++;
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }
            Console.WriteLine($"Number of Elements larger than average: {bigCount}");
            Console.WriteLine($"MaxElt: {max} minElt: {min}");
        }
    }
}
