using System;

namespace EcoSystem
{
    class ConsoleViewer : IViewer
    {
        public void View(ICellContainer ocean, CellsCounter counter)
        {
            Console.Clear();
            for (int i = 0; i < ocean.Hight; i++)
            {
                for (int j = 0; j < ocean.Width; j++)
                {
                     Console.Write(GetCellIcon(ocean[j,i]));
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Blocks: {counter.Blocks}, " +
                $"sharks: {counter.Sharks}, " +
                $"fishes: {counter.Fishes}");
        }

        public char GetCellIcon(CellIcon fi)
        {
            char fishImage = '-';
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
