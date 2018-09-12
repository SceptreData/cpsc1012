using System;

namespace AverageVelocity
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1, x2, t1, t2, avgVel;

            Console.WriteLine("Enter points x1 and x2: ");
            x1 = double.Parse(Console.ReadLine());
            x2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter times t1 and t2: ");
            t1 = double.Parse(Console.ReadLine());
            t2 = double.Parse(Console.ReadLine());

            avgVel = (x2 - x1) / (t2 - t1);
            Console.WriteLine($"The average velocity is: {avgVel}");
        }
    }
}
