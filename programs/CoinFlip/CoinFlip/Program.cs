using System;

namespace CoinFlip
{
    class Program
    {
        enum Side { HEADS, TAILS };

        static void Main(string[] args)
        {
            Console.WriteLine("COIN FLIPPER 10,000");
            Console.WriteLine("Enter 0 for Heads, 1 for Tails:");
            Side userGuess = (Side)Enum.Parse(typeof(Side), Console.ReadLine());

            Random rnd = new Random();
            Side coinResult = (Side) rnd.Next(0, 1);

            if (coinResult == userGuess)
                Console.WriteLine("You got it baby!");
            else Console.WriteLine("DID IT.");
        }
    }
}
