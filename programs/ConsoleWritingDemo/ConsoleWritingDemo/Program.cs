using System;

namespace ConsoleWritingDemo
{
    /* Demonstrate various usage of the WriteLine and 
     * Write method */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programming is Fun!");
            Console.WriteLine("I just can't get enough of it.");

            // The Console.Write function does not insert new line characters.
            Console.Write("Programming is ");
            Console.Write("FUN.\n");

            /*
             * We use ESCAPE-CHARACTERS to represent special or otherwise
             * untypeable symbols inside our strings. Escape characters are
             * preceded by a BACKSLASH '\' .
             */
            Console.WriteLine("My real name is \"BARACK OBAMA\".");

            Console.Write("\nThese are our top sellers:\n");
            Console.Write("\tApples\n" +
                          "\tBananas\n" +
                          "\tShotguns\n"
            );
        }
    }
}
