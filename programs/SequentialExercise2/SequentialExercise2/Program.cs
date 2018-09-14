using System;

namespace SequentialExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            float radius;
            float length;
            float area;
            float volume;

            Console.WriteLine("Enter the Radius and Length of a cylinder:");
            radius = float.Parse(Console.ReadLine());
            length = float.Parse(Console.ReadLine());

            area = radius * radius * (float)Math.PI;
            volume = area * length;

            Console.WriteLine($"The area is {area:F4}");
            Console.WriteLine($"The volume is {volume:F1}");
        }
    }
}
