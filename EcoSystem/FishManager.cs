using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class FishManager : IFishManager
    {
        #region variables 
        Ocean _ocean;
        private int _fishesNumber = 0;
        private int _sharksNumber = 0;
        private int _blocksNumber = 0;
        int _widthRange;
        int _higthRange;
        GetRandomDirection randomDirection;
        #endregion

        public FishManager(Ocean ocean, int widthRange, int higthRange,GetRandomDirection getRandom)
        {
            _ocean = ocean;
            _widthRange = widthRange;
            _higthRange = higthRange;
            randomDirection = getRandom;
        }
        public int FishNumber { get => _fishesNumber; }

        public int SharkNumber { get => _sharksNumber; }

        public int BlocksNumber { get => _blocksNumber; }

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
            _blocksNumber++;
        }

        public void CreateFish(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            _ocean[p.X, p.Y] = new Fish(p, SwopCell, CreateFish,randomDirection,isCell, KillCell);//, SwopCell, /*CreateFish*/, GetRandomDirection, /*isCell*/, KillCell
            _fishesNumber++;
        }

        public void CreateShark(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            _ocean[p.X, p.Y] = new Shark(p, SwopCell, CreateShark, randomDirection,isCell, KillCell, isFish);//, SwopCell, CreateShark, GetRandomDirection, isCell, KillCell, isFish
            _sharksNumber++;
        }

        public bool isCell(Point p)
        {
            bool result;

            if (PointOutOfRange(p))
            {
                result = false;
            }

            result = _ocean[p.X, p.Y] == null;

            return result;
        }

        public bool isBlock(Point p)
        {
            bool result;

            if (PointOutOfRange(p))
            {
                result = false;
            }

            if (_ocean[p.X, p.Y] is Block)
            {
                result = true;
            }
            result = false;

            return result;

        }
        public bool isFish(Point p)
        {
            bool result;
            if (PointOutOfRange(p))
            {
                result = false;
            }

            if (_ocean[p.X, p.Y] is Fish && !(_ocean[p.X, p.Y] is Shark))
            {
                result = true;
            }
            result = false;

            return result;

        }

        public bool isShark(Point p)
        {
            bool result;

            if (PointOutOfRange(p))
            {
                result = false;
            }

            if (_ocean[p.X, p.Y] is Shark)
            {
                result = true;
            }

            result = false;

            return result;

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

        public void KillCell(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            if (isFish(p))
            {
                _fishesNumber--;
            }
            if (isShark(p))
            {
                _sharksNumber--;
            }
            _ocean[p.X, p.Y] = null;
        }

        public void SwopCell(Point p1, Point p2)
        {
            if (PointOutOfRange(p1) || PointOutOfRange(p2))
            {
                return;
            }

            Cell tmp = _ocean[p1.X, p1.Y];
            _ocean[p1.X, p1.Y] = _ocean[p2.X, p2.Y];
            _ocean[p2.X, p2.Y] = tmp;
            if (!isCell(p1))
            {
                _ocean[p1.X, p1.Y].Position = p1;
            }
            if (!isCell(p2))
            {
                _ocean[p2.X, p2.Y].Position = p2;
            }

        }

    }
}
