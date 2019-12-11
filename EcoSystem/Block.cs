using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Block : Cell
    {
        public Block(Point p) 
            : base(p)
        {
            this.Icon = FishIcon.Block;
        }
    }
}
