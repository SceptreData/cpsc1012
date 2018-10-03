using System;

namespace TotalSales
{
    class Program
    {
        static void Main(string[] args)
        {
            int days;
            double sales;
            double totalSales;

            Console.Write("Enter the number of days: ");
            days = int.Parse(Console.ReadLine());

            totalSales = 0;
            for (int i = 1; i <= days; i++)
            {
                Console.Write($"Enter sales for day#{i}");
                sales = double.Parse(Console.ReadLine());
                totalSales += sales;
            }

            Console.WriteLine($"Total Sales: {totalSales:C}");
        }
    }
}
