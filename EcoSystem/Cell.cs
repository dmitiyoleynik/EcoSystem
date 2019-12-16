﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    abstract public class Cell
    {
        #region variables 
        protected Point _position;
        #endregion
        public CellIcon Icon { get; set; }
        public Point Position { get => _position; set => _position = value; }

        public Cell(Point p)
        {
            _position = p;
        }

        public Cell(int x,int y)
        {
            _position.X = x;
            _position.Y = y;
        }
    }
}
