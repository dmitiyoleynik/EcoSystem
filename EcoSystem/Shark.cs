using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Shark : Fish
    {
        private int CurrentTimeToDie;
        public new event GetRandomDirection GetDir;
        public new event KillCell Kill;
        public event checkCell isFish;
        public event checkCell isCell;

        public Shark(Point p, SwopCell swop, CreateFish create, GetRandomDirection dir, checkCell cell, KillCell kill, checkCell fish, int reproduceTime = 45, int dieTime = 30) : base(p, swop, create, dir, cell, kill, reproduceTime, dieTime)
        {
            this.Icon = 'S';
            Kill += kill;
            GetDir += dir;
            isCell += cell;
            isFish += fish;
        }

        public void EatFish(Direction dir)
        {
            Kill(position+dir);
            CurrentTimeToDie = timeToDie;
            Move(dir);
        }
        public new void LifeCicleStep()
        {
            CurrentTime++;
            CurrentTimeToDie++;
            Direction direct = GetDir();

            if (CurrentTime >= timeToDie)
            {
                Die();
                return;
            }

            if (isFish(position+direct))
            {
                EatFish(direct);
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
