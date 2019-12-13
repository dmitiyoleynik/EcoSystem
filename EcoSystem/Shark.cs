using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Shark : Fish
    {
        #region variables 
        protected int _currentTimeToDie;
        #endregion

        public Shark(Point p, Ocean ocean, int reproduceTime = DefaultReproduceTime, int dieTime = DefaultDieTime)
            : base(p, ocean, reproduceTime, dieTime)
        {
            this.Icon = FishIcon.Shark;
        }

        public void EatFish(Direction dir)
        {
            FishManager.KillCell(_position + dir, _ocean);
            _currentTimeToDie = _timeToDie;
            Move(dir);
        }

        public override void Reproduce(Direction d)
        {
            if (FishManager.IsCell(_position + d, _ocean))
            {
                FishManager.CreateShark(_position + d, _ocean);
            }
        }

        public override void LifeCicleStep()
        {
            _currentTime++;
            _currentTimeToDie++;
            Direction direct = FishManager.GetDir();

            if (_currentTime >= _timeToDie)
            {
                Die();
            }
            else
            {
                if (FishManager.IsFish(_position + direct, _ocean))
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
