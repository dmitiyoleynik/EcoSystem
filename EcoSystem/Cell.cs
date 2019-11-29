using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Cell
    {
        protected Point position;
        public Point Position { get; set; }
        public char Icon { get; set; }
        public Cell(Point p)
        {
            position = p;
            Icon = '-';
        }
        public Cell(int x,int y)
        {
            position.X = x;
            position.Y = y;
            Icon = '-';
        }
    }
}
