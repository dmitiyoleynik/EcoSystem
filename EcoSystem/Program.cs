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
            ocean.PopulateOcean(50, 50, 20);
            ocean.Print();

            while (true)
            {
                Console.ReadKey();
                ocean.Run();
                ocean.Print();
            }
            //MyClass mc = new MyClass(5,5);
            //mc = null;
            //Console.WriteLine(mc == null);
        }
        class MyClass
        {
            int _a;
            int _b;
            public MyClass(int A, int B)
            {
                _a = A;
                _b = B;
            }

        }
    }
}
