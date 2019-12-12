using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Ocean:IEnumerable
    {
        #region const
        const int DefaultWidth = 120;
        const int DefaultHigth = 25;
        const int DefaultTimeToReproduce = 30;
        #endregion

        #region variables 
        private Cell[,] _cells;
        private int _width;
        private int _hight;
        private int _timeToFishReproduce;
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

        public Ocean(int width = DefaultWidth, int hight = DefaultHigth, int timeToReproduce = DefaultTimeToReproduce)
        {
            _width = width;
            _hight = hight;
            this._timeToFishReproduce = timeToReproduce;
            _cells = new Cell[width, hight];
        }
        
        public IEnumerator GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
