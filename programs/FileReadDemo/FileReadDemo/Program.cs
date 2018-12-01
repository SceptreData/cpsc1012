using System;
using System.IO;

namespace FileReadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get Filename
            Console.Write("Enter Filename: ");
            //string fname = Console.ReadLine();
            string fname = @"C:\intel\test.txt";

            // check if File exists
            if (File.Exists(fname))
            {
                Console.WriteLine("CurrentDirectory: " + Environment.CurrentDirectory);
                Console.WriteLine("SystemDirectory: " + Environment.SystemDirectory);
                Console.WriteLine("TempDirectory: " + Environment.GetEnvironmentVariable("TEMP"));

                StreamReader reader = new StreamReader(fname);

                // Write our file data to the screen.
                string curLine;
                while ( (curLine = reader.ReadLine()) != null)
                {
                    Console.WriteLine(curLine);
                }

                // Close our reader object.
                reader.Close();
            }
            else
            {
                Console.WriteLine($"The filename {fname} does not exist.");
            }

        }
    }
}
