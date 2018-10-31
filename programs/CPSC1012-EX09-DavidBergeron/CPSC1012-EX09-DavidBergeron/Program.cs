using System;

namespace CPSC1012_EX09_DavidBergeron
{
    class Program
    {
        /*
         * Enter Grades
         * populates a passed array with grade values.
         * Max = Length of Array.
         * returns how many grades were entered
         */

        static int GetPositiveInt(string msg)
        {
            try
            {
                Console.Write(msg);
                int num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Invalid Input: Enter a non-negative value.");
                    return GetPositiveInt(msg);
                }
                return num;
            } catch(Exception ex)
            {
                Console.WriteLine("Invalid Input: Enter numbers. ");
                return GetPositiveInt(msg);
            }

        }

        static int GetPositiveInt(string msg, int max)
        {
            int num = GetPositiveInt(msg);
            if (num > max)
            {
                Console.WriteLine($"Invalid Value: Enter number lower than {max}.");
                GetPositiveInt(msg, max);
            }
            return num;
        }

        static int EnterGrades(int[] grades, int max)
        {
            int count = 0;
            for (int i = 0; i < max; i++)
            {
                bool invalidInput = true;
                while (invalidInput)
                {
                    int num = GetPositiveInt("Enter Grade: ");
                    if (num == 999)
                    {
                        return count;
                    }

                    if (num > 100)
                    {
                        Console.WriteLine("Invalid Value: Grade cannot be higher than 100.");
                    } else
                    {
                        invalidInput = false;
                        grades[i] = num;
                        count++;
                    }
                }
            }
            return count;
        }

        static void SortGradesDescending(int[] grades, int size)
        {
            for (int sortIdx = 0; sortIdx < size - 1; sortIdx++)
            {
                int maxIdx = sortIdx;
                for (int curIdx = sortIdx + 1; curIdx < size; curIdx++)
                {
                    if (grades[curIdx] > grades[maxIdx])
                    {
                        maxIdx = curIdx;
                    }

                    if (maxIdx != sortIdx)
                    {
                        Swap(grades, maxIdx, sortIdx);
                    }
                }
            }
        }

        static double CalculateAverage(int[] grades, int size)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += grades[i];
            }
            return sum / size;
        }

        static void Swap(int[] arr, int a, int b)
        {
            int tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        static void DisplayArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\t{arr[i]}");
            }
        }

        static void Main(string[] args)
        {
            int size = 5;
            int[] studentGrades = new int[size];
            EnterGrades(studentGrades, 5);
            DisplayArray(studentGrades, 5);

            Console.WriteLine("\nGrades Sorted:");
            SortGradesDescending(studentGrades, 5);
            DisplayArray(studentGrades, 5);

            double avg = CalculateAverage(studentGrades, 5);
            Console.WriteLine($"Average: {avg}");
        }
    }
}
