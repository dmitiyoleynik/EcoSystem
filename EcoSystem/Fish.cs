using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Fish : Cell
    {
        #region consts
        protected const int DefaultReproduceTime = 30;
        protected const int DefaultDieTime = 45;
        #endregion

        #region variables 
        protected int _timeToReproduce;
        protected int _timeToDie;
        protected int _currentTime = 0;
        protected Ocean _ocean;
        #endregion

        public Fish(Point p, Ocean ocean, int reproduceTime = DefaultReproduceTime, int dieTime = DefaultDieTime)
            : base(p)
        {
            this._timeToReproduce = reproduceTime;
            this._timeToDie = dieTime;
            this.Icon = FishIcon.Fish;
            _ocean = ocean;
        }

        public void Move(Direction d)
        {
            if (FishManager.IsCell(_position + d, _ocean))
            {
                FishManager.SwopCell(_position, _position + d, _ocean);
            }
        }

        public void Die()
        {
            FishManager.KillCell(_position, _ocean);
        }

        public virtual void Reproduce(Direction d)
        {
            if (FishManager.IsCell(_position + d, _ocean))
            {
                FishManager.CreateFish(_position + d, _ocean);
            }
        }

        public virtual void LifeCicleStep()
        {
            _currentTime++;
            Direction direct = FishManager.GetDir();

            if (_currentTime >= _timeToDie)
            {
                Die();
            }
            else if (_currentTime >= _timeToReproduce)
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
