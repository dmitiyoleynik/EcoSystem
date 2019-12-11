using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Shark : Fish
    {
        #region variables 
        private int _currentTimeToDie;
        public new event GetRandomDirection GetDir;
        public new event KillCell Kill;
        public event checkCell isFish;
        public event checkCell isCell;
        #endregion

        public Shark(Point p, SwopCell swop, CreateFish create, GetRandomDirection dir, checkCell cell, KillCell kill, checkCell fish, int reproduceTime = defaultReproduceTime, int dieTime = defaultDieTime) 
            : base(p, swop, create, dir, cell, kill, reproduceTime, dieTime)
        {
            this.Icon = FishIcon.Shark;
            Kill += kill;
            GetDir += dir;
            isCell += cell;
            isFish += fish;
        }

        public void EatFish(Direction dir)
        {
            Kill(_position+dir);
            _currentTimeToDie = _timeToDie;
            Move(dir);
        }

        public override void LifeCicleStep()
        {
            _currentTime++;
            _currentTimeToDie++;
            Direction direct = GetDir();

            if (_currentTime >= _timeToDie)
            {
                Die();
                return;
            }

            if (isFish(_position+direct))
            {
                EatFish(direct);
            }

            if (_currentTime >= _timeToReproduce)
            {
                _currentTime = 0;
                Reproduce(direct);
            }
            else
            {
                Move(direct);
            }

        }
    }
}
