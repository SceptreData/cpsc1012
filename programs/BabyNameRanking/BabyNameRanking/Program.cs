using System;
using System.Collections.Generic; // For List Class
using System.IO;                  // For StreamReader and StreamWriter

namespace BabyNameRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new List<BabyName>();
            var females = new List<BabyName>();

            string filePath = @"C:\temp\yob2016.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"The file at {filePath} does not exist.");
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] data = line.Split(',');
                            string name = data[0];
                            char gender = char.Parse(data[1]);
                            int count = int.Parse(data[2]);

                            var newBaby = new BabyName(name, gender, count);
                            if (newBaby.Gender == 'M')
                            {
                                males.Add(newBaby);
                            } else
                            {
                                females.Add(newBaby);
                            }
                        }
                    }
                    Console.WriteLine("Number of Males: " + males.Count);
                    Console.WriteLine("Number of Females: " + females.Count);

                    // Get Name / Gender
                    Console.Write("Enter Name to Search for: ");
                    var searchName = Console.ReadLine();

                    Console.Write("Enter Gender (M/F): ");
                    var searchGender = char.Parse(Console.ReadLine());

                    var babyList = (char.ToUpper(searchGender) == 'M') ? males : females;
                    int babyRank = -1;

                    BabyName theBaby = FindName(searchName, babyList);
                    babyRank = FindRank(searchName, babyList);

                    
                    Console.WriteLine($"name: {theBaby.Name} \t Count: {theBaby.Count}");
                    Console.WriteLine("Rank: " + babyRank);

                } catch (Exception e)
                {
                    Console.WriteLine("The file could not be read: ");
                    Console.WriteLine(e.Message);
                }

            }

        }

        static BabyName FindName(string name, List <BabyName> babies)
        {
            return babies.Find(theBaby => theBaby.Name == name);
        }

        static int FindRank (string name, List<BabyName> babies)
        {
            int eltIdx = -1;
            for (int i = 0; i < babies.Count; i++)
            {
                if (babies[i].Name == name)
                {
                    eltIdx = i;
                    break;
                }
            }
            return eltIdx + 1;
        }

        static double GetDouble(string msg)
        {
            try
            {
                Console.Write(msg);
                double num = double.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Invalid Input: Enter a non-negative value.");
                    return GetDouble(msg);
                }
                return num;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input: Enter numbers. ");
                return GetDouble(msg);
            }

        }
    }
}
