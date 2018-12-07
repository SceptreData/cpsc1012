using System;

namespace CPSC1012_AP_6_DavidBergeron
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TicTacToe();
            game.Draw();

            game.Board[0, 0] = 'X';
            game.Board[0, 2] = 'O';
            game.Draw();
        }

        static double GetDouble(string msg)
        {
            try
            {
                Console.Write(msg);
                double num = double.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Invalid Input: Enter a non-negative value.");
                    return GetDouble(msg);
                }
                return num;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input: Enter numbers. ");
                return GetDouble(msg);
            }
        }
    }
}
