using System;

namespace SequentialExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*Hexagon Area Solver*\n");
            Console.WriteLine("Enter the length of the side:");

            double length = double.Parse(Console.ReadLine());
            double area = ((3 * Math.Sqrt(3)) / 2) * Math.Pow(length, 2);
            Console.WriteLine($"The area of the hexagon is {area:F4}");
        }
    }
}