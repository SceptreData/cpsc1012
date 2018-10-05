using System;

namespace GregorianCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gregorian Calendar App");

            Console.Write("Enter the month number (1-12): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter the year: ");
            int year = int.Parse(Console.ReadLine());

            bool isLeapYear = false;

            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                isLeapYear = true;
            }

            // We handle February inside the switch statement.
            int monthLen;
            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                monthLen = 30;
            } else
            {
                monthLen = 31;
            }
            
            string monthStr = "";
            switch (month)
            {
                case 1:
                    monthStr = "January";
                    break;

                case 2:
                    monthStr = "February";
                    if (isLeapYear)
                        monthLen = 29;
                    else
                        monthLen = 28;
                    break;

                case 3:
                    monthStr = "March";
                    break;

                case 4:
                    monthStr = "April";
                    break;

                case 5:
                    monthStr = "May";
                    break;

                case 6:
                    monthStr = "June";
                    break;

                case 7:
                    monthStr = "July";
                    break;

                case 8:
                    monthStr = "August";
                    break;

                case 9:
                    monthStr = "September";
                    break;

                case 10:
                    monthStr = "October";
                    break;

                case 11:
                    monthStr = "November";
                    break;

                case 12:
                    monthStr = "December";
                    break;

                default:
                    monthStr = "**INVALID**";
                    break;
            }

            Console.WriteLine($"There are {monthLen} days in {monthStr} {year}.");
        }
    }
}
