using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean ocean = new Ocean();
            ocean.Print();
            Console.ReadKey();
            ocean.PopulateOcean(50,50,20);
            ocean.Print();

            while (true)
            {
                Console.ReadKey();
                ocean.Run();
                ocean.Print();
            }
        }
    }
}
