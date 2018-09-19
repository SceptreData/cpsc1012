﻿using System;

namespace CPSC1012_Ex03_DavidBergeron
{
  /*
   * Purpose: Display the appropriate letter grade for a percentage score on test.
   * 
   * Input: The student's score as a percent, in a number from (0-100)
   * 
   * Process: Get input from user.
   *          Use if-statements to determine letter grade.
   *
   * Output: The student's letter grade.
   *         
   * Written By: David Bergeron
   * Date Modified: 2018.09.19
   * */
    class Program
    {
        static void Main(string[] args)
        {
            // Get user Input
            Console.WriteLine("Enter student's grade % (0-100):");
            int grade = int.Parse(Console.ReadLine());

            // Store our letter grade in a char.
            char letterGrade;

            // Calculate our letter grade with If statements.
            if (grade > 100)
                letterGrade = 'X';
            else if (grade >= 80)
                letterGrade = 'A';
            else if (grade >= 70)
                letterGrade = 'B';
            else if (grade >= 60)
                letterGrade = 'C';
            else if (grade >= 50)
                letterGrade = 'D';
            else if (grade >= 0)
                letterGrade = 'F';
            else
                letterGrade = 'X';

            // If we have an invalid letter grade, let the user know.
            if (letterGrade == 'X')
                Console.WriteLine("Invalid score entered.");
            else
                Console.WriteLine($"The letter Grade is:  {letterGrade}");
        }
    }
}
