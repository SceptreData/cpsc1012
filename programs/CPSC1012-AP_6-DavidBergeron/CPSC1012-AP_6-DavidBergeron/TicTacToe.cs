using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_6_DavidBergeron
{
    public class TicTacToe
    {
        private char[,] _board = new char[3,3];
        private char _currentPlayer = 'X';

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

        public void Reset()
        {
            ClearBoard();
            CurrentPlayer = 'X';
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

        public void PickCell()
        {
            bool validMove = false;
            while (!validMove)
            {
                try
                {
                    int pos = (int)GetDouble($"Enter cell number (1-9) for player {CurrentPlayer}: ", 9);
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
                    validMove = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }

        public bool HasWinner()
        {
            return (CheckRows(CurrentPlayer) || CheckColumns(CurrentPlayer) || CheckDiagonals(CurrentPlayer));
        }

        bool CheckRows(char player)
        {
            bool hasWon = false;
            if (Board[0, 0] == player && Board[0,1] == player && Board[0,2] == player)
            {
                hasWon = true;
            }
            else if (Board[1, 0] == player && Board[1,1] == player && Board[1,2] == player)
            {
                hasWon = true;
            }
            else if (Board[1, 0] == player && Board[1,1] == player && Board[1,2] == player)
            {
                hasWon = true;
            }
            return hasWon;
        }

        bool CheckColumns(char player)
        {
            bool hasWon = false;
            if (Board[0, 0] == player && Board[1,0] == player && Board[2,0] == player)
            {
                hasWon = true;
            }
            else if (Board[0, 1] == player && Board[1,1] == player && Board[2,1] == player)
            {
                hasWon = true;
            }
            else if (Board[0, 2] == player && Board[1,2] == player && Board[2,2] == player)
            {
                hasWon = true;
            }
            return hasWon;
        }

        bool CheckDiagonals(char player)
        {
            bool hasWon = false;
            /* Bottom Left to Top Right */
            if (Board[0, 0] == player && Board[1,1] == player && Board[2,2] == player)
            {
                hasWon = true;
            }
            /* Top Left to Bottom Right */
            else if (Board[2, 0] == player && Board[1,1] == player && Board[0,2] == player)
            {
                hasWon = true;
            }
            return hasWon;
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
            Console.WriteLine("\n-------------");
            Console.WriteLine($"| {Board[2, 0]} | {Board[2, 1]} | {Board[2,2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[1, 0]} | {Board[1, 1]} | {Board[1,2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[0, 0]} | {Board[0, 1]} | {Board[0,2]} |");
            Console.WriteLine("-------------");
        }

        static double GetDouble(string msg)
        {
            try
            {
                Console.Write(msg);
                double num = double.Parse(Console.ReadLine());
                if (num <= 0)
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

        static double GetDouble(string msg, double max)
        {
            double num = GetDouble(msg);
            while (num > max)
            {
                Console.WriteLine($"Error: Number entered is higher than Max value ({max})");
                num = GetDouble(msg);
            }
            return num;
        }

    }
}
