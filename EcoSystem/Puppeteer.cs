using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Puppeteer
    {
        #region variables 
        private Ocean _ocean;
        private FishManager _fishManager;
        private IInitializer _initializer;
        private IPrinter _printer;
        #endregion

        public Puppeteer()
        {
            _ocean = new Ocean();
            _fishManager = new FishManager(_ocean, _ocean.Width, _ocean.Hight,_ocean.GetRandomDirection);
            _initializer = new RandomInitializer(_fishManager);
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

                    if (_fishManager.isFish(item.Position))
                    {
                        (item as Fish).LifeCicleStep();
                    }

                    if (_fishManager.isShark(item.Position))
                    {
                        (item as Shark).LifeCicleStep();
                    }
                }
            }
        }
        public void Test()
        {
            _fishManager.CreateFish(new Point { X = 5, Y = 5 });
            (_ocean[5, 5] as Fish).Move(Direction.Up);
            (_ocean[5, 4] as Fish).Reproduce(Direction.Up);
        }

    }
}
