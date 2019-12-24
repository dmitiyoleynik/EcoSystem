using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class ConsolePrinter : IPrinter
    {
        public void Print(Ocean ocean)
        {
            Console.Clear();
            for (int i = 0; i < ocean.Hight; i++)
            {
                for (int j = 0; j < ocean.Width; j++)
                {
                    if (ocean[j, i] != null)
                    {
                        Console.Write(GetCellIcon(ocean[j,i]));
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Blocks: {ocean.BlocksNumber}, " +
                $"sharks: {ocean.SharksNumber}, " +
                $"fishes: {ocean.FishesNumber}");
        }

        public char GetCellIcon(CellIcon? fi)
        {
            char fishImage = ' ';
            switch (fi)
            {
                case CellIcon.Block:
                    fishImage = '#';
                    break;
                case CellIcon.Fish:
                    fishImage = 'F';
                    break;
                case CellIcon.Shark:
                    fishImage = 'S';
                    break;
                default:
                    break;
            }

            return fishImage;
        }
    }
}
