using System;

namespace DiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Die(20);
            int numRolls = 10;
            for (int i = 0; i < numRolls; i++)
            {
                Console.WriteLine("Value: " + d.Value);
                d.Roll();
            }
        }
    }
}
