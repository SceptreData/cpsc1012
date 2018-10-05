using System;

namespace CPSC1012_Ex07_DavidBergeron
{ /*
   * Purpose: 
   *    - Calculate the highest, lowest and average grades for a class of students,
   *      while handling invalid inputs.
   * 
   * Input: 
   *    - A particular student's mark.
   *    - Escape Event.
   * 
   * Process:  
   *    - Current Student's Mark (curMark)
   *    - Overall lowest Mark Recorded (minMark)
   *    - Overall Highest Mark (maxMark)
   *    - Sum of all students marks
   *    - Average Mark
   *
   * Output: 
   *    - Display Highest Mark
   *    - Display Lowest Mark
   *    - Display Average Mark
   *    - Display Error message if necessary
   *         
   * Written By: David Bergeron
   * Date Modified: 2018.10.01
   * */
    class Program
    {
        static void Main(string[] args)
        {

            double curMark = -1;
            do
            {
                // Initialize Min/Max to invalid values
                int numStudents = 0;
                double minMark = 101;
                double maxMark = -1;
                double sumOfMarks = 0;
                double avgMark = -1;

                Console.WriteLine("Enter grade to start NEW CLASS or 999 to QUIT.");
                Console.Write("Enter Grade: ");
                curMark = double.Parse(Console.ReadLine());

                while (curMark != 999)
                {
                    // Check for valid input.
                    if (curMark < 0 || curMark > 100)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    else
                    {
                        // Add a student
                        numStudents++;
                        // Is this the highest or lowest mark we've seen?
                        if (curMark < minMark)
                        {
                            minMark = curMark;
                        }
                        if (curMark > maxMark)
                        {
                            maxMark = curMark;
                        }
                        // Add the mark to our running total for the avg.
                        sumOfMarks += curMark;
                    }
                    Console.Write("Enter Grade: ");
                    curMark = double.Parse(Console.ReadLine());
                }

                if (numStudents > 0)
                {
                    avgMark = (double)sumOfMarks / numStudents;
                    Console.WriteLine($"\nCLASS SIZE: {numStudents}");
                    Console.WriteLine($"Average Mark: {avgMark}, Highest Mark: {maxMark}, Lowest Mark: {minMark}\n");
                    curMark = -1;
                }
            } while (curMark != 999);
        }
    }
}
