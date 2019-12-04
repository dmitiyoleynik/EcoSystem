using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Cell
    {
        protected Point position;
        public char Icon { get; set; }
        public Point Position { get => position; set => position = value; }

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
