using System;

namespace CorePortfolio3
{  /*
    * Purpose: 
    *      - To input a list of items to a bill, then calculate the total after
    *        tax + tip.
    *      - Allow the user to remove unwanted items or to clear the bill.
    *      - Check for a variety of invalid inputs.
    * 
    * Input: 
    *    - Product Names
    *    - Product Descriptions.
    *    - Product Price
    *    - Tip Value (percentage or Price)
    *    - Item to be deleted.
    * 
    * Process:
    *      - Add Items to our bill.
    *      - Remove unwanted items from the bill
    *      - Choose whether or not we want to add a tip.
    *      - Calculate the bill Total.
    *
    * Output:
    *    - Formatted List of Products
    *    - Formatted Final Bill of Sale
    *    - Variety of menus and selection systems.
    *         
    * Written By: David Bergeron
    * Date Modified: 2018.11.18
    * */
    class Program
    {
        static void Main(string[] args)
        {
            /* Declare the maximum number of items for our arrays */
            int maxNumItems = 5;

            /* Declare our Parallel Arrays. 
             * Use a counter to track the number  of Elements */
            int numItems = 0;
            string[] itemNames = new string[maxNumItems];
            double[] itemPrices= new double[maxNumItems];

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
                            Console.Clear();
                            Error($"Too many Products. The free edition of this program supports {numItems}.");
                            Console.WriteLine("\n Please Upgrade to add more products.");
                            Console.WriteLine("\n Press any key to continue...");
                            Console.ReadLine();
                        }
                        break;

                    /* Remove Item from Bill */
                    case 2:
                        if (numItems == 0) // No items on our bill. ERROR!
                        {
                            Error("Cannot remove item from empty bill.");
                            Console.WriteLine("\nPush Any Key to Continue...");
                            Console.ReadLine();
                        } else
                        {
                            DisplayRemoveMenu(itemNames, itemPrices, numItems);
                            int choice = GetMenuChoice("Which item would you like to remove? ", numItems);
                            int deleteIdx = choice - 1;
                            numItems = RemoveBillItem(deleteIdx, itemNames, itemPrices, numItems);
                        }
                        break;

                    /* Add Tip to Bill - By Percentage or Amount */
                    case 3:
                        DisplayTipMenu();
                        tipValue = GetTip (CalculateNetAmount(itemPrices, numItems));
                        break;

                    /* Display Printed Bill (Line Items + Totals )*/
                    case 4:
                        DisplayBill(itemNames, itemPrices, numItems, tipValue);
                        break;

                    /* Clear all items from Bill. */
                    case 5:
                        ClearBillItems(itemNames, itemPrices, numItems);
                        if (numItems == 0)
                        {
                            Error("Bill already empty.");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadLine();
                        }
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
            Console.WriteLine("Bill Cleared. Press any key to continue...");
            Console.ReadLine();
        }

        static void DisplayRemoveMenu(string[] itemNames, double[] itemPrices, int numItems)
        {
            Console.Clear();
            Console.WriteLine($"{"ItemNo",-8} {"Item Name",-15} {"Item Price",10}");
            Console.WriteLine($"{"======",-8} {"=========",-15} {"==========",10}\n");
            for (int i = 0; i < numItems; i++)
            {
                Console.WriteLine($"{i + 1,-8} {itemNames[i],-15} {itemPrices[i],10:C}");
            }
            Console.WriteLine();
        }


        //  Remove an item from our bill, then shuffle the remaining elements into place.
        static int RemoveBillItem(int deleteIdx, string[] itemNames, double[] itemPrices, int numItems)
        {
            if (deleteIdx >= numItems || numItems == 0)
            {
                Error("Unable to remove Item.");
                return numItems;
            }

            // Delete the item by setting it to invalid values.
            itemNames[deleteIdx]  = null;
            itemPrices[deleteIdx] = -1;

            // Move through the array and bubble down all of the items past the deleted value.
            for (int i = deleteIdx; i < numItems - 1; i++)
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

            int mode = GetMenuChoice("Tip Mode: ", numOptions: 3);
            /* Calculate Tip by Percentage */
            if (mode == 1)
            {
                double tipRate = GetDouble("Enter Tip Percentage (1-100): ", 100);
                tipVal = netAmount * (tipRate / 100);
            }
            /* Calculate Tip by Amount */
            else if (mode == 2)
            {
                tipVal = GetDouble("Enter Tip Amount: ");
            }
            else if (mode == 3)
            {
                tipVal = 0;
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
            Console.WriteLine(" 3) No Tip");
        }

        static double CalculateGst(double netAmount)
        {
            const double gstRate = 0.05;
            return netAmount * gstRate;
        }
        
        static double CalculateTotalAmount(double netAmount, double tipVal, double gstVal)
        {
            return netAmount + tipVal + gstVal;
        }

        static void DisplayBill(string[] itemNames, double[] itemPrices, int size, double tipVal)
        {
            Console.Clear();
            Console.WriteLine($"{"Description",-20}   {"Price", 10}");
            Console.WriteLine($"{"-----------",-20}   {"-----", 10}");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{itemNames[i],-20}   {itemPrices[i],10:C}");
            }

            double netAmount = CalculateNetAmount(itemPrices, size);
            double gstVal = CalculateGst(netAmount);
            
            double billTotal = CalculateTotalAmount(netAmount, tipVal, gstVal);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"\n\tNet Total \t{netAmount, 10:C}");
            Console.WriteLine($"\tTip Amount \t{tipVal, 10:C}");
            Console.WriteLine($"\tTotal GST \t{gstVal, 10:C}");
            Console.WriteLine($"\tTotal Amount \t{billTotal, 10:C}");

            Console.WriteLine("\nPress Any Key to Continue....");
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
            return GetMenuChoice("\nChoose from the available options (1-6): ", numOptions: 6);
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
                    Error($"Invalid Selection. Select 1-{numOptions}.");
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
            Console.WriteLine(msg);
        }
    }
}

