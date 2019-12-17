using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Shark : Fish
    {
        #region fields  

        protected int _currentTimeToDie;

        #endregion

        public Shark(Point p, Ocean ocean, 
            int reproduceTime = DEFAULT_REPRODUCE_TIME,
            int dieTime = DEFAULT_DIE_TIME)
            : base(p, ocean, reproduceTime, dieTime)
        {
            this.Icon = CellIcon.Shark;
        }

        public void EatFish(Direction dir)
        {
            _ocean.KillCell(_position + dir);
            _currentTimeToDie = _timeToDie;
            Move(dir);
        }

        public override void Reproduce(Direction d)
        {
            if (_ocean.IsCell(_position + d))
            {
                _ocean.CreateShark(_position + d);
            }
        }

        public override void LifeCicleStep()
        {
            _currentTime++;
            _currentTimeToDie++;
            Direction direct = RandomBehavior.GetRandomDirection();

            if (_currentTime >= _timeToDie)
            {
                Die();
            }
            else
            {
                if (_ocean.IsFish(_position + direct))
                {
                    EatFish(direct);
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
}
