using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz4Review
{
    class Student
    {
        private string mName = "No Name";
        private double mGrade = 0;

        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public double Grade
        {
            get => mName;
            set
            {
                if (value < 0)
                    throw new Exception("Grade must be positive value.");
                else
                {
                    mGrade = value;
                }
            }
        }

        public Student() { }

        public Student(string name, double grade)
        {
            Name = name;
            Grade = grade;
        }

        public bool IsPassing()
        {
            return Grade > 50;
        }

    }
}
