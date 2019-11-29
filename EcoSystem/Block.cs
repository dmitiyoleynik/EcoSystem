using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Block : Cell
    {
        public Block(Point p) : base(p)
        {
            this.Icon = '#';
        }
    }
}
