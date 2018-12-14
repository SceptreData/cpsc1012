using System;

namespace CPSC1012_AP_6_DavidBergeron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************");
            Console.WriteLine("* Tic-Tac-Toe Game *");
            Console.WriteLine("********************");
            var game = new TicTacToe();

            Console.WriteLine("The cell numbers for the game are shown below.");
            game.Draw();

            Play(game);
        }

        static void Play(TicTacToe game)
        {
            game.Reset();

            bool playerHasWon = false;
            while (!playerHasWon)
            {
                game.Draw();
                game.PickCell();
                if (game.HasWinner())
                {
                    playerHasWon = true;
                } else
                {
                    game.SwitchPlayer();
                }
            }

            game.Draw();
            Console.WriteLine($"Congratulations! Player {game.CurrentPlayer} wins!");
            char playAgain = PromptYesNo("Would you like to play again (y/n)?  ");

            if (playAgain == 'Y')
            {
                game.Reset();
                Play(game);
            } else
            {
                Console.WriteLine("\nSo long, and thanks for all the fish!");
            }
        }

        static char PromptYesNo(string msg)
        {
            Console.Write(msg);
            ConsoleKeyInfo key = Console.ReadKey();
            char c = char.ToUpper(key.KeyChar);
            Console.WriteLine();

            if (c == 'Y' || c == 'N')
            {
                return c;
            }
            else
            {
                throw new Exception("Must Enter (Y)es or (N)o.");
            }
        }
    }
}
