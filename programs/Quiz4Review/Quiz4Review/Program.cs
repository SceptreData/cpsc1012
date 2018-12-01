using System;
using System.Collections.Generic;

namespace Quiz4Review
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Lets make some arrays */
            string[] names = new string[25];
            double[] grades = new double[25];

            /* Lets make a list! */
            List<Student> students = new List<Student>();
            

            string bestStudent = "";
            double bestGrade = -1;
            double sum = 0;

            for (int i = 0; i < names.Length; i++)
            {
                if (grades[i] > bestGrade)
                {
                    bestGrade = grades[i];
                    bestStudent = names[i];
                }
                sum += grades[i];
            }

            double avg = sum / grades.Length;

            for (int i=0; i < names.Length; i++)
            {
                Console.WriteLine($"{names[i]}: {grades[i]}");
            }
        }
    }
}
