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

            Console.WriteLine("***************");
            Console.WriteLine("* Trivia Game *");
            Console.WriteLine("***************");
            Console.WriteLine($"There are {triviaList.Count} questions in the question bank. Each player will answer {numRounds} questions");

            int playerOneScore = 0;
            int playerTwoScore = 0;
            int curRound = 1;

            while (programIsRunning)
            {
                // Ask Player One Question.

                // Ask Player Two Question

                // Advance the game.
                curRound++;
                if (curRound > numRounds)
                {
                    programIsRunning = false;
                }
            }

            // Display Results.
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
