using System;

namespace EcoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point { X = 5, Y = 6 };
            Console.WriteLine(p);
            Direction d = new Direction();
            Console.WriteLine(d);
            d = Direction.Down;
            Console.WriteLine(d);
            p = p + d;
            Console.WriteLine(p);
        }
    }
}
