using System;

namespace CPSC1012_Ex02_DavidBergeron
{
    /*
     * Purpose: Display the federal, provincial, combined sales tax and total price of an item.
     * 
     * Input: The retail price of the item.
     *              Number of items
     * Process: Get input from user.
     *          Calculate Sales/Provincial tax for each item
     *          Calculate Sales Total
     *
     * Output: Total price without tax
     *         Provincial Tax
     *         Federal Sales Tax
     *         Total sales Tax
     *         Total of the sale.
     *         
     * Written By: David Bergeron
     * Date Modified: 2018.09.17
     * */
    class Program
    {
        static void Main(string[] args)
        {
            // Declare our variables.
            // Constants
            const double provTaxRate = 0.06;
            const double fedTaxRate = 0.05;

            // Inputs
            double itemPrice;
            int numItems;

            // Results
            double beforeTax;
            double totalProvTax;
            double totalFedTax;
            double totalTax;
            double totalSale;

            Console.WriteLine("Enter the item price: ");
            itemPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Number of Items: ");
            numItems = int.Parse(Console.ReadLine());

            beforeTax = itemPrice * numItems;
            Console.WriteLine($"Purchase Total (before Tax): {beforeTax:C}");

            // Calculate Tax
            totalProvTax = beforeTax * provTaxRate;
            Console.WriteLine($"Total Provincial Tax: {totalProvTax:C}");

            totalFedTax = beforeTax * fedTaxRate;
            Console.WriteLine($"Total Federal Tax: {totalFedTax:C}");

            totalTax = totalProvTax + totalFedTax;
            Console.WriteLine($"Total Tax Amount: {totalTax:C}");

            totalSale = beforeTax + totalTax;
            Console.WriteLine($"Total Sale price: {totalSale:C}");
        }
    }
}
