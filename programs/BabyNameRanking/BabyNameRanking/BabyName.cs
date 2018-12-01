using System;
using System.Collections.Generic;
using System.Text;

namespace BabyNameRanking
{
    class BabyName
    {
        private string _name = "Not Initialized.";
        private char _gender = 'F';
        private int _count = 0;

        // Property declarations

        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Baby Name Must contain a string.");
                }
            }
        }

        public char Gender
        {
            get => char.ToUpper(_gender);
            set
            {
                char c = char.ToUpper(value);
                if (c == 'M' || c == 'F')
                {
                    _gender = value;
                }
                else
                {
                    throw new Exception("Gender not valid.");
                }
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Count must be >= 0.");
                }
                else
                {
                    _count = value;
                }
            }
        }

        public BabyName(string name, char gender, int count)
        {
            try
            {
                this.Name = name;
                this.Gender = gender;
                this.Count = count;
            } catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
