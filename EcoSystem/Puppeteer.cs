﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Puppeteer
    {
        #region variables 
        private Ocean _ocean;
        private FishCreator _fishCreator;
        private IInitializer _initializer;
        #endregion

        public Puppeteer()
        {
            _ocean = new Ocean();
            _fishCreator = new FishCreator(_ocean.Cells, _ocean.Width, _ocean.Hight,_ocean.SwopCell,_ocean.GetRandomDirection,_ocean.KillCell,_ocean.isFish);
            _initializer = new RandomInitializer(_fishCreator);
        }
        public void PrintOcean()
        {
            _ocean.Print();
        }
        public void InitOcean()
        {
            _ocean.PopulateOcean(_initializer);
        }
        public void Play(int iter = 1)
        {
            for (int i = 0; i < iter; i++)
            {
                foreach (Cell item in _ocean.Cells)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (_ocean.isFish(item.Position))
                    {
                        (item as Fish).LifeCicleStep();
                    }

                    if (_ocean.isShark(item.Position))
                    {
                        (item as Shark).LifeCicleStep();
                    }
                }
            }
        }
        public void Test()
        {
            _fishCreator.CreateFish(new Point { X = 5, Y = 5 });
            (_ocean.Cells[5, 5] as Fish).Move(Direction.Up);
            (_ocean.Cells[5, 4] as Fish).Reproduce(Direction.Up);
        }

    }
}
