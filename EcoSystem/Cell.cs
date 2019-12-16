using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    abstract public class Cell
    {
        #region fields 

        protected Point _position;
        protected readonly Ocean _ocean;
        #endregion

        public CellIcon Icon { get; set; }

        public Point Position { get => _position; set => _position = value; }

        public Cell(Point p, Ocean ocean)
        {
            _position = p;
            _ocean = ocean;
        }

        public Cell(int x, int y, Ocean ocean)
        {
            _position.X = x;
            _position.Y = y;
            _ocean = ocean;
        }
    }
}
