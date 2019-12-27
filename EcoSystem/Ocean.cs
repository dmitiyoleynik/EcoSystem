using System;
using System.Collections;

namespace EcoSystem
{
    public class Ocean : IEnumerable, ICellContainer
    {
        #region fields 

        private Cell[,] _cells;
        private FishPlayStrategy _fishPlay;

        #endregion

        public CellIcon this[int x, int y]
        {
            get
            {
                CellIcon ci = CellIcon.Cell;
                if(_cells[x,y] != null)
                {
                    ci = _cells[x, y].Icon;
                }

                return ci;
            }
        }

        public int Hight { get; }

        public int Width { get; }

        public Ocean(int width = Constants.DEFAULT_WIDTH,
            int hight = Constants.DEFAULT_HIGHT,
            int timeToReproduce = Constants.DEFAULT_TIME_TO_REPRODUCE)
        {
            Width = width;
            Hight = hight;
            _cells = new Cell[width, hight];
            _fishPlay = new FishPlayStrategy();
        }

        public IEnumerator GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        public bool IsCell(Point p)
        {
            return !PointOutOfRange(p) && _cells[p.X, p.Y] == null;
        }

        public bool PointOutOfRange(Point p)
        {
            return p.X >= Width || p.Y >= Hight || p.X < 0 || p.Y < 0;
        }

        public void KillCell(Point p)
        {
            if (!PointOutOfRange(p))
            {
                _fishPlay.RemoveEvent(_cells[p.X, p.Y].LifeCicleStep);
                _cells[p.X, p.Y] = null;
            }
        }

        public bool IsBlock(Point p)
        {
            return !PointOutOfRange(p) && _cells[p.X, p.Y]?.Icon == CellIcon.Block;
        }

        public bool IsFish(Point p)
        {
            return !PointOutOfRange(p) && _cells[p.X, p.Y]?.Icon == CellIcon.Fish;
        }

        public bool IsShark(Point p)
        {
            return !PointOutOfRange(p) && _cells[p.X, p.Y]?.Icon == CellIcon.Shark;
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
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Hight; j++)
                {
                    _cells[i, j] = null;
                }
            }
        }

        public void SetCell(Point p, Cell cell,Action<ICellContainer> act)
        {
            if (!PointOutOfRange(p) && IsCell(p))
            {
                _cells[p.X, p.Y] = cell;
                _fishPlay.AddEvent(act);   
            }
            else
            {
                throw new ArgumentException("It can't be created on non-cell point");
            }
        }

        public void ExecuteDay()
        {
            _fishPlay.Invoke(this);
        }
    }
}
