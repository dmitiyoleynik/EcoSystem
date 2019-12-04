using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public struct Point
    {
        public int Y { get; set; }
        public int X { get; set; }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        } 
        public static Point operator +(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return new Point { X = p.X, Y = p.Y - 1 };
                case Direction.Down:
                    return new Point { X = p.X, Y = p.Y + 1 };
                case Direction.Left:
                    return new Point { X = p.X - 1, Y = p.Y };
                case Direction.Right:
                    return new Point { X = p.X + 1, Y = p.Y };
            }
            throw new Exception("Direction has unexpected value in addition method.");
        }
    }
}
