using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessAgeApp
{
    class GuessAge
    {
        static void Main(string[] args)
        {
            string inString; // for key input val;
            int num;

            // Explain how to compute a "magic" number.
            Console.WriteLine("I can guess your age from a magic number, here's how:");
            Console.WriteLine("  1. Add 21 to your age.");
            Console.WriteLine("  2. Double the result of step 1.");
            Console.WriteLine("  3. Add your age to the result of step 2.");
            Console.WriteLine("  4. Subtract 18 from the result of step 3.");

            // Prompt the user for the magic number and read the number from the keyboard.
            Console.Write("Enter your magic number: ");
            inString = Console.ReadLine();
            num = int.Parse(inString);
        }
    }
}
