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
        #endregion
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


        public Fish(Point p, SwopCell swop, CreateFish create, GetRandomDirection dir, checkCell cell, KillCell kill, int reproduceTime = defaultReproduceTime, int dieTime = defaultDieTime) : base(p)
        {
            this._timeToReproduce = reproduceTime;
            this._timeToDie = dieTime;
            this.Icon = 'F';
            Swop += swop;
            NewInstance += create;
            GetDir += dir;
            isCell += cell;
            Kill += kill;
        }

        public void Move(Direction d)
        {
            Swop(_position, _position + d);
        }
        public void Die()
        {
            Kill(this._position);
        }
        public void Reproduce(Direction d)
        {
            NewInstance(_position + d);
        }
        public virtual void LifeCicleStep()
        {
            _currentTime++;
            Direction direct = GetDir();
            if (!isCell(_position + direct))
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
