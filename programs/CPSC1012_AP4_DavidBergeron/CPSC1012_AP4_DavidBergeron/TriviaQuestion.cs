using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP4_DavidBergeron
{

    class TriviaQuestion
    {
        private string mQuestion;
        private List<string> mAnswers = new List<string>();
        private int mCorrectAnswer = -1;

        public string Question
        {
            get => mQuestion;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    mQuestion = value;
                }
                else
                {
                    throw new Exception("Error: Cannot enter blank question value.");
                }
            }
        }

        public List<string> Answers
        {
            get { return mAnswers; }
        }

        public int CorrectAnswer
        {
            get => mCorrectAnswer;
            set
            {
                if (value > 0 && value <= 4)
                {
                    mCorrectAnswer = value;
                }
                else
                {
                    throw new Exception("Error! Correct Answer value must be between 1-4.");
                }
            }
        }

        public TriviaQuestion()
        {
            Question = "Empty Question";
        }

        public TriviaQuestion(string question,
                              string answer1,
                              string answer2,
                              string answer3,
                              string answer4,
                              int correctAnswer)
        {
            Question = question;
            mAnswers.Add(answer1);
            mAnswers.Add(answer2);
            mAnswers.Add(answer3);
            mAnswers.Add(answer4);
            CorrectAnswer = correctAnswer;
        }

        public void SetQuestion(string question)
        {
            Question = question;
        }

        public void AddAnswer(string answer)
        {
            if (Count() < 4)
            {
                mAnswers.Add(answer);
            }
            else
            {
                throw new Exception("Error: Question already has 4 answers.");
            }
        }

        public bool AnswerQuestion(int choice)
        {
            return choice == CorrectAnswer;
        }

        public int Count()
        {
            return mAnswers.Count;
        }
    }
}
