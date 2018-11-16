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

            /* Declare our Parallel Arrays. 
             * Use a counter to track the number  of Elements */
            int numItems = 0;
            string[] itemNames = new string[maxNumItems];
            double[] itemPrices= new double[maxNumItems];

            string[] testNames = { "Apple Sauce", "Crushed Monkeys" };
            double[] testPrices = { 5.99, 14.99 };

            double tipValue = 0;

            /* Main Program Loop */
            bool running = true;
            while (running)
            {
                Console.Clear();
                DisplayMainMenu();

                switch( GetMainMenuInput() )
                {
                    /* Add Item to Bill */
                    case 1:
                        if (numItems < maxNumItems)
                        {
                            numItems = AddBillItem(itemNames, itemPrices, numItems);
                        } else
                        {
                            Error("Array currently full.");
                        }
                        break;

                    /* Remove Item from Bill */
                    case 2:
                        // listItems();
                        if (numItems == 0)
                        {
                            Error("Cannot remove item from empty bill.");
                        } else
                        {
                            int choice = GetMenuChoice("Which item would you like to remove?", numItems);
                            numItems = RemoveBillItem(choice, itemNames, itemPrices, numItems);
                        }
                        break;

                    /* Add Tip to Bill - By Percentage or Amount */
                    case 3:
                        DisplayTipMenu();
                        tipValue = GetTip (CalculateNetAmount(itemPrices, numItems));
                        break;

                    /* Display Printed Bill (Line Items + Totals )*/
                    case 4:
                        //DisplayBill(testNames, testPrices, 2, 5.00);
                        DisplayBill(itemNames, itemPrices, numItems, 5.00);
                        break;

                    /* Clear all items from Bill. */
                    case 5:
                        ClearBillItems(itemNames, itemPrices, numItems);
                        //ClearBillItems(testNames, testPrices, numItems);
                        numItems = 0;
                        break;

                    /* Exit the program */
                    case 6:
                        Console.Clear();
                        Console.WriteLine("GoodBye!");
                        running = false;
                        break;
                }
            }

        }

        static int AddBillItem(string[] itemNames, double[] itemPrices, int numItems)
        {
            Console.Clear();
            Console.WriteLine("Add Item to Bill");
            Console.WriteLine("------------------");

            // Grab Input from User
            string newItemName = "";
            double newItemPrice = -1;
            Console.Write("Enter Item Name: ");
            newItemName = Console.ReadLine();
            newItemPrice = GetDouble("Enter Item Price: ");

            // Add item to our array;
            itemNames[numItems] = newItemName;
            itemPrices[numItems] = newItemPrice;
            numItems++;

            return numItems;
        }

        static void ClearBillItems(string[] itemNames, double[] itemPrices, int numItems)
        {
            /* Iterate over our parallel arrays and reset the values */
            for (int i = 0; i < numItems; i++)
            {
                itemNames[i]  = null;
                itemPrices[i] = 0;
            }
        }

        //  Remove an item from our bill, then shuffle the remaining elements into place.
        static int RemoveBillItem(int deleteIdx, string[] itemNames, double[] itemPrices, int numItems)
        {
            if (deleteIdx >= numItems || numItems == 0)
            {
                Error("Unable to remove Item.");
                return numItems;
            }
            itemNames[deleteIdx - 1]  = null;
            itemPrices[deleteIdx - 1] = -1;
            for (int i = deleteIdx - 1; i < numItems - 1; i++)
            {
                itemNames[i]  = itemNames[i + 1];
                itemPrices[i] = itemPrices[i + 1];
            }

            return numItems - 1;
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
            const double gstRate = 1.05;
            return netAmount * gstRate;
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

            Console.WriteLine("\n Press Any Key to Continue.");
            Console.ReadLine();
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
                    Error($"Invalid Selection. Input must be number from 1-{numOptions}. ");
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
                    Error("Invalid Input. Number must be positive.");
                    return GetDouble(prompt);
                }
                return num;
            }
            catch (Exception e)
            {
                Error("Invalid Input. Not a Number.");
                return GetDouble(prompt);
            }
        }

        static double GetDouble(string prompt, double max)
        {
            double num = GetDouble(prompt);
            if (num > max)
            {
                Error($"Invalid Input. Number can't be higher than {max}");
                return GetDouble(prompt, max);
            }
            return num;
        }

        static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error: ");
            Console.ResetColor();
        }
    }
}

