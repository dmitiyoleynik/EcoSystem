using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Puppeteer
    {
        #region variables 
        private Ocean _ocean;
        private IInitializer _initializer;
        private IPrinter _printer;
        #endregion

        public Puppeteer()
        {
            _ocean = new Ocean();
            _initializer = new RandomInitializer(_ocean);
            _printer = new Printer();
        }
        public void PrintOcean()
        {
            _printer.Print(_ocean);
        }
        public void InitOcean()
        {
            _initializer.Initialize( _ocean.Width, _ocean.Hight);
        }
        public void Play(int iter = 1)
        {
            for (int i = 0; i < iter; i++)
            {
                foreach (Cell item in _ocean)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (FishManager.IsFish(item.Position, _ocean))
                    {
                        (item as Fish).LifeCicleStep();
                    }

                    if (FishManager.IsShark(item.Position,_ocean))
                    {
                        (item as Shark).LifeCicleStep();
                    }
                }
            }
        }
        public void Test()
        {
            FishManager.CreateFish(new Point { X = 5, Y = 5 },_ocean);
            (_ocean[5, 5] as Fish).Move(Direction.Up);
            (_ocean[5, 4] as Fish).Reproduce(Direction.Up);
        }

    }
}
