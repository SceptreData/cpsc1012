using System;
using System.IO;
using System.Collections.Generic;

namespace CPSC1012_AP_3_DavidBergeron
{/*
    * Purpose:  To build a database file of Trivia Questions
    * 
    * Input: 
    *    - Menu Choices
    *    - Trivia Questions
    *    - The answers for those trivia questions.
    * 
    * Process:
    *      - Read existing questions from a file.
    *      - Add or Delete Questions from the file.
    *      - Save questions to the file when we exit.
    *
    * Output:
    *    - Menus
    *    - List of Questions + their answers
    *    - An unholy host of error messages.
    *         
    * Written By: David Bergeron
    * Date Modified: 2018.12.13
    * */
    class Program
    {
        static void Main(string[] args)
        {
            // BEWARE. I Am saving this stuff right to your desktop!
            string desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            string filePath = desktopPath + @"\triviaList.txt";

            // Initialize list of Trivia Questions
            List<TriviaQuestion> triviaList = new List<TriviaQuestion>();

            // Check to see if the file exists.
            if (File.Exists(filePath))
            {
                LoadQuestions(filePath, triviaList);
            }

            bool programIsRunning = true;
            while (programIsRunning)
            {
                DrawMenu();
                int menuChoice = (int)GetDouble("Your Choice: ", 4);
                switch (menuChoice)
                {
                    case 1:
                        ListTriviaItems(triviaList);
                        break;
                    case 2:
                        AddManualTriviaItem(triviaList);
                        break;
                    case 3:
                        DeleteTriviaItem(triviaList);
                        break;
                    case 4:
                        programIsRunning = false;
                        break;

                    default:
                        Console.WriteLine("Error, Invalid menu choice. (How did we get here?)");
                        break;
                }
            }

            // Save our Questions to file!
            if (triviaList.Count > 0)
            {
                SaveQuestions(filePath, triviaList);
            }

            // Exiting the Program
            Console.WriteLine("Goodbye!");
        }

        static void DrawMenu()
        {
            Console.WriteLine("\n******************************");
            Console.WriteLine("* Trivia Game Administration *");
            Console.WriteLine("******************************");
            Console.WriteLine("1.   List Trivia Items");
            Console.WriteLine("2.   Add Trivia Item");
            Console.WriteLine("3.   Delete Trivia Item");
            Console.WriteLine("4.   Quit");
        }

       

        static void LoadQuestions(string filePath, List<TriviaQuestion> triviaList)
        {
            string line = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    // Pray to god that the questions don't include unnecessary semi-colons.
                    string[] data = line.Split(';');

                    TriviaQuestion tq = new TriviaQuestion();
                    tq.Question = data[0];
                    tq.AddAnswer(data[1]);
                    tq.AddAnswer(data[2]);
                    tq.AddAnswer(data[3]);
                    tq.AddAnswer(data[4]);
                    tq.CorrectAnswer = int.Parse(data[5]);

                    triviaList.Add(tq);
                }
            }
        }

        static void SaveQuestions(string filePath, List<TriviaQuestion> triviaList)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (TriviaQuestion tq in triviaList)
                {
                    sw.WriteLine($"{tq.Question};{tq.Answers[0]};{tq.Answers[1]};{tq.Answers[2]};{tq.Answers[3]};{tq.CorrectAnswer}");
                }
            }
            Console.WriteLine($"Saved trivia questions to {filePath}.");
        }

        static void ListTriviaItems(List<TriviaQuestion> triviaList)
        {
            if (triviaList.Count == 0)
            {
                Console.WriteLine("There are currently no items in the database.");
            } else
            {
                int count = 1;
                foreach(TriviaQuestion tq in triviaList)
                {
                    Console.WriteLine($"{count}.    {tq.Question}");
                    for (int i = 0; i < tq.Count(); i++)
                    {
                        Console.WriteLine($"\t{i + 1}.\t {tq.Answers[i]}");
                    }
                    Console.WriteLine($"Current Answer: {tq.CorrectAnswer}\n");
                    count++;
                }
            }
        }

        static void AddManualTriviaItem(List<TriviaQuestion> triviaList)
        {

            // Build a new TriviaQuestion
            TriviaQuestion tq = new TriviaQuestion();

            // Get our trivia question.
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    tq.Question = GetString("Enter the trivia item question: ");
                    validInput = true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Grab the answers for our new question.
            for (int i = 0; i < 4; i++)
            {
                validInput = false;
                while (!validInput)
                {
                    try
                    {
                        Console.WriteLine($"Enter answer #{i + 1}:");
                        string newAnswer = GetString("");
                        tq.AddAnswer(newAnswer);
                        validInput = true;
                    }
                    catch (Exception ex)

                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            // Get Correct Answer
            validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.WriteLine("Enter Correct Answer (1-4): ");
                    tq.CorrectAnswer = int.Parse(Console.ReadLine());
                    validInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            triviaList.Add(tq);
        }

        static void DeleteTriviaItem(List<TriviaQuestion> triviaList)
        {
            if (triviaList.Count == 0)
            {
                Console.WriteLine("List contains no questions to delete\n.");
            }
            else
            {
                DrawDeleteMenu(triviaList);
                int deleteIdx = -1;
                deleteIdx = (int)GetDouble("Enter the item number to delete: ", triviaList.Count);
                triviaList.RemoveAt(deleteIdx - 1);
                Console.WriteLine($"Item #{deleteIdx} has been deleted from database.\n");
            }
        }

        static void DrawDeleteMenu(List<TriviaQuestion> triviaList)
        {
            Console.WriteLine($"{"Item #", -10}{"Question", -40}");
            Console.WriteLine($"{"------", -10}{"--------------------", -40}");
            for (int i = 0; i < triviaList.Count; i++)
            {
                TriviaQuestion tq = triviaList[i];
                Console.WriteLine($"{i+1, -10}{tq.Question, -40}");
            }
        }
        
        static double GetDouble(string msg)
        {
            try
            {
                Console.Write(msg);
                double num = double.Parse(Console.ReadLine());
                if (num <= 0)
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

        static double GetDouble(string msg, double max)
        {
            double num = GetDouble(msg);
            while (num > max)
            {
                Console.WriteLine($"Error: Number entered is higher than Max value ({max})");
                num = GetDouble(msg);
            }
            return num;
        }

        static string GetString(string msg)
        {
            Console.Write(msg);
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str)) {
                throw new Exception("Error: empty string.");
            }
            return str;
        }

    }
}
