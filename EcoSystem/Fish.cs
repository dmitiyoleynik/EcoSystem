using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSystem
{
    public class Fish : Cell
    {
        #region consts

        protected const int DEFAULT_REPRODUCE_TIME = 30;
        protected const int DEFAULT_DIE_TIME = 45;

        #endregion

        #region fields
        
        protected int _timeToReproduce;
        protected int _timeToDie;
        protected int _currentTime = 0;

        #endregion

        public Fish(Point p, 
            int reproduceTime = DEFAULT_REPRODUCE_TIME,
            int dieTime = DEFAULT_DIE_TIME)
            : base(p)
        {
            this._timeToReproduce = reproduceTime;
            this._timeToDie = dieTime;
            this.Icon = CellIcon.Fish;
        }

        public void Move(Direction d, ICellContainer _container)
        {
            if (_container.IsCell(_position + d))
            {
                _container.SwopCell(_position, _position + d);
            }
        }

        public void Die(ICellContainer _container)
        {
            _container.KillCell(_position);
        }

        public virtual void Reproduce(Direction d, ICellContainer _container)
        {
            Point newPoint = _position + d;
            if (_container.IsCell(newPoint))
            {
                Fish cell = new Fish(newPoint);
                _container.SetCell(newPoint, cell,cell.LifeCicleStep);
            }
        }

        public override void LifeCicleStep(ICellContainer _container)
        {
            _currentTime++;
            Direction direct = RandomBehavior.GetRandomDirection();

            if (_currentTime >= _timeToDie)
            {
                Die(_container);
            }
            else if (_currentTime >= _timeToReproduce)
            {
                _currentTime = 0;
                Reproduce(direct, _container);
            }
            else
            {
                Move(direct, _container);
            }
        }

        
    }
}
