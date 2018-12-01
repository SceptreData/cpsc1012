using System;
using System.Collections.Generic; // For List Class

namespace OopCore3App
{
    class Program
    {
        static int AddItem(List<Item> items)
        {
            Console.Write("Enter Name: ");
            Console.Write("Enter Price: ");
            return items.Count;
        }

        static void DisplayItems(List<Item> items)
        {
            foreach (Item i in items)
            {
                Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            List<Item> itemList = new List<Item>();

            var itm = new Item("Large Coffee", 2.35);
            var itm2 = new Item();

            itemList.Add(itm);
            itemList.Add(itm2);

            DisplayItems(itemList);

            //int count = 0;
            //bool validInput = false;
            //bool addItemFlag = false;

            //while (!addItemFlag)
            //{
            //    count = AddItem(itemList);
            //    Console.WriteLine("Add Item was successful.");


            //}

        }
    }
}
