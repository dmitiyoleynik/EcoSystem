using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Ocean:IEnumerable
    {
        #region
        const int defaultWidth = 120;
        const int defaultHigth = 25;
        const int defaultTimeToReproduce = 30;
        #endregion

        #region variables 
        private Cell[,] _cells;
        private int _width;
        private int _hight;
        private int _fishesNumber = 0;
        private int _sharksNumber = 0;
        private int _blocksNumber = 0;
        private int _timeToFishReproduce;
        private Random _rand = new Random();
        #endregion

        public Cell this[int x,int y]
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

        public int FishNumber { get => _fishesNumber; }

        public int SharkNumber { get => _sharksNumber; }

        public int BlocksNumber { get => _blocksNumber; }

        public int Hight { get => _hight;  }

        public int Width { get => _width; }

        public Ocean(int width = defaultWidth, int hight = defaultHigth, int timeToReproduce = defaultTimeToReproduce)
        {
            _width = width;
            _hight = hight;
            this._timeToFishReproduce = timeToReproduce;
            _cells = new Cell[width, hight];
        }
        

        public bool PointOutOfRange(Point p)
        {
            if (p.X >= Width || p.Y >= Hight || p.X < 0 || p.Y < 0)
            {
                return true;
            }
            else return false;
        }

        public void Print()
        {
            char ico;
            Console.Clear();
            for (int i = 0; i < Hight; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    ico = '-';
                    if (_cells[j, i] != null)
                    {
                        ico = _cells[j, i].Icon;
                    }
                        Console.Write(ico);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Blocks: {_blocksNumber}, sharks: {_sharksNumber}, fishes: {_fishesNumber}");
        }
        public bool isCell(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            return _cells[p.X, p.Y] == null;

        }

        public bool isFish(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            if (_cells[p.X, p.Y] is Fish && !(_cells[p.X, p.Y] is Shark))
            {
                return true;
            }
            return false;
        }

        public bool isShark(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            if (_cells[p.X, p.Y] is Shark)
            {
                return true;
            }
            return false;
        }

        public bool isBlock(Point p)
        {
            if (PointOutOfRange(p))
            {
                return false;
            }

            if (_cells[p.X, p.Y] is Block)
            {
                return true;
            }
            return false;
        }

        public void SwopCell(Point p1, Point p2)
        {
            if (PointOutOfRange(p1) || PointOutOfRange(p2))
            {
                return;
            }

            Cell tmp = _cells[p1.X, p1.Y];
            _cells[p1.X, p1.Y] = _cells[p2.X, p2.Y];
            _cells[p2.X, p2.Y] = tmp;
            if (!isCell(p1))
            {
                _cells[p1.X, p1.Y].Position = p1;
            }
            if (!isCell(p2))
            {
                _cells[p2.X, p2.Y].Position = p2;
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
            _cells[p.X, p.Y] = null;

        }

        public Direction GetRandomDirection()
        {
            return (Direction)(_rand.Next(0, 1000) % 4 + 1);
        }

        public IEnumerator GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
