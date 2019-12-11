using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Ocean:IEnumerable
    {
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
        

        //public Cell[,] Cells { get => _cells; }

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

        public Ocean(int width = 120, int hight = 25, int timeToReproduce = 30)
        {
            _width = width;
            _hight = hight;
            this._timeToFishReproduce = timeToReproduce;
            _cells = new Cell[width, hight];
            Clear();
        }
        
        private void Clear()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Hight; j++)
                {
                    _cells[i, j] = null;
                }
            }
        }
        //public void Run(int iter = 1)
        //{
        //    for (int i = 0; i < iter; i++)
        //    {
        //        foreach (Cell item in cells)
        //        {
        //            if (item==null)
        //            {
        //                continue;
        //            }

        //            if (isFish(item.Position))
        //            {
        //                (item as Fish).LifeCicleStep();
        //            }

        //            if (isShark(item.Position))
        //            {
        //                (item as Shark).LifeCicleStep();
        //            }
        //        }
        //    }
        //}

        public void PopulateOcean(IInitializer initializer)
        {
            initializer.Initialize(_cells, Width, Hight);
        }
        
        public bool PointOutOfRange(Point p)
        {
            if (p.X >= Width || p.Y >= Hight || p.X < 0 || p.Y < 0)
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

            _cells[p.X, p.Y] = new Block(p);
            _blocksNumber++;
        }
        public void CreateFish(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            _cells[p.X, p.Y] = new Fish(p, SwopCell, CreateFish, GetRandomDirection, isCell, KillCell);
            _fishesNumber++;
        }
        public void CreateShark(Point p)
        {
            if (PointOutOfRange(p))
            {
                return;
            }

            _cells[p.X, p.Y] = new Shark(p, SwopCell, CreateShark, GetRandomDirection, isCell, KillCell, isFish);
            _sharksNumber++;
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
