using System;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate a random number between 1 and 100.
            Random rnd = new Random();
            int num = rnd.Next(1, 101);

            // Ask the user to guess the number until it is correct.
            // for each guess indicate if guess is "too high" "too low" or "correct".

            int guess;
            int numAttempts = 0;
            int MAX_ATTEMPTS = 5;
            bool guessNotCorrect = true;

            while (guessNotCorrect && numAttempts < MAX_ATTEMPTS)
            {
                Console.WriteLine($"You have {MAX_ATTEMPTS - numAttempts} remaining.");
                Console.Write("Guess a number (1-100): ");
                guess = int.Parse(Console.ReadLine());
                numAttempts++;

                if (guess < num)
                {
                    Console.WriteLine("Too Low!");
                }
                else if (guess > num)
                {
                    Console.WriteLine("Too high!");
                } else {
                    guessNotCorrect = false;
                }
            }

            if (guessNotCorrect)
            {
                Console.WriteLine($"You ran out of tries! Number was {num}.");
            } else {
                Console.WriteLine("Hooray! You got the number!");
            }
        }
    }
}
