using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            double bmi;
            Console.WriteLine("Enter BMI Value: ");
            bmi = double.Parse(Console.ReadLine());

            string bmiString = "";
            //bmi   meaning
            if (bmi < 18.5)
                bmiString = "Underweight";
            else if (bmi >= 18.5 && bmi < 25)
                bmiString = "normal";
            else if (bmi >= 25 && bmi < 30)
                bmiString = "overweight";
            else if (bmi > 30)
                bmiString = "Obese";

            Console.WriteLine("User is: " + bmiString);
        }
    }
}
