using System;

namespace OopCore1
{
    class Program
    {
        static void Main(string[] args)
        {
            double gateLength  = 3;
            double gateWidth   = 2;

            double fenceLen    = 10;
            double fenceWidth  = 8;
            double fenceHeight = 4;


            try
            {
                var fenceSize = new Rectangle(fenceLen, fenceWidth);
                var gateRect = new Rectangle(gateLength, gateWidth);

                var fence = new Fence(fenceSize, 6);

                Console.WriteLine(fence);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
