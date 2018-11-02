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
        static void Main(string[] args)
        {
            int maxStudents = 5;
            int[] grades = new int[maxStudents];

            int numStudents = EnterGrades(grades, maxStudents);

        }


        static int EnterGrades(int[] grades, int max)
        {
            int count = 0;
            for (int i = 0; i <= max; i++)
            {
                int num = 0;
                bool validInput = false;
                while (!validInput)
                {
                    num = GetPositiveInt("Enter Grade: ");
                    if (num == 999 || count == max)
                    {
                        if (count == max)
                        {
                            Console.WriteLine("-----------------------");
                            Console.WriteLine($"The free edition supports a max of {max} grades.");
                            Console.WriteLine("Please Upgrade to a full edition for unlimited number of grades.");
                            Console.WriteLine("-----------------------");
                            Console.WriteLine("Press ANY key to continue.");
                            Console.ReadLine();
                        }
                        return count;
                    }

                    if (num > 100)
                    {
                        Console.WriteLine("Invalid Value: Grade cannot be higher than 100.");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                grades[i] = num;
                count++;
            }
            return count;
        }

        static void SortGradesDescending(int[] grades, int size)
        {
            for (int scanIdx = 0; scanIdx < size - 1; i++)
            {
                int maxIdx = scanIdx;
                for (int i = scanIdx + 1; i < size; i++)
                {
                    if (grades[i] > grades[maxIdx])
                        maxIdx = i;
                }

                if (maxIdx != scanIdx)
                {
                    Swap(grades, scanIdx, maxIdx);
                }
            }
        }

        static void DisplayArray(int[] grades, int size)
        {
            Console.WriteLine("Grades from Highest to Lowest: ");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("\t" + grades[i]);
            }
            Console.WriteLine("Average: " + CalculateAverage(grades, size));
        }

        static double CalculateAverage(int[] grades, int size)
        {
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += (double)grades[i];
            }
            return sum / size;
        }

        static void Swap(int[] arr, int a, int b)
        {
            int tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

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

    }
}
