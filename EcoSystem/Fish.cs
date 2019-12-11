using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Fish : Cell
    {
        #region consts
        protected const int defaultReproduceTime = 30;
        protected const int defaultDieTime = 45;
        #endregion

        #region variables 
        protected int _timeToReproduce;
        protected int _timeToDie;
        protected int _currentTime = 0;
        protected Ocean _ocean;
        #endregion
        public event SwopCell Swop;
        public delegate void CreateFish(Point p);
        public event CreateFish NewInstance;
        public event GetRandomDirection GetDir;
        public event checkCell isCell;
        public event KillCell Kill;

        public Fish(Point p,Ocean ocean, int reproduceTime = defaultReproduceTime, int dieTime = defaultDieTime)
            :base(p)
        {
            this._timeToReproduce = reproduceTime;
            this._timeToDie = dieTime;
            this.Icon = FishIcon.Fish;
            _ocean = ocean;
        }

        public void Move(Direction d)
        {
            FishManager.SwopCell(_position, _position + d, _ocean);
        }
        public void Die()
        {
            FishManager.KillCell(_position, _ocean);
        }
        public void Reproduce(Direction d)
        {
            FishManager.CreateFish(_position + d, _ocean);
        }
        public virtual void LifeCicleStep()
        {
            _currentTime++;
            Direction direct = FishManager.GetDir();
            if (!FishManager.isCell(_position + direct, _ocean)) 
            {
                return;
            }
            if (_currentTime >= _timeToDie)
            {
                Die();
                return;
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
