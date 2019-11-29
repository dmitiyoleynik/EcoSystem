using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean o = new Ocean();
            //o.Print();
            //Console.ReadKey();
            //o.CreateBlock(new Point { X = 5, Y = 7 });
            //o.CreateFish(new Point { X = 15, Y = 17 });
            //o.CreateShark(new Point { X = 12, Y = 12 });
            //o.Print();
            //Console.ReadKey();
            //o.SwopCell(new Point { X = 15, Y = 17 }, new Point { X = 12, Y = 12 });
            //o.Print();
            //Console.ReadKey();
            //o.KillCell(new Point { X = 15, Y = 17 });
            //o.Print();
            //Console.ReadKey();
            //o.CreateFish(new Point { X = 20, Y = 20 });
            //o.Print();
            //Console.ReadKey();
            o.TestFish(new Point { X = 20, Y = 23 });
            o.Print();

        }
    }
}
