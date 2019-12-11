using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Printer : IPrinter
    {
        public void Print(Ocean ocean)
        {
            char ico;
            Console.Clear();
            for (int i = 0; i < ocean.Hight; i++)
            {
                for (int j = 0; j < ocean.Width; j++)
                {
                    ico = '-';
                    if (ocean[j, i] != null)
                    {
                        ico = ocean[j, i].Icon;
                    }
                    Console.Write(ico);
                }
                Console.WriteLine();
            }
            //Console.WriteLine($"Blocks: {_blocksNumber}, sharks: {_sharksNumber}, fishes: {_fishesNumber}");//Убрать вложенность
        }
    }
}
