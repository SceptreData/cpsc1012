﻿using System;

namespace CPSC1012_AP_2_DavidBergeron
{/*
    * Purpose:  To calculate the total cost to carpet a room.
    * 
    * Input: 
    *    - Room Length
    *    - Room Width
    *    - Cost per Square Foot
    * 
    * Process:
    *      - Room Area
    *      - Total Cost (Room Area * Cost Per Square Foot)
    *
    * Output:
    *    - Total cost to carpet the room.
    *         
    * Written By: David Bergeron
    * Date Modified: 2018.12.06
    * */
    class Program
    {
        static void Main(string[] args)
        {
            double roomLength = GetDouble("Enter the Room Length in Feet: ");
            double roomWidth = GetDouble("Enter the Room Width in Feet: ");
            double carpetCost = GetDouble("Enter the Carpet Cost per Square Foot: ");

            RoomDimension rd = new RoomDimension(roomLength, roomWidth);
            RoomCarpet carpet = new RoomCarpet(rd, carpetCost);

            Console.WriteLine(carpet.Size);
            Console.WriteLine(carpet);
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
