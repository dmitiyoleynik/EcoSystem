using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Fish : Cell
    {
        protected int timeToReproduce;
        protected int timeToDie;
        protected int CurrentTime = 0;
        //public delegate void SwopCell(Point p1, Point p2);
        public event SwopCell Swop;
        public delegate void CreateFish(Point p);
        public event CreateFish NewInstance;
        //public delegate Direction GetRandomDirection();
        public event GetRandomDirection GetDir;
        //public delegate bool checkCell(Point p);
        public event checkCell isCell;
        //public delegate void KillCell(Point p);
        public event KillCell Kill;


        public Fish(Point p, SwopCell swop, CreateFish create, GetRandomDirection dir, checkCell cell, KillCell kill, int reproduceTime = 30, int dieTime = 45) : base(p)
        {
            this.timeToReproduce = reproduceTime;
            this.timeToDie = dieTime;
            this.Icon = 'F';
            Swop += swop;
            NewInstance += create;
            GetDir += dir;
            isCell += cell;
            Kill += kill;
        }
        //public Fish(Point p, int reproduceTime = 30, int dieTime = 45) : base(p)
        //{
        //    this.Icon = 'F';
        //    this.timeToReproduce = reproduceTime;
        //    this.timeToDie = dieTime;

        //}
        public void Move(Direction d)
        {
            Swop(position, position + d);
        }
        public void Die()
        {
            Kill(this.position);
        }
        public void Reproduce(Direction d)
        {
            NewInstance(position + d);
        }
        public void LifeCicleStep()
        {
            CurrentTime++;
            Direction direct = GetDir();
            if (!isCell(position + direct))
            {
                return;
            }
            if (CurrentTime >= timeToDie)
            {
                Die();
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
