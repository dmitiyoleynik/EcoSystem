using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Shark : Cell
    {
        public Shark(Point p) : base(p)
        {
            this.Icon = 'S';
        }
    }
}
