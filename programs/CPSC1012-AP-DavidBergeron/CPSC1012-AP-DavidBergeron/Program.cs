using System;

namespace CPSC1012_AP_DavidBergeron
{/*
    * Purpose:  To Calculate the Dosage of Acetaminophen Required for a Small Child.
    * 
    * Input: 
    *    - Child Weight 
    *    - Child Age
    * 
    * Process:
    *      - Compare child's weight and age to our dosage table
    *
    * Output:
    *    - Correct amount of Acetaminophen required.
    *         
    * Written By: David Bergeron
    * Date Modified: 2018.12.06
    * */
    class Program
    {
        static void Main(string[] args)
        {
            RunAcetaminophen();
        }

        static void RunAcetaminophen()
        {
            Console.WriteLine("********************");
            Console.WriteLine("*  Tylenol Dosage  *");
            Console.WriteLine("********************");

            Acetaminophen tylenol = new Acetaminophen();

            bool notFinished = true;
            while (notFinished)
            {
                try
                {

                    GetWeight(tylenol);
                    GetAge(tylenol);
                    
                    Console.WriteLine($"Weight: {tylenol.Weight} lbs, Age: {tylenol.Age} years old.");
                    char yesNo = PromptYesNo("Is the above information about the children correct (Y/N): ");

                    if (yesNo == 'Y')
                        notFinished = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(tylenol);
        }

        static void GetWeight(Acetaminophen ace)
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
            ace.Weight = weight;
        }

        static void GetAge(Acetaminophen ace)
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
            ace.Age = age;
        }

        static char PromptYesNo (string msg)
        {
            Console.Write(msg);
            ConsoleKeyInfo key = Console.ReadKey();
            char c = char.ToUpper(key.KeyChar);
            Console.WriteLine();

            if (c == 'Y' || c == 'N')
            {
                return c;
            }
            else
            {
                throw new Exception("Must Enter (Y)es or (N)o.");
            }
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
