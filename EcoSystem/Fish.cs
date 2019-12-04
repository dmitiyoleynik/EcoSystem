using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Fish : Cell
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
            Swop(position, position + d);
        }
        public void Reproduce(Direction d)
        {
            NewFish(position + d);
        }
        public void LifeCicleStep()
        {
            CurrentTime++;
            Direction direct = GetDir();
            if (!isCell(position + direct))
            {
                return;
            }

            if (CurrentTime >= timeToReproduce)
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
