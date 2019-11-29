using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    class Fish : Cell
    {
        private int timeToReproduce;
        private int CurrentTime = 0;
        public delegate void SwopCell(Point p1, Point p2);
        public event SwopCell Swop;
        public delegate void CreateFish(Point p);
        public event CreateFish NewFish;
        public delegate Direction GetRandomDirection();
        public event GetRandomDirection GetDir;
        public delegate bool checkCell(Point p);
        public event checkCell isCell;

        public Fish(Point p, int time, SwopCell swop, CreateFish create, GetRandomDirection dir, checkCell cell) : base(p)
        {
            this.timeToReproduce = time;
            this.Icon = 'F';
            Swop += swop;
            NewFish += create;
            GetDir += dir;
            isCell += cell;
        }
        public void Move(Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    Swop(position, new Point { X = position.X, Y = position.Y - 1 });
                    break;
                case Direction.Down:
                    Swop(position, new Point { X = position.X, Y = position.Y + 1 });
                    break;
                case Direction.Left:
                    Swop(position, new Point { X = position.X - 1, Y = position.Y });
                    break;
                case Direction.Right:
                    Swop(position, new Point { X = position.X + 1, Y = position.Y });
                    break;
                default:
                    break;
            }
        }
        public void Reproduce(Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    NewFish(new Point { X = position.X, Y = position.Y - 1 });
                    break;
                case Direction.Down:
                    NewFish(new Point { X = position.X, Y = position.Y + 1 });
                    break;
                case Direction.Left:
                    NewFish(new Point { X = position.X - 1, Y = position.Y });
                    break;
                case Direction.Right:
                    NewFish(new Point { X = position.X + 1, Y = position.Y });
                    break;
                default:
                    break;
            }
        }
        public void LifeCicleStep()
        {
            CurrentTime++;
            Direction direct = GetDir();
            //switch (direct)
            //{
            //    case Direction.Up:
            //        if (!isCell(new Point { X = position.X, Y = position.Y - 1 }))
            //        {
            //            return;
            //        }
            //        break;
            //    case Direction.Down:
            //        if (!isCell(new Point { X = position.X, Y = position.Y + 1 }))
            //        {
            //            return;
            //        }
            //        break;
            //    case Direction.Left:
            //        if (!isCell(new Point { X = position.X - 1, Y = position.Y }))
            //        {
            //            return;
            //        }
            //        break;
            //    case Direction.Right:
            //        if (!isCell(new Point { X = position.X + 1, Y = position.Y }))
            //        {
            //            return;
            //        }
            //        break;
            //}
            if (CurrentTime == timeToReproduce)
            {
                CurrentTime = 0;
                Reproduce(direct);
            }
            else
            {
                Move(direct);
            }
        }

    }
}
