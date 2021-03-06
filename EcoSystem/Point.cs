﻿using System;

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
            Point point;
            switch (d)
            {
                case Direction.Up:
                    point = new Point { X = p.X, Y = p.Y - 1 };
                    break;
                case Direction.Down:
                    point =  new Point { X = p.X, Y = p.Y + 1 };
                    break;
                case Direction.Left:
                    point = new Point { X = p.X - 1, Y = p.Y };
                    break;
                case Direction.Right:
                    point = new Point { X = p.X + 1, Y = p.Y };
                    break;
                default:
                    throw new ArgumentException("Direction has unexpected value in addition method.");
            }

            return point;
        }

    }
}
