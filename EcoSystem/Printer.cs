using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Printer : IPrinter
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
                        FishIconWrite(ocean[j, i].Icon);
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Blocks: {ocean.BlocksNumber}, sharks: {ocean.SharksNumber}, fishes: {ocean.FishesNumber}");
        }

        public void FishIconWrite(FishIcon fi)
        {
            String fishImage = " ";
            switch (fi)
            {
                case FishIcon.Block:
                    fishImage = "#";
                    break;
                case FishIcon.Fish:
                    fishImage = "F";
                    break;
                case FishIcon.Shark:
                    fishImage = "S";
                    break;
                default:
                    break;
            }
            Console.Write(fishImage);
        }
    }
}
