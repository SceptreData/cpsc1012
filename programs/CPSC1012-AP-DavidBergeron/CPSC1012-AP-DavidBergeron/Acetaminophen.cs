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

        }
    }
}
