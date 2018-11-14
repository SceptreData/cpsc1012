using System;

namespace CorePortfolio3
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Declare the maximum number of items for our arrays */
            int maxNumItems = 100;
            Console.WriteLine();

            /* Declare our Parallel Arrays. Use a counter to track the number
             * of Elements */
            int numItems = 0;
            string[] itemNames = new string[maxNumItems];
            double[] itemPrices= new double[maxNumItems];

            string[] testNames = { "Apple Sauce", "Crushed Monkeys" };
            double[] testPrices = { 5.99, 14.99 };

            bool running = true;
            while (running)
            {
                DisplayMainMenu();

                switch( GetMainMenuInput() )
                {
                    /* Add Item to Bill */
                    case 1:
                        break;

                    /* Remove Item from Bill */
                    case 2:
                        break;

                    /* Add Tip to Bill - By Percentage or Amount */
                    case 3:
                        break;

                    /* Display Printed Bill (Line Items + Totals )*/
                    case 4:
                        DisplayBill(testNames, testPrices, 2, 5.00);
                        //DisplayBill(itemNames, itemPrices, 2, 5.00);
                        break;

                    /* Clear all items from Bill. */
                    case 5:
                        //ClearBillItems(itemNames, itemPrices, numItems);
                        ClearBillItems(testNames, testPrices, numItems);
                        numItems = 0;
                        break;

                    /* Exit the program */
                    case 6:
                        Console.WriteLine("GoodBye!");
                        running = false;
                        break;
                }
            }

        }

        static bool AddBillItem(string[] itemNames, double[] itemPrices, int numItems)
        {
            return false;
        }

        static void ClearBillItems(string[] itemNames, double[] itemValues, int numItems)
        {
            /* Iterate over our parallel arrays and reset the values */
            for (int i = 0; i < numItems; i++)
            {
                itemNames[i]  = null;
                itemValues[i] = 0;
            }
        }

        static double CalculateNetAmount(double[] itemPrices, int size)
        {
            double netAmount = 0;
            for (int i = 0; i < size; i++)
            {
                netAmount += itemPrices[i];
            }
            return netAmount;
        }

        static double GetTip(double netAmount)
        {
            DisplayTipMenu();
            double tipVal = 0;

            int mode = GetMenuChoice("Tip Mode: ", numOptions: 2);
            /* Calculate Tip by Percentage */
            if (mode == 1)
            {
                double tipRate = GetDouble("Enter Tip Percentage (1-100): ");
                tipVal = netAmount * (tipRate / 100);
            }
            /* Calculate Tip by Amount */
            else if (mode == 2)
            {
                tipVal = GetDouble("Enter Tip Amount: ");
            }
            return tipVal;
        }

        static void DisplayTipMenu()
        {
            Console.Clear();
            Console.WriteLine("\t Select Tip Mode");
            Console.WriteLine("***************************");
            Console.WriteLine(" 1) Tip by Percentage (Num from 0-100)");
            Console.WriteLine(" 2) Tip by Amount");
        }

        static double CalculateGst(double netAmount)
        {
            return 0;
        }
        
        static double CalculateTotalAmount(double netAmount)
        {
            return 0;
        }

        static void DisplayBill(string[] itemNames, double[] itemPrices, int size, double tipVal)
        {
            Console.Clear();
            Console.WriteLine($"{"Description",-20}   {"Price", 10}");
            Console.WriteLine($"{"-----------",-20}   {"-----", 10}");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{itemNames[i],-20}   {itemPrices[i],10}");
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"{$"GST: {tipVal}",-20}");
            Console.WriteLine($"{$"total: {tipVal}",-20}");
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("\tWelcome to Monk's Café!");
            Console.WriteLine("*************************************");
            Console.WriteLine("Please select from the following options:");
            Console.WriteLine(" 1) Add Item");
            Console.WriteLine(" 2) Remove Item");
            Console.WriteLine(" 3) Add Tip (Percentage or Amount)");
            Console.WriteLine(" 4) Display Bill");
            Console.WriteLine(" 5) Clear All");
            Console.WriteLine(" 6) Exit");
            Console.WriteLine();
        }

        static int GetMainMenuInput()
        {
            return GetMenuChoice("Choose from the available options (1-6): ", numOptions: 6);
        }

        static int GetMenuChoice(string msg, int numOptions)
        {
            int menuChoice = -1;
            bool validInput = false;
            while (!validInput)
            {
                menuChoice = (int)GetDouble(msg);
                if (menuChoice < 1 || menuChoice > numOptions)
                {
                    Console.WriteLine($"Invalid Selection. Input must be number from 1-{numOptions}. ");
                } else
                {
                    validInput = true;
                }
            }
            return menuChoice;
        }

        static double GetDouble(string prompt)
        {
            try
            {
                Console.Write($"{prompt}");
                double num = double.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Invalid Input. Number must be positive.");
                    return GetDouble(prompt);
                }
                return num;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Input. Not a Number.");
                return GetDouble(prompt);
            }
        }

        static double GetDouble(string prompt, double max)
        {
            double num = GetDouble(prompt);
            if (num > max)
            {
                Console.WriteLine($"Invalid Input. Number can't be higher than {max}");
                return GetDouble(prompt, max);
            }
            return num;
        }
    }
}
