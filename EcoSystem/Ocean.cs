using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Ocean : IEnumerable, ICellContainer
    {
        #region const



        #endregion

        #region fields 

        private Cell[,] _cells;
        private int _width;
        private int _hight;
        private int _timeToFishReproduce;
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

        public int Hight { get => _hight; }

        public int Width { get => _width; }

        public Ocean(int width = Constants.DEFAULT_WIDTH,
            int hight = Constants.DEFAULT_HIGHT,
            int timeToReproduce = Constants.DEFAULT_TIME_TO_REPRODUCE)
        {
            _width = width;
            _hight = hight;
            this._timeToFishReproduce = timeToReproduce;
            _cells = new Cell[width, hight];
            _fishPlay = new FishPlayStrategy();
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
                _fishPlay.RemoveEvent(_cells[p.X, p.Y].LifeCicleStep);
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
