using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class FishCreator : IFishCreator
    {
        #region variables 
        Ocean _ocean;
        int _widthRange;
        int _higthRange;
        SwopCell swopCell;
        GetRandomDirection randomDirection;
        KillCell killCell;
        checkCell isFish;
        #endregion

        public FishCreator(Ocean ocean, int widthRange, int higthRange,SwopCell swop,GetRandomDirection getRandom,KillCell kill, checkCell fish)
        {
            _ocean = ocean;
            _widthRange = widthRange;
            _higthRange = higthRange;
            swopCell = swop;
            randomDirection = getRandom;
            killCell = kill;
            isFish = fish;
        }

        public bool PointOutOfRange(Point p)
        {
            if (p.X >= _widthRange || p.Y >= _higthRange || p.X < 0 || p.Y < 0)
            {
                return true;
            }
            else return false;
        }
        public void CreateBlock(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            _ocean[p.X, p.Y] = new Block(p);
            //blocksNumber++;
        }

        public void CreateFish(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            _ocean[p.X, p.Y] = new Fish(p,swopCell,CreateFish,randomDirection,isCell,killCell);//, SwopCell, /*CreateFish*/, GetRandomDirection, /*isCell*/, KillCell
            //fishesNumber++;
        }

        public void CreateShark(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            _ocean[p.X, p.Y] = new Shark(p,swopCell, CreateShark, randomDirection,isCell,killCell,isFish);//, SwopCell, CreateShark, GetRandomDirection, isCell, KillCell, isFish
            //sharksNumber++;
        }

        public bool isCell(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            return _ocean[p.X, p.Y] == null;
        }

        public void ClearOcean()
        {
            for (int i = 0; i < _widthRange; i++)
            {
                for (int j = 0; j < _higthRange; j++)
                {
                    _ocean[i, j] = null;
                }
            }
        }
    }
}
