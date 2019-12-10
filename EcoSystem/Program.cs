using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ocean ocean = new Ocean();
            ////ocean.Print();
            ////Console.ReadKey();
            //RandomInitializer ri = new RandomInitializer();
            //ocean.PopulateOcean(ri);
            //ocean.Print();

            //while (true)
            //{
            //    Console.ReadKey();
            //    ocean.Run();
            //    ocean.Print();
            //}
            //MyClass mc = new MyClass(5,5);
            //mc = null;
            //Console.WriteLine(mc == null);

            //Ocean ocean = new Ocean();
            //FishCreator fCreator = new FishCreator(ocean.Cells, ocean.Width, ocean.Hight);
            //RandomInitializer rInit = new RandomInitializer(fCreator);
            //ocean.PopulateOcean(rInit);

            //ocean.Print();

            Puppeteer puppeteer = new Puppeteer();
            puppeteer.InitOcean();
            puppeteer.PrintOcean();
            puppeteer.Play();
            puppeteer.PrintOcean();
            //puppeteer.Test();
            //puppeteer.PrintOcean();


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
