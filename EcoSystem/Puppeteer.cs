using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Puppeteer
    {
        private Ocean ocean;
        private FishCreator fishCreator;
        private IInitializer initializer;

        public Puppeteer()
        {
            ocean = new Ocean();
            fishCreator = new FishCreator(ocean.Cells, ocean.Width, ocean.Hight,ocean.SwopCell,ocean.GetRandomDirection,ocean.KillCell,ocean.isFish);
            initializer = new RandomInitializer(fishCreator);
        }
        public void PrintOcean()
        {
            ocean.Print();
        }
        public void InitOcean()
        {
            ocean.PopulateOcean(initializer);
        }
        public void Play(int iter = 1)
        {
            for (int i = 0; i < iter; i++)
            {
                foreach (Cell item in ocean.Cells)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (ocean.isFish(item.Position))
                    {
                        (item as Fish).LifeCicleStep();
                    }

                    if (ocean.isShark(item.Position))
                    {
                        (item as Shark).LifeCicleStep();
                    }
                }
            }
        }
        public void Test()
        {
            fishCreator.CreateFish(new Point { X = 5, Y = 5 });
            (ocean.Cells[5, 5] as Fish).Move(Direction.Up);
            (ocean.Cells[5, 4] as Fish).Reproduce(Direction.Up);
        }

    }
}
