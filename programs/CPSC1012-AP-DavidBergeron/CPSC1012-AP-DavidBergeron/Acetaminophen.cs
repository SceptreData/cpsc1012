using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_DavidBergeron
{
    class Acetaminophen
    {
        private int _age = 2;
        private double _weight = 24;

        public int Age
        {
            get => _age;
            set
            {
                if (value < 2 || value > 11)
                {
                    throw new Exception("Age must be within range of 2-11.");
                }
                else
                {
                    _age = value;
                }
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value < 24 || value > 95)
                {
                    throw new Exception("Weight must be between 24-95.");
                }
                else
                {
                    _weight = value;
                }
            }
        }

        public Acetaminophen() { }

        public Acetaminophen(int age, double weight)
        {
            Age = age;
            Weight = weight;
        }

        public double LiquidDosageByWeight()
        {
            double dosage = -1;

            if (Weight >= 24 && Weight <= 35) { dosage =  5; }
            else if (Weight >= 36 && Weight <= 47) { dosage = 7.5; }
            else if (Weight >= 24 && Weight <= 59) { dosage = 10; }
            else if (Weight >= 24 && Weight <= 71) { dosage = 12.5; }
            else if (Weight >= 72) { dosage =  15; }

            return dosage;
        }
        
        public double LiquidDosageByAge()
        {
            double dosage = -1;

            if (Age >= 2 && Age <= 3) { dosage =  5; }
            else if (Age >= 4 && Age <= 5) { dosage = 7.5; }
            else if (Age >= 6 && Age <= 8) { dosage = 10; }
            else if (Age >= 9 && Age <= 10) { dosage = 12.5; }
            else if (Age == 11) { dosage =  15; }

            return dosage;
        }

        public void GetWeight()
        {
            bool valid = false;
            double weight;
            do
            {
                Console.Write("Enter Weight: ");
                valid = double.TryParse(Console.ReadLine(), out weight);
                if (weight < 24 || weight > 95)
                {
                    valid = false;
                    Console.WriteLine("Weight must be between 24-95.");
                }
            } while (!valid);
            Weight = weight;
        }

        public void GetAge()
        {
            bool valid = false;
            int age;
            do
            {
                Console.Write("Enter Age: ");
                valid = int.TryParse(Console.ReadLine(), out age);
                if (age < 2 || age > 11)
                {
                    valid = false;
                    Console.WriteLine("Age must be between 2-11.");
                }
            } while (!valid);
            Age = age;
        }

        public override string ToString()
        {
            string str = $"Dosage by weight ({Weight}): {LiquidDosageByWeight()}\n" +
                         $"Dosage by age ({Age}): {LiquidDosageByAge()}";
            return str;
        }
    }
}
