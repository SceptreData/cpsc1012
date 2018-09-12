using System;

namespace TakeHeart
{
    class Program
    {
        static void Main(string[] args)
        {
            const int magicNum = 220;
            int age, maxHeartRate;
            float lowLimit, highLimit;

            Console.Write("Enter your age: ");
            age = int.Parse(Console.ReadLine());
            maxHeartRate = magicNum - age;

            lowLimit = (float) 0.6 * maxHeartRate;
            highLimit = (float)0.75 * maxHeartRate;

            Console.WriteLine($"THRZ: {lowLimit} - {highLimit} BPM");
        }
    }
}
