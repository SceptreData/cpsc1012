using System;
using System.IO;
using System.Collections.Generic;

namespace CPSC1012_AP4_DavidBergeron
{
    class Program
    {/*
    * Purpose:  To Play a Trivia Game, using a database of questions
    *
    * Input: 
    *    - The list of questions (in file format).
    *    - Player Choices
    *    - Menu Selections
    * 
    * Process:
    *      - Read questions from file
    *      - Divide questions between users.
    *      - Check if player has entered correct answer.
    *      - Display the winner of the game.
    *
    * Output:
    *    - Menus
    *    - List of Questions + their answers
    *    - An unholy host of error messages.
    *    - Current Player
    *    - Game Results
    *    - Game Winner
    *         
    * Written By: David Bergeron
    * Date Modified: 2018.12.13
    * */
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            string filePath = desktopPath + @"\triviaList.txt";

            bool programIsRunning = true;

            // Initialize list of Trivia Questions
            List<TriviaQuestion> triviaList = new List<TriviaQuestion>();

            // Check to see if the file exists.
            if (File.Exists(filePath))
            {
                // Load questions to Array
                LoadQuestions(filePath, triviaList);
                // Shuffle Questions
                Shuffle(triviaList);
            } else
            {
                programIsRunning = false;
            }

            // By using an int we save ourself the hassle of dealing with an odd number of questions.
            int numRounds = triviaList.Count / 2;

            // Split up our Questions.
            List<TriviaQuestion> playerOneQuestions = new List<TriviaQuestion>();
            List<TriviaQuestion> playerTwoQuestions = new List<TriviaQuestion>();
            playerOneQuestions = triviaList.GetRange(0, numRounds);
            playerTwoQuestions = triviaList.GetRange(numRounds, numRounds);

            int playerOneScore = 0;
            int playerTwoScore = 0;
           
            while (programIsRunning)
            {
                Console.WriteLine("***************");
                Console.WriteLine("* Trivia Game *");
                Console.WriteLine("***************");
                Console.WriteLine($"There are {triviaList.Count} questions in the question bank. Each player will answer {numRounds} questions");

                int curRound = 1;
                // Ask Player One Questions (?)
                while (curRound <= numRounds)
                {
                    Console.WriteLine("\n\nPlayer 1 Question");
                    Console.WriteLine("_________________");
                    TriviaQuestion tq = playerOneQuestions[curRound - 1];
                    DisplayQuestion(tq);
                    int choice = GetChoice();

                    if (choice == tq.CorrectAnswer)
                    {
                        playerOneScore++;
                    }
                    curRound++;
                }

                curRound = 1; // Reset current round (since players do not alternate).

                // Ask Player Two Question
                while (curRound <= numRounds)
                {
                    Console.WriteLine("\n\nPlayer 2 Question");
                    Console.WriteLine("_________________");
                    TriviaQuestion tq = playerTwoQuestions[curRound - 1];
                    DisplayQuestion(tq);
                    int choice = GetChoice();

                    if (choice == tq.CorrectAnswer)
                    {
                        playerTwoScore++;
                    }
                    curRound++;
                }
                programIsRunning = false;
            }

            // Display Results.
            Console.WriteLine("\n\nFINAL SCORE: ");
            Console.WriteLine($"\tPlayer 1: {playerOneScore}");
            Console.WriteLine($"\tPlayer 2: {playerTwoScore}");
            if (playerOneScore == playerTwoScore)
            {
                Console.WriteLine("\nTie game! You guys are both so good at this!");
            } else
            {
                if (playerOneScore > playerTwoScore)
                {
                    Console.WriteLine("\nCongratulations PLAYER ONE! You WIN!!!");
                } else
                {
                    Console.WriteLine("\nCongratulations PLAYER TWO! You WIN!!!");
                }
            }
        }

        static void DisplayQuestion(TriviaQuestion tq)
        {
            Console.WriteLine(tq.Question);
            Console.WriteLine($"a. {tq.Answers[0]}");
            Console.WriteLine($"b. {tq.Answers[1]}");
            Console.WriteLine($"c. {tq.Answers[2]}");
            Console.WriteLine($"d. {tq.Answers[3]}");
        }

        static int GetChoice()
        {
            int retVal = -1;
            bool validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.Write("Your Answer: ");
                    char c = Console.ReadKey().KeyChar;
                    c = char.ToUpper(c);

                    if (c == 'A' || c == 'B' || c == 'C' || c == 'D')
                    {
                        if (c == 'A') retVal = 1;
                        else if (c == 'B') retVal = 2;
                        else if (c == 'C') retVal = 3;
                        else retVal = 4;
                    }
                    else
                    {
                        throw new Exception("Error: Answer A, B, C or D.");
                    }
                    validInput = true;
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return retVal;
        }

        static void LoadQuestions(string filePath, List<TriviaQuestion> triviaList)
        {
            string line = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
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

        static void Shuffle(List<TriviaQuestion> triviaList)
        {
            Random rnd = new Random();
            for (int i = 0; i < triviaList.Count; i++)
            {
                Swap(triviaList, i, rnd.Next(i, triviaList.Count));
            }
        }

        static void Swap(List<TriviaQuestion> triviaList, int i, int j)
        {
            TriviaQuestion temp = triviaList[i];
            triviaList[i] = triviaList[j];
            triviaList[j] = temp;
        }

        

    }
}
