using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_6_DavidBergeron
{
    class TicTacToe
    {
        private string[,] _board = new string[3,3];
        private int _winningPlayer = 0;
        private bool _gameOver = false;

        string [,] Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
            }
        }

        public TicTacToe()
        {
            int count = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = count.ToString();
                    count++;
                }
            }
        }

        public void SetCellPosition(int pos, char player)
        {
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                }
            }
        }

        public void Draw()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"|-{Board[2, 0]}-|-{Board[2, 1]}-|-{Board[2,2]}-|");
            Console.WriteLine("-------------");
            Console.WriteLine($"|-{Board[1, 0]}-|-{Board[1, 1]}-|-{Board[1,2]}-|");
            Console.WriteLine("-------------");
            Console.WriteLine($"|-{Board[0, 0]}-|-{Board[0, 1]}-|-{Board[0,2]}-|");
            Console.WriteLine("-------------");
        }
    }
}
