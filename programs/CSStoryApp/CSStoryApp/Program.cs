using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStoryApp
{
    class CSStory 
    {
        static void Main(string[] args)
        {
            string firstName; // User's first name

            Console.WriteLine();
            Console.WriteLine("Electronic messages use the symbol :-) to indicate a funny comment.\n" +
                              "The :-) symbol is called a 'smiley'. Look at it sideways and you'll\n" +
                              "see why.");


            /* The story of C# */
            Console.WriteLine("The name C# was inpired by musical notation where a sharp indicates\n" +
                              "that the written note should be made a semitone higher in pitch.\n" +
                              "This is similar to the language name C++, where \"++\" indicates that a\n" +
                              "variable should be incremented by 1. The sharp symbol also resembles a \n" +
                              "ligature for four \"+\" symbols (in a two-by-two grid), further \n" +
                              "implying that the language is an increment of C++.");

            Console.WriteLine();
            Console.WriteLine("Due to technical limitations to display and the fact that the sharp\n" +
                              "symbol is not present on the standard keyboard, the number sign (#)\n" +
                              "was chosen to represent the sharp symbol in the written name of the\n" +
                              "programming language.");

            /* Get User's name and display Personalized Message */
            Console.WriteLine();
            Console.Write("Enter your first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("When you've finished this course, and you are NEW AND IMPROVED,\n " +
                              "people may call you " + firstName + "#. :-)");

                   }
    }
}
