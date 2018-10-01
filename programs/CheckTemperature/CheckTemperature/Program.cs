using System;

namespace CheckTemperature
{
    class Program
    {
        // This program assists a technician in the process
        // of cjeclomg a substance's temperature.
        static void Main(string[] args)
        {
            const double maxTemp = 39.2; // MAX TEMP in C

            // Get current temperature.

            // As long as necessary, instruct the technician to adjust temperature.

            Console.Write("Please enter new temperature: ");
            double curTemp = double.Parse(Console.ReadLine());

            while (curTemp > maxTemp)
            {
                Console.WriteLine($"Warning! Temp: {curTemp}C is too high. Decrease by {curTemp - maxTemp}");
                Console.Write("Please enter new temperature: ");
                curTemp = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Phew! You did it! Got those temperatures under control!");
        }
    }
}
