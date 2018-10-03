using System;

namespace ForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (string aaa = "A";;aaa += aaa)
                Console.WriteLine(aaa);
        }
    }
}
