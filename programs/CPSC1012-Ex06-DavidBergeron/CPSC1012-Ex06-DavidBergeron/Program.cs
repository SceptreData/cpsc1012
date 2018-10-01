using System;

namespace CPSC1012_Ex06_DavidBergeron
{ /*
   * Purpose: Calculate the highest, lowest and average grades for a class of students.
   * 
   * Input: 
   *    - Number of Students
   *    - A particular student's marks.
   * 
   * Process:  
   *    - Current Student's Mark (curMark)
   *    - Overall lowest Mark Recorded (minMark)
   *    - Overall Highest Mark (maxMark)
   *    - Sum of all students marks
   *    - Average Mark
   *
   * Output: Display Highest Mark
   *         Display Lowest Mark
   *         Display Average Mark
   *         
   * Written By: David Bergeron
   * Date Modified: 2018.10.01
   * */
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents;
            double curMark;
            double minMark = 101;
            double maxMark = -1;
            double sumOfMarks = 0;
            double avgMark;

            Console.Write("Enter number of students: ");
            numStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numStudents; i++)
            {
                Console.Write($"Enter mark for student #{i + 1}: ");
                curMark = double.Parse(Console.ReadLine());
                if (curMark < minMark)
                {
                    minMark = curMark;
                }
                if (curMark > maxMark)
                {
                    maxMark = curMark;
                }

                sumOfMarks += curMark;
            }

            avgMark = sumOfMarks / numStudents;
            Console.WriteLine($"\nAverage Mark: {avgMark}, Highest Mark: {maxMark}, Lowest Mark: {minMark}");
        }
    }
}
