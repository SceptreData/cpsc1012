using System;

namespace CPSC1012_Ex10_DavidBergeron
{
   /*
    * Purpose: 
    *      - To input a list of Products, then output a formatted display.
    *      - Check for a variety of invalid inputs.
    * 
    * Input: 
    *    - Product Names
    *    - Product Descriptions.
    *    - Product Price
    * 
    * Process:
    *      - Loop over AddProduct method to build Product Array
    *
    * Output:
    *    - Formatted List of Products
    *         
    * Written By: David Bergeron
    * Date Modified: 2018.11.02
    * */
    class Product
    {
        public string name;
        public string description;
        public double price;

        public Product(string prodName, string prodDescription, double prodPrice)
        {
            name = prodName;
            description = prodDescription;
            price = prodPrice;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int maxProducts = 3;
            Product[] products = new Product[maxProducts];

            int numProducts = AddProduct(products);
            DisplayProducts(products, numProducts);
        }

        static int AddProduct(Product[] products)
        {
            int count = 0;
            while (true)
            {
                string name = GetString("\n\nEnter name of a product: ");
                string description = GetString("Enter Product Description: ");
                double price = GetDouble("Enter Product Price: ");

                Product newProd = new Product(name, description, price);
                products[count] = newProd;
                count++;

                Console.WriteLine();
                if (count >= products.Length)
                {
                    Console.WriteLine("Array Full. Unable to add another product.");
                    break;
                }

                if (!PromptYesNo("Add another product (y-n): "))
                {
                    Console.WriteLine();
                    break;
                }
            }

            return count;
        }

        static void DisplayProducts(Product[] products, int productCount)
        {
            Console.WriteLine("\nProducts");
            Console.WriteLine("========");
            Console.WriteLine($"{"name",-20} {"Description",-20} {"Price",20}");

            for (int i = 0; i < productCount; i++)
            {
            Console.WriteLine($"{products[i].name,-20} " +
                              $"{products[i].description,-20}" +
                              $"{products[i].price,20:C}");
            }
        }

        static bool PromptYesNo(string msg)
        {
            Console.Write(msg);
            char c = Console.ReadKey().KeyChar;
            bool isYes = false;
            if (c == 'y')
            {
                isYes = true;
            }
            else if (c == 'n')
            {
                isYes = false;
            } else
            {
                return PromptYesNo(msg);
            }

            return isYes;
        }
        static string GetString(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }

        static double GetDouble(string msg)
        {
            Console.Write(msg);
            double num = double.Parse(Console.ReadLine());

            if (num <= 0)
            {
                Console.WriteLine("Error. Please enter number greater than 0.");
                return GetDouble(msg);
            }
            return num;
        }

    }
}
