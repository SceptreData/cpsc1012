using System;

namespace PollutionIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            const double CUTOFF = 50.0;
            double level1,
                   level2,
                   level3,
                   index;

            Console.WriteLine("Enter 3 Pollution level readings:");
            level1 = double.Parse(Console.ReadLine());
            level2 = double.Parse(Console.ReadLine());
            level3 = double.Parse(Console.ReadLine());

            index = (level1 + level2 + level3) / 3;

            // Check for hazardous condition.
            if (index >= CUTOFF)
                Console.WriteLine("HAZARDOUS CONDITION!!1");
            else
                Console.WriteLine("Nah it's safe.");
        }
    }
}
