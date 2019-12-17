using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Ocean:IEnumerable
    {
        #region const

        const int DEFAULT_WIDTH = 120;
        const int DEFAULT_HIGHT = 25;
        const int DEFAULT_TIME_TO_REPRODUCE = 30;

        #endregion

        #region fields 

        private Cell[,] _cells;
        private int _width;
        private int _hight;
        private int _timeToFishReproduce;
        private int _sharksNumber = 0;
        private int _fishesNumber = 0;
        private int _BlocksNumber = 0;
        FishPlay _fishPlay;

        #endregion

        public Cell this[int x, int y]
        {
            get
            {
                return _cells[x, y];
            }
            set
            {
                _cells[x, y] = value;
            }
        }

        public int Hight { get => _hight;  }

        public int Width { get => _width; } 

        public int SharksNumber { get => _sharksNumber; set => _sharksNumber = value; }
        
        public int FishesNumber { get => _fishesNumber; set => _fishesNumber = value; }
        
        public int BlocksNumber { get => _BlocksNumber; set => _BlocksNumber = value; }

        public Ocean(FishPlay fishPlay, int width = DEFAULT_WIDTH,
            int hight = DEFAULT_HIGHT, int timeToReproduce = DEFAULT_TIME_TO_REPRODUCE)
        {
            _width = width;
            _hight = hight;
            this._timeToFishReproduce = timeToReproduce;
            _cells = new Cell[width, hight];
            _fishPlay = fishPlay;
        }
        
        public IEnumerator GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        public bool IsCell(Point p)
        {
            bool result = PointOutOfRange(p)
                ? false : _cells[p.X, p.Y] == null;

            return result;

        }

        public bool PointOutOfRange(Point p)
        {
            if (p.X >= _width || p.Y >= _hight || p.X < 0 || p.Y < 0)
            {
                return true;
            }

            else return false;

        }

        public void KillCell(Point p)
        {
            if (!PointOutOfRange(p))
            {
                if (IsFish(p))
                {
                    _fishesNumber--;
                    _fishPlay.Play -= (_cells[p.X, p.Y] as Fish).LifeCicleStep;
                }
                if (IsShark(p))
                {
                    SharksNumber--;
                    _fishPlay.Play -= (_cells[p.X, p.Y] as Shark).LifeCicleStep;
                }
                _cells[p.X, p.Y] = null;
            }
        }

        public bool IsBlock(Point p)
        {
            bool result = PointOutOfRange(p)
                ? false : (_cells[p.X, p.Y] is Block);

            return result;

        }

        public bool IsFish(Point p)
        {
            bool result = PointOutOfRange(p)
                ? false : (_cells[p.X, p.Y] is Fish);

            return result;

        }

        public bool IsShark(Point p)
        {
            bool result = PointOutOfRange(p)
                ? false : (_cells[p.X, p.Y] is Shark);

            return result;

        }

        public void CreateFish(Point p)
        {
            if (!PointOutOfRange(p) && IsCell(p))
            {
                _cells[p.X, p.Y] = new Fish(p, this);
                FishesNumber++;
                _fishPlay.Play += (_cells[p.X, p.Y] as Fish).LifeCicleStep;
            }
            else
            {
                throw new ArgumentException("Fish can't be created on non-cell point");
            }
        }

        public void CreateShark(Point p)
        {
            if (!PointOutOfRange(p) && IsCell(p))
            {
                _cells[p.X, p.Y] = new Shark(p, this);
                SharksNumber++;
                _fishPlay.Play += (_cells[p.X, p.Y] as Shark).LifeCicleStep;
            }
            else
            {
                throw new ArgumentException("Shark can't be created on non-cell point");
            }
        }

        public void CreateBlock(Point p)
        {
            if (!PointOutOfRange(p) && IsCell(p))
            {
                _cells[p.X, p.Y] = new Block(p, this);
                BlocksNumber++;
            }
            else
            {
                throw new ArgumentException("Block can't be created on non-cell point");
            }
        }

        public void SwopCell(Point p1, Point p2)
        {
            if (!PointOutOfRange(p1) || !PointOutOfRange(p2))
            {
                Cell tmp = _cells[p1.X, p1.Y];
                _cells[p1.X, p1.Y] = _cells[p2.X, p2.Y];
                _cells[p2.X, p2.Y] = tmp;

                if (!IsCell(p1))
                {
                    _cells[p1.X, p1.Y].Position = p1;
                }

                if (!IsCell(p2))
                {
                    _cells[p2.X, p2.Y].Position = p2;
                }
            }
        }

        public void ClearOcean()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _hight; j++)
                {
                    _cells[i, j] = null;
                }
            }
        }

    }
}
