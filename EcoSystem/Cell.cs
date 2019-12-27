using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    abstract public class Cell
    {
        public CellIcon Icon { get; set; }

        public Point Position { get; set; }

        public Cell(Point p)
        {
            Position = p;
        }

        public Cell(int x, int y)
        {
            Position = new Point {X = x,Y = y};
        }

        public abstract void LifeCicleStep(ICellContainer _container);
    }
}
