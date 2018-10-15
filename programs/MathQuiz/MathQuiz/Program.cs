using System;

namespace MathQuiz
{
    class Program
    {

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Math Quiz");
            Console.WriteLine("**********\n");
            Console.WriteLine("A) \tAddition Question");
            Console.WriteLine("S) \tSubtraction Question");
            Console.WriteLine("M) \tMultiplication Question");
            Console.WriteLine("D) \tDivision Question");
            Console.WriteLine("Q) \tQuit");
        }
        
        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Subtract(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Divide(double a, double b)
        {
            return a / b;
        }

        static char GetChoice()
        {
            Console.Write("Please enter a choice: ");
            char c = Char.ToLower(Char.Parse(Console.ReadLine()));
            switch (c)
            {
                case 'a':
                case 's':
                case 'm':
                case 'd':
                case 'q':
                    return c;

                default:
                    Console.WriteLine("Invalid Option.");
                    return GetChoice();
            }
        }

        static double DoThatMath(char c)
        {
            double a, b;
            Console.Write("Enter Number 1: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Enter Number 2: ");
            b = double.Parse(Console.ReadLine());

            if (c == 'a') return Add(a, b);
            if (c == 's') return Subtract(a, b);
            if (c == 'm') return Multiply(a, b);
            else return Divide(a, b);
        }

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                DisplayMenu();
                char c = GetChoice();
                if (c == 'q')
                    running = false;
                else
                {
                    Console.WriteLine("Result is: " + DoThatMath(c));
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Goodbye!");
        }
    }
}
