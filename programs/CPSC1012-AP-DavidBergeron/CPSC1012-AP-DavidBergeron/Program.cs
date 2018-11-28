using System;

namespace CPSC1012_AP_DavidBergeron
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAcetaminophen();
            //RunRoomCarpet();
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

                    tylenol.GetWeight();
                    tylenol.GetAge();
                    //tylenol.Weight = GetDouble("Enter the child's weight in pounds: ");
                    //tylenol.Age = (int)GetDouble("Enter the child's age: ");

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

        static void RunRoomCarpet()
        {
            double roomLength = GetDouble("Enter the Room Length in Feet: ");
            double roomWidth  = GetDouble("Enter the Room Width in Feet: ");
            double carpetCost = GetDouble("Enter the Carpet Cost per Square Foot: ");

            RoomDimension rd = new RoomDimension(roomLength, roomWidth);
            RoomCarpet carpet = new RoomCarpet(rd, carpetCost);

            Console.WriteLine(carpet.DimensionString);
            Console.WriteLine(carpet);
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
