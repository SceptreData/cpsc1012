using System;
using System.IO;

namespace FileWriteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string fname;
            string friendId;
            int numFriends;

            // Get number of friends
            Console.Write("How many friends do you have?! ");
            numFriends = int.Parse(Console.ReadLine());

            // Get the filename
            Console.Write("Enter the filename: ");
            fname = Console.ReadLine();

            try
            {
                StreamWriter writer = new StreamWriter(fname, false);
                for(int i = 1; i <= numFriends; i++)
                {
                    Console.Write($"Enter name of friend #{i}: ");
                    friendId = Console.ReadLine();

                    // Write friend name to file.
                    writer.WriteLine(friendId);
                }
                writer.Close();
                Console.WriteLine($"Data written to the file {fname}.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
