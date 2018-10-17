using System;

namespace CPSC1012_Ex08_DavidBergeron
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = GetNumber("Enter the number of rows: ");
            Console.Write("Enter the Draw Character: ");

            char c = char.Parse(Console.ReadLine());
            DrawTriangle(5);
            DrawTriangle(num, c);
        }

        static int GetNumber(string msg)
        {
            bool validInput = false;
            int num = 0;

            while (!validInput)
            {
                Console.Write(msg);
                try
                {
                    num = int.Parse(Console.ReadLine());

                    if (num > 0)
                        validInput = true;
                    else
                    {
                        Console.WriteLine("Invalid Input. Number must be bigger than zero.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Input value, not a number. Enter a number.");
                }
            }
            return num;
        }

        static void DrawTriangle(int rows)
        {
            char c = '*';
            for (int i = 1; i <= rows; i++)
            {
                DrawRow(i, c);
            }
        }
       
        static void DrawTriangle(int rows, char drawChar)
        {
            for (int i = 1; i <= rows; i++)
            {
                DrawRow(i, drawChar);
            }
        }

        static void DrawRow(int len, char c)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write(c);
            }
            Console.Write("\n");
        }
    }
}
