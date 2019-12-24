using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    abstract public class Cell
    {
        #region fields 

        protected Point _position;
        //protected readonly Ocean _ocean;
        protected readonly ICellContainer _container;
        #endregion

        public CellIcon? Icon { get; set; }

        public Point Position { get => _position; set => _position = value; }

        public Cell(Point p, ICellContainer container)
        {
            _position = p;
            _container = container;
        }

        public Cell(int x, int y, ICellContainer container)
        {
            _position.X = x;
            _position.Y = y;
            _container = container;
        }
    }
}
