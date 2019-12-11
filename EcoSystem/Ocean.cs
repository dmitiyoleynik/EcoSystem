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

        public int Hight { get => _hight;  }

        public int Width { get => _width; }

        public Ocean(int width = defaultWidth, int hight = defaultHigth, int timeToReproduce = defaultTimeToReproduce)
        {
            _width = width;
            _hight = hight;
            this._timeToFishReproduce = timeToReproduce;
            _cells = new Cell[width, hight];
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
