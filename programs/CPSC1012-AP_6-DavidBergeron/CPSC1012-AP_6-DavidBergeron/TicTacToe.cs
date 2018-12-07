using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_6_DavidBergeron
{
    class TicTacToe
    {
        private char[,] _board = new char[3,3];
        private int _winningPlayer = 0;
        private bool _gameOver = false;

        private char _currentPlayer;

        public char[,] Board
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

        public char CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                char c = Char.ToUpper(value);
                if (c == 'X' || c == 'O')
                    _currentPlayer = c;
                else
                    throw new Exception("Current Player must be an 'X' or an 'O'");
            }
        }

        public TicTacToe()
        {
            int count = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = count.ToString()[0];
                    count++;
                }
            }
        }

        public void StartGame()
        {
            ClearBoard();
            CurrentPlayer = 'X';
        }

        public void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = ' ';
                }
            }
        }

      


        public bool CellIsOpen(int x, int y)
        {
            return Board[x, y] == ' ';
        }

        public bool IsFull()
        {
            bool boardIsFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (CellIsOpen(i, j))
                        boardIsFull = false;
                }
            }

            return boardIsFull;
        }

        public void SetCell(int x, int y)
        {
            if (CellIsOpen(x, y))
            {
                Board[x, y] = CurrentPlayer;
            }
            else
            {
                throw new Exception("That space is already occupied!");
            }
        }

        public bool PickCell(int pos)
        {

            bool moveWasSuccess = false;
            switch (pos)
            {
                case 1:
                    SetCell(0, 0);
                    break;

                case 2:
                    SetCell(0, 1);
                    break;
                case 3:
                    SetCell(0, 2);
                    break;
                case 4:
                    SetCell(1, 0);
                    break;
                case 5:
                    SetCell(1, 1);
                    break;
                case 6:
                    SetCell(1, 2);
                    break;
                case 7:
                    SetCell(2, 0);
                    break;
                case 8:
                    SetCell(2, 1);
                    break;
                case 9:
                    SetCell(2, 2);
                    break;

                default:
                    throw new Exception("Trying to access invalid Cell. Choose from (1-9)");
            }

            SwitchPlayer();
            return true;
        }

        public void SwitchPlayer()
        {
            if (CurrentPlayer == 'X')
                CurrentPlayer = 'O';
            else
                CurrentPlayer = 'X';
        }

        public void Draw()
        {
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[2, 0]} | {Board[2, 1]} | {Board[2,2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[1, 0]} | {Board[1, 1]} | {Board[1,2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[0, 0]} | {Board[0, 1]} | {Board[0,2]} |");
            Console.WriteLine("-------------");
        }
    }
}
