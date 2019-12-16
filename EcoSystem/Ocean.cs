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

        public Ocean(int width = DEFAULT_WIDTH, int hight = DEFAULT_HIGHT, int timeToReproduce = DEFAULT_TIME_TO_REPRODUCE)
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
