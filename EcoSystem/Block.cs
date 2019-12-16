using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Block : Cell
    {
        public Block(Point p, Ocean ocean) 
            : base(p, ocean)
        {
            this.Icon = CellIcon.Block;
        }
    }
}
